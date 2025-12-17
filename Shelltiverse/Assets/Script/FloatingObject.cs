using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    [Header("Floating Settings")]
    [Tooltip("위아래로 움직이는 속도입니다. 값이 클수록 빨리 움직입니다.")]
    [SerializeField] private float moveSpeed = 1.5f;

    [Tooltip("위아래로 움직이는 범위(높이)입니다. 값이 클수록 더 높이 올라갔다 내려갑니다.")]
    [SerializeField] private float moveDistance = 0.3f;

    private Vector3 startPosition;
    // 여러 오브젝트가 동시에 똑같이 움직이는 것을 방지하기 위한 랜덤 시작 시간 값
    private float randomOffset;

    void Start()
    {
        // 게임 시작 시점의 최초 위치를 기준점으로 기억합니다.
        startPosition = transform.position;

        // 자연스러운 움직임을 위해 시작 시점에 랜덤한 오프셋을 줍니다.
        // (0 ~ 2*PI 사이의 랜덤값)
        randomOffset = Random.Range(0f, Mathf.PI * 2);
    }

    void Update()
    {
        // 1. 새로운 Y값 계산
        // Mathf.Sin(시간 * 속도 + 랜덤시작점) 결과값(-1~1)에 이동 거리(moveDistance)를 곱합니다.
        float newY = startPosition.y + Mathf.Sin(Time.time * moveSpeed + randomOffset) * moveDistance;

        // 2. 위치 적용
        // X와 Z축은 원래 위치를 유지하고, Y축만 계산된 새로운 값을 적용합니다.
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}