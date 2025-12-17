using UnityEngine;

// 그래프를 그려주는 스크립트
public class WaveRenderer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int points = 100; // 선을 구성할 점의 개수
    public float width = 10.0f; // 파형의 전체 가로 길이

    // 그래프 위치 조절은 이걸로 하면됨^^
    private float posX = -2.5f;
    private float posY = 2.0f;

    // 이 값들을 조절하여 파형을 바꿉니다.
    public float amplitude = 1f; 
    public float frequency = 1f;

    void Update()
    {
        DrawWave();
    }

    void DrawWave()
    {
        lineRenderer.positionCount = points;
        for (int i = 0; i < points; i++)
        {
            float progress = (float)i / (points - 1);
            float x = progress * width + posX;
            // 사인파 공식: y = A * sin(f * x)
            float y = amplitude * Mathf.Sin(x * frequency) * 0.4f + posY;
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}