using UnityEngine;
using TMPro;
using UnityEngine.UI; // 슬라이더 사용을 위해 추가

public class SliderControl : MonoBehaviour
{
    [Header("UI Settings")]
    public Slider hertzSlider; // 유니티 에디터에서 Slider를 연결하세요.

    [Header("Audio Settings")]
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioClip noise;
    public AudioClip morse;

    [Header("Target Settings")]
    public Vector3 targetPosition = new Vector3(0f, 0f, 0f); // 정답 위치
    public TextMeshProUGUI hzText;

    private float hertz;
    private float timer = 0f;
    private bool isClear = false;

    

    

    void Start()
    {

        // 슬라이더 초기 설정
        if (hertzSlider != null)
        {
            hertzSlider.minValue = 0f;
            hertzSlider.maxValue = 3.0f;
            hertzSlider.value = (hertzSlider.minValue+hertzSlider.maxValue)/2;
            // 초기 슬라이더 위치에 맞춰 오브젝트 위치 설정
            //UpdateValue(hertzSlider.value);
        }

    }

    void Update()
    {
        // 1. 슬라이더 값을 실시간으로 반영
        if (hertzSlider != null)
        {
            //UpdateValue(hertzSlider.value);
        }

        // 2. 정답 범위 체크 및 타이머 로직
        //CheckClearCondition();
    }

    // 슬라이더 값에 따라 위치, 볼륨, 텍스트를 업데이트하는 핵심 함수
    void UpdateValue(float sliderValue)
    {
        // 슬라이더(0~1)를 Y좌표(-4.5~4.5)로 변환
        float minY = -4.5f;
        float maxY = 4.5f;  
        float newY = Mathf.Lerp(minY, maxY, sliderValue);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);


        // 헤르츠 계산 및 텍스트 표시
        // hertz = (transform.position.y + 5.0f) * 28 + 23.0f;
        // hertz = Mathf.Clamp(hertz, 37f, 289f);
        // hzText.text = hertz.ToString("F0") + "Hz"; // 소수점 제거
    }

    // void CheckClearCondition()
    // {
    //     float targetMin = targetPosition.y - 1.0f;
    //     float targetMax = targetPosition.y + 1.0f;

    //     if (transform.position.y >= targetMin && transform.position.y <= targetMax)
    //     {
    //         timer += Time.deltaTime;
    //         if (timer >= 2.5f && !isClear)
    //         {
    //             isClear = true;
    //             Debug.Log("Clear!");
    //         }
    //     }
    //     else
    //     {
    //         timer = 0f;
    //         isClear = false;
    //     }
    // }

}