using UnityEngine;
using TMPro;
using UnityEngine.UI; // 슬라이더 사용을 위해 추가

public class SliderControl : MonoBehaviour
{
    [Header("UI Settings")]
    public Slider hertzSlider; 


    

    

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
        // 슬라이더 값을 실시간으로 반영
        if (hertzSlider != null)
        {
            //UpdateValue(hertzSlider.value);
        }

    }

    // 슬라이더 값에 따라 위치, 볼륨, 텍스트를 업데이트하는 핵심 함수
    // void UpdateValue(float sliderValue)
    // {
    //     // 슬라이더(0~1)를 Y좌표(-4.5~4.5)로 변환
    //     float minY = -4.5f;
    //     float maxY = 4.5f;  
    //     float newY = Mathf.Lerp(minY, maxY, sliderValue);
    //     transform.position = new Vector3(transform.position.x, newY, transform.position.z);

    // }


}