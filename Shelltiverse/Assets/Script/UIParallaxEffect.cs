using UnityEngine;

public class UIParallaxEffect : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("이미지가 움직일 최대 거리입니다. 값이 클수록 많이 움직입니다.")]
    [SerializeField] private float moveAmount = 20f;

    [Tooltip("움직임의 부드러움 정도입니다. 값이 작을수록 더 부드럽고 느리게 따라옵니다.")]
    [SerializeField] private float smoothSpeed = 5f;

    private RectTransform rectTransform;
    private Vector2 startPos;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        // 시작할 때의 초기 위치(정중앙)를 기억합니다.
        startPos = rectTransform.anchoredPosition;
    }

    void Update()
    {
        // 1. 마우스의 화면상 위치를 구합니다.
        // 화면 중앙을 (0,0)으로, 좌측하단을 (-1,-1), 우측상단을 (1,1) 범위로 정규화합니다.
        float x = (Input.mousePosition.x / Screen.width) - 0.5f;

        // -0.5 ~ 0.5 범위를 -1 ~ 1 범위로 확장
        Vector2 mousePosNorm = new Vector2(x * 2f, 0);

        // 2. 목표 위치 계산 (반대 방향)
        // 마우스가 오른쪽(+)으로 가면 이미지는 왼쪽(-)으로 가야 하므로 마이너스를 곱해줍니다.
        Vector2 targetPos = startPos + (mousePosNorm * -moveAmount);

        // 3. 부드럽게 이동 (Lerp 사용)
        rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, targetPos, Time.deltaTime * smoothSpeed);
    }
}