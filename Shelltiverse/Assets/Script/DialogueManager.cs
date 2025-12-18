using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    [Header("UI 연결")]
    public TextMeshProUGUI dialogueText;

    [Header("글자 출력 간격 (초)")]
    public float typingSpeed = 0.05f;

    [Header("타이핑 효과음 설정")]
    public AudioSource typingAudioSource; // 기존 오디오 소스 (이름 명확하게 변경)
    public AudioClip typingSound;

    // ========== [추가된 부분] ==========
    [Header("성우 목소리 설정 (별도 AudioSource 필요)")]
    public AudioSource voiceAudioSource; // 성우 전용 오디오 소스
    // ===================================

    private Coroutine currentCoroutine;

    public bool IsTyping
    {
        get { return currentCoroutine != null; }
    }

    public void ShowMessage(string message)
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }

        dialogueText.text = "";
        currentCoroutine = StartCoroutine(TypeText(message));
    }

    // ========== [추가된 함수] 성우 목소리 재생 ==========
    public void PlayVoiceOver(AudioClip clip)
    {
        // 1. 혹시 재생 중인 이전 목소리가 있다면 즉시 정지
        if (voiceAudioSource.isPlaying)
        {
            voiceAudioSource.Stop();
        }

        // 2. 새로운 클립이 있을 경우에만 재생
        if (clip != null)
        {
            voiceAudioSource.clip = clip;
            voiceAudioSource.Play();
        }
    }
    // =====================================================

    IEnumerator TypeText(string message)
    {
        foreach (char letter in message.ToCharArray())
        {
            dialogueText.text += letter;

            // typingAudioSource로 이름 변경됨
            if (letter != ' ' && typingAudioSource != null && typingSound != null)
            {
                typingAudioSource.PlayOneShot(typingSound);
            }

            yield return new WaitForSeconds(typingSpeed);
        }

        currentCoroutine = null;
    }

    public void HideDialogue()
    {
        if (currentCoroutine != null) StopCoroutine(currentCoroutine);

        // 대화창이 꺼질 때 목소리도 같이 꺼줍니다.
        if (voiceAudioSource != null) voiceAudioSource.Stop();

        dialogueText.text = "";
        currentCoroutine = null;
    }
}