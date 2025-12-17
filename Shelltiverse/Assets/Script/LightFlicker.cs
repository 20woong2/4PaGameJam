using System.Collections;
using UnityEngine;
using UnityEngine.UI; // UI Image용

public class LightFlicker : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("알파값이 줄어들 때의 최소값입니다. (0에 가까울수록 어두워짐)")]
    [Range(0f, 1f)]
    [SerializeField] private float minAlpha = 0.3f; // 너무 0으로 가면 완전히 안보이니 0.3 정도 추천

    [Tooltip("알파값이 줄어들 때의 최대값입니다. (보통 1보다는 작게 설정)")]
    [Range(0f, 1f)]
    [SerializeField] private float maxDimAlpha = 0.8f;

    [Header("Timing")]
    [Tooltip("깜빡임이 발생하기 전 대기하는 최소 시간")]
    [SerializeField] private float minWaitTime = 0.5f;
    [Tooltip("깜빡임이 발생하기 전 대기하는 최대 시간")]
    [SerializeField] private float maxWaitTime = 3.0f;

    [Tooltip("깜빡일 때 어두운 상태로 유지되는 시간 (짧을수록 지직거리는 느낌)")]
    [SerializeField] private float flickerDuration = 0.1f;

    private Image uiImage;
    private SpriteRenderer spriteRenderer;
    private float defaultAlpha = 1.0f;

    void Start()
    {
        // UI 이미지인지, 2D 스프라이트인지 자동으로 찾습니다.
        uiImage = GetComponent<Image>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (uiImage == null && spriteRenderer == null)
        {
            Debug.LogError("이 오브젝트에는 Image 혹은 SpriteRenderer가 없습니다!");
            return;
        }

        // 깜빡임 코루틴 시작
        StartCoroutine(FlickerRoutine());
    }

    IEnumerator FlickerRoutine()
    {
        while (true)
        {
            // 1. 정상 상태 (불 켜짐) 유지
            SetAlpha(defaultAlpha);

            // 랜덤한 시간만큼 대기 (이 시간 동안은 밝음)
            float waitTime = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(waitTime);

            // 2. 깜빡임 효과 (불 꺼짐/흐려짐)
            // 지직거리는 느낌을 위해 1~3회 정도 빠르게 깜빡이게 할 수도 있지만,
            // 여기서는 깔끔하게 한 번 툭 꺼졌다 켜지는 로직입니다.

            float randomDim = Random.Range(minAlpha, maxDimAlpha);
            SetAlpha(randomDim);

            // 아주 짧은 시간 동안 어두운 상태 유지
            yield return new WaitForSeconds(flickerDuration);

            // 다시 루프의 처음으로 돌아가서 불이 켜집니다.
        }
    }

    // 알파값을 변경하는 함수 (UI와 스프라이트 모두 대응)
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