using UnityEngine;

public class WaveRenderer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int points = 50; // 선을 구성할 점의 개수
    public float width = 300.0f; // 파형의 전체 가로 길이

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
            float x = progress * width;
            // 사인파 공식: y = A * sin(f * x)
            float y = amplitude * Mathf.Sin(x * frequency);
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}