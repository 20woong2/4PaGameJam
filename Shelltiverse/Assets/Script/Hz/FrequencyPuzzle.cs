using UnityEngine;
using UnityEngine.UI;

public class FrequencyPuzzle : MonoBehaviour
{
    [Header("Wave Renderers")]
    public WaveRenderer targetWave; // 정답 파형 (회색 등)
    public WaveRenderer playerWave; // 플레이어가 조절하는 파형 (파란색 등)

    [Header("UI Sliders")]
    public Slider ampSlider;
    public Slider freqSlider;

    [Header("Settings")]
    public float threshold = 0.1f; // 얼마나 정확해야 정답으로 인정할지

    [Header("Audio Settings")]
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioClip noise;
    public AudioClip morse;

    public float correctAM;
    public float correctFR;

    private float timer = 0f;
    private bool isClear = false;

    void Start()
    {
        // 정답 파형을 랜덤하게 설정 (예시)
        correctAM = Random.Range(0.1f, 2.9f);
        correctFR = Random.Range(0.1f, 2.9f);
        targetWave.amplitude = correctAM;
        targetWave.frequency = correctFR;

        // 시작하자마자 소리 재생 준비
        PlaySound("noise");
        PlaySound("morse");
    }

    void Update()
    {
        // 1. 슬라이더 값을 플레이어 파형에 적용
        playerWave.amplitude = ampSlider.value;
        playerWave.frequency = freqSlider.value;

        // 2. 정답 여부 체크
        CheckAnswer();

        // 볼륨 조절
        Volume(audioSource);
        Volume(audioSource2);
    }

    void CheckAnswer()
    {
        float ampDiff = Mathf.Abs(playerWave.amplitude - targetWave.amplitude);
        float freqDiff = Mathf.Abs(playerWave.frequency - targetWave.frequency);

        if (ampDiff < threshold && freqDiff < threshold)
        {
            // 정답일 때 실행할 로직 (예: 색깔 변경, 다음 단계 이동 등)
            // playerWave.lineRenderer.startColor = Color.green;
            // playerWave.lineRenderer.endColor = Color.green;
            // 3초 뒤 클리어
            timer += Time.deltaTime;
            if (timer >= 3.0f && !isClear)
            {
                isClear = true;
                Debug.Log("Clear!");
            }
        }
        else
        {
            timer = 0f;
            isClear = false;
            // playerWave.lineRenderer.startColor = Color.cyan;
            // playerWave.lineRenderer.endColor = Color.cyan;
        }
    }



     void PlaySound(string sound)
    {
         if (sound == "noise") 
        {
            
            if (noise != null && !audioSource.isPlaying) 
            {
                Debug.Log("wow");
                audioSource.clip = noise;
                audioSource.Play();
            }
        }

        if (sound == "morse") 
        {
            if (morse != null && !audioSource2.isPlaying) 
            {
                audioSource2.clip = morse;
                audioSource2.Play();
            }
        }
    }

    void Volume(AudioSource audio)
    {
        // float distance = Mathf.Abs(ampSlider.value - correctAM);
        // float maxDistance = 3.0f;
        // float newVolume = (distance / maxDistance);

        // if (audio == audioSource2) 
        //     newVolume = 1.0f - (distance / maxDistance);

        // audio.volume = Mathf.Clamp(newVolume, 0f, 1f);

        

        // 1. 진폭 차이와 주파수 차이를 각각 구합니다.
        float ampDiff = Mathf.Abs(ampSlider.value - correctAM);
        float freqDiff = Mathf.Abs(freqSlider.value - correctFR);

        // 2. 두 차이의 합을 구합니다. (이 값이 0에 가까울수록 정답)
        float totalDiff = ampDiff + freqDiff;

        // 3. 최대 오차 범위를 설정합니다. (슬라이더 범위에 따라 조절)
        // 슬라이더가 0~3 범위라면, 최대 오차는 약 6(3+3) 정도가 됩니다.
        float maxDiff = 4.0f; 

        // 4. 정답과의 거리를 비율(0~1)로 변환합니다.
        // 가득 차면 1, 정답이면 0이 되는 값입니다.
        float ratio = Mathf.Clamp01(totalDiff / maxDiff);

        if (audio == audioSource) // Noise 소리 (멀어질수록 커짐)
        {
            audio.volume = ratio; 
        }
        else if (audio == audioSource2) // Morse 소리 (가까워질수록 커짐)
        {
            audio.volume = 1.0f - ratio; 
        }
    }
}