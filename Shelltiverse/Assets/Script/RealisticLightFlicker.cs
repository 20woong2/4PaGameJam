using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RealisticLightFlicker : MonoBehaviour
{
    [Header("Brightness Settings")]
    [Tooltip("꺼질 때의 최소 밝기 (0.1 ~ 0.5 추천)")]
    [Range(0f, 1f)]
    [SerializeField] private float minAlpha = 0.2f;

    [Tooltip("꺼질 때의 최대 밝기 (완전히 꺼지지 않고 살짝 어두워짐)")]
    [Range(0f, 1f)]
    [SerializeField] private float maxDimAlpha = 0.6f;

    [Header("Timing Settings")]
    [Tooltip("다음 깜빡임까지 대기하는 시간 (최소)")]
    [SerializeField] private float minWaitTime = 0.5f;
    [Tooltip("다음 깜빡임까지 대기하는 시간 (최대)")]
    [SerializeField] private float maxWaitTime = 4.0f;

    [Header("Burst Settings (연속 깜빡임)")]
    [Tooltip("한 번 작동할 때 연속으로 깜빡일 확률 (0 ~ 100%)")]
    [Range(0, 100)]
    [SerializeField] private int burstChance = 30; // 30% 확률로 여러번 깜빡임

    [Tooltip("연속 깜빡임 횟수 최소값")]
    [SerializeField] private int minBurstCount = 2;
    [Tooltip("연속 깜빡임 횟수 최대값")]
    [SerializeField] private int maxBurstCount = 5;

    [Tooltip("깜빡거리는 찰나의 속도 (낮을수록 빠름)")]
    [SerializeField] private float flickerSpeed = 0.05f;

    private Image uiImage;
    private SpriteRenderer spriteRenderer;
    private float defaultAlpha = 1.0f;

    void Start()
    {
        uiImage = GetComponent<Image>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (uiImage == null && spriteRenderer == null)
        {
            Debug.LogError("Image나 SpriteRenderer가 필요합니다.");
            return;
        }

        StartCoroutine(FlickerRoutine());
    }

    IEnumerator FlickerRoutine()
    {
        while (true)
        {
            // 1. 평소에는 불이 켜져 있음
            SetAlpha(defaultAlpha);

            // 다음 깜빡임까지 랜덤 대기
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));

            // 2. 깜빡임 시작 여부 결정 (단발성 vs 연속성)
            // burstChance 확률로 여러 번 깜빡임, 아니면 1번만 깜빡임
            int flickCount = (Random.Range(0, 100) < burstChance)
                            ? Random.Range(minBurstCount, maxBurstCount + 1)
                            : 1;

            // 3. 결정된 횟수만큼 "치지직" 거림
            for (int i = 0; i < flickCount; i++)
            {
                // 어둡게 만듦 (불 꺼짐)
                float dimAlpha = Random.Range(minAlpha, maxDimAlpha);
                SetAlpha(dimAlpha);
                yield return new WaitForSeconds(Random.Range(0.02f, flickerSpeed)); // 아주 짧게 유지

                // 다시 밝게 만듦 (잠깐 돌아옴)
                // 마지막 회차가 아니면 살짝 덜 밝게 돌아오게 해서 불안정한 느낌 추가
                float recoverAlpha = (i == flickCount - 1) ? defaultAlpha : Random.Range(0.8f, 1.0f);
                SetAlpha(recoverAlpha);

                // 다음 깜빡임 사이의 아주 짧은 간격
                yield return new WaitForSeconds(Random.Range(0.02f, flickerSpeed));
            }
        }
    }

    void SetAlpha(float alpha)
    {
        if (uiImage != null)
        {
            Color c = uiImage.color;
            c.a = alpha;
            uiImage.color = c;
        }
        else if (spriteRenderer != null)
        {
            Color c = spriteRenderer.color;
            c.a = alpha;
            spriteRenderer.color = c;
        }
    }
}