using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FrequencyPuzzle : MonoBehaviour
{
    [Header("Wave Renderers")]
    public WaveRenderer targetWave; // 정답 파형 
    public WaveRenderer playerWave; // 플레이어가 조절하는 파형

    [Header("UI Sliders")]
    public Slider ampSlider;
    public Slider freqSlider;
    public TextMeshProUGUI logText;

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

    public TextMeshProUGUI textAM;
    public TextMeshProUGUI textFR;
    private float hertzAM;
    private float hertzFR;

    public static int[] HertzResult = new int[4];
    public int level = 1;




    void Start()
    {
        // 정답 파형을 랜덤하게 설정 (예시)
        correctAM = Random.Range(0.1f, 2.9f);
        correctFR = Random.Range(0.1f, 2.9f);
        targetWave.amplitude = correctAM;
        targetWave.frequency = correctFR;

        // 시작하자마자 소리 재생
        PlaySound("noise");
        PlaySound("morse");

        logText.text = "...";
    }



    void Update()
    {
        // 슬라이더 값을 플레이어 파형에 적용
        playerWave.amplitude = ampSlider.value;
        playerWave.frequency = freqSlider.value;

        // 정답 여부 체크
        int oldLv = level;
        CheckAnswer();

        // 볼륨 조절
        Volume(audioSource);
        Volume(audioSource2);

        // 헤르츠 텍스트 표시
        hertzAM = (ampSlider.value + 5.0f) * 28 + 23.0f; // 대충 쓸데없는 계산식
        hertzAM = Mathf.Clamp(hertzAM, 37f, 289f); // 최소최대값 지정
        textAM.text = hertzAM.ToString("F0") + "Hz"; // 소수점 제거

        hertzFR = (freqSlider.value + 5.0f) * 28 + 23.0f;
        hertzFR = Mathf.Clamp(hertzFR, 37f, 289f);
        textFR.text = hertzFR.ToString("F0") + "Hz"; 

        // 레밸 변경 검사
        if(oldLv != level) 
        {
            correctAM = Random.Range(0.1f, 2.9f);
            correctFR = Random.Range(0.1f, 2.9f);
            targetWave.amplitude = correctAM;
            targetWave.frequency = correctFR;
        }
    }



    void CheckAnswer()
    {
        float ampDiff = Mathf.Abs(playerWave.amplitude - targetWave.amplitude);
        float freqDiff = Mathf.Abs(playerWave.frequency - targetWave.frequency);

        if (ampDiff < threshold && freqDiff < threshold)
        {
            // 정답일 때 실행할 로직 
            timer += Time.deltaTime;
            // playerWave.lineRenderer.startColor = Color.green;
            // playerWave.lineRenderer.endColor = Color.green;
            // 2.5초 뒤 클리어
            if (timer >= 2.5f && !isClear)
            {
                HertzResult[level-1] = (int)Mathf.Floor(hertzAM - hertzFR);
                Debug.Log("Clear! : " + HertzResult[level-1]);
                logText.text = "Clear! : " + HertzResult[level - 1];
                LanguageQuestion.SetQuestion(level - 1);

                isClear = true;
                timer = 0f;
                if (level < 4) level++;
                else  
                {
                    Debug.Log("문제 모두 해결");
                    logText.text = "ALL CLEAR";
                    audioSource.Stop();
                    audioSource2.Stop();
                }
            }
        }
        else
        {
            timer = 0f;
            isClear = false;
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
        // 정답이랑 차이 값 구하기
        float ampDiff = Mathf.Abs(ampSlider.value - correctAM);
        float freqDiff = Mathf.Abs(freqSlider.value - correctFR);

        // 두 차이의 합을 구하기 
        float totalDiff = ampDiff + freqDiff;

        // 최대 오차 범위를 설정합니다. (슬라이더 범위에 따라 조절)
        // 슬라이더가 0~3 범위라면, 최대 오차는 약 6(3+3) 정도가 됩니다.
        float maxDiff = 4.0f; 

        // 정답과의 거리를 비율(0~1)로 변환
        float ratio = Mathf.Clamp01(totalDiff / maxDiff);

        // 볼륨 지정
        float noiseVolume = ratio;
        float morseVolume = Mathf.Pow(1.0f - ratio, 10f); // 3은 곡선의 강도

        if (audio == audioSource) // Noise 소리 (멀어질수록 커짐)
            audio.volume = noiseVolume;
        else if (audio == audioSource2) // Morse 소리 (가까워질수록 커짐)
            audio.volume = morseVolume;
    }
}