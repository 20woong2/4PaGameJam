using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // UI 컴포넌트를 제어하기 위해 필수
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    [Header("UI Settings")]
    [Tooltip("화면을 가릴 검은색 이미지를 연결하세요.")]
    public Image fadeImage;

    [Tooltip("페이드 효과가 지속될 시간 (초 단위)")]
    public float fadeDuration = 1.0f;

    void Start()
    {
        // 씬이 시작되면 자동으로 '페이드 인' (검정 -> 투명) 실행
        if (fadeImage != null)
        {
            // 시작할 때 바로 검은색으로 시작해서 점점 투명해짐
            SetAlpha(1);
            StartCoroutine(Fade(1, 0));
        }
    }

    public void LoadScene(string mapName)
    {
        // 버튼을 눌렀을 때 '페이드 아웃' (투명 -> 검정) 후 씬 이동
        StartCoroutine(FadeOutAndLoad(mapName));
    }

    // 페이드 효과를 처리하는 코루틴
    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            // Lerp를 사용해 부드럽게 알파값 변경
            float newAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            SetAlpha(newAlpha);
            yield return null; // 한 프레임 대기
        }

        SetAlpha(endAlpha); // 확실하게 최종 값으로 설정
    }

    // 페이드 아웃이 끝난 뒤 씬을 로드하는 코루틴
    IEnumerator FadeOutAndLoad(string mapName)
    {
        // 1. 페이드 아웃 시작 (투명 -> 검정)
        // 클릭 방지를 위해 Raycast Target이 켜져 있어야 함 (이미지가 화면을 덮으니까)
        if (fadeImage != null)
        {
            fadeImage.raycastTarget = true;
            yield return StartCoroutine(Fade(0, 1));
        }

        // 2. 페이드가 끝나면 씬 이동
        Debug.Log("Scene 이동: " + mapName);
        SceneManager.LoadScene(mapName);
    }

    // 이미지의 투명도(Alpha)를 조절하는 헬퍼 함수
    private void SetAlpha(float alpha)
    {
        if (fadeImage != null)
        {
            Color color = fadeImage.color;
            color.a = alpha;
            fadeImage.color = color;

            // 완전히 투명하면 버튼 클릭을 방해하지 않도록 Raycast 끔
            fadeImage.raycastTarget = (alpha > 0);
        }
    }
}