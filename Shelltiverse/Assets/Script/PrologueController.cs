using UnityEngine;
using System.Collections;

public class PrologueController : MonoBehaviour
{
    [Header("Dialogue Manager 연결")]
    public DialogueManager dialogueManager;

    [Header("프롤로그 데이터")]
    [Tooltip("대사 텍스트 입력 (4줄)")]
    [TextArea(3, 5)]
    public string[] prologueLines;

    [Tooltip("각 대사에 맞는 성우 더빙 파일 연결 (대사 개수와 동일하게)")]
    public AudioClip[] prologueVoiceOvers;

    [Header("설정")]
    [Tooltip("다음 문장으로 넘어가기 위한 최소 대기 시간")]
    public float minInputInterval = 1.0f;

    // PlayerPrefsKey는 다른 씬(시작 화면)과 공유해야 하므로 public const로 변경하거나
    // 이전 답변처럼 별도의 GameConstants 파일을 쓰는 것이 좋습니다.
    // 일단 이 스크립트 내에서만 쓴다고 가정하고 private로 유지합니다.
    // 만약 시작 화면에서 초기화하신다면 이 변수명과 똑같은 문자열을 사용하셔야 합니다.
    private const string PlayerPrefsKey = "HasSeenPrologue";

    private float markTime; // 문장이 시작된 시간을 기록하는 변수

    void Start()
    {
        // (중요) 시작 화면에서 초기화 로직을 구현했다면 아래 3줄은 주석 처리하거나 지우세요.
        // 테스트를 위해 매번 실행하고 싶다면 주석을 해제하세요.
        // PlayerPrefs.DeleteKey(PlayerPrefsKey); 

        // 이미 봤다면 오브젝트를 끄고 종료
        if (PlayerPrefs.GetInt(PlayerPrefsKey, 0) == 1)
        {
            gameObject.SetActive(false);
            return;
        }

        // 코루틴 시작
        StartCoroutine(RunPrologueSequence());
    }

    IEnumerator RunPrologueSequence()
    {
        // 대사 개수만큼 반복
        for (int i = 0; i < prologueLines.Length; i++)
        {
            // ========== 1. 즉시 대사 및 목소리 출력 ==========
            // 루프가 시작되자마자 기다림 없이 바로 실행됩니다.
            if (i < prologueVoiceOvers.Length)
            {
                dialogueManager.PlayVoiceOver(prologueVoiceOvers[i]);
            }
            dialogueManager.ShowMessage(prologueLines[i]);
            if (i == 0)
            {
                GameObject.Find("Story 1 Canvas").transform.Find("Prologue Image 1").gameObject.SetActive(true);
            }
            if (i == 2)
            {
                GameObject.Find("Story 1 Canvas").transform.Find("Prologue Image 1").gameObject.SetActive(false);
            }

            // 문장이 표시되기 시작한 시점을 기록합니다.
            markTime = Time.time;

            // ========== 2. 다음 넘기기 대기 ==========

            // 조건 1: 문장이 표시된 시점부터 최소 설정 시간(1초)이 지날 때까지 대기
            // (타이핑이 진행 중이어도 시간은 흐릅니다)
            yield return new WaitUntil(() => Time.time - markTime >= minInputInterval);

            // 조건 2: 1초가 지난 후, 플레이어의 스페이스바나 클릭 입력을 대기
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0));

            // 입력이 들어오면 루프가 다시 돌면서 다음 문장(i+1)을 즉시 출력합니다.
        }

        // 모든 반복이 끝나면 프롤로그 종료
        EndPrologue();
    }

    void EndPrologue()
    {
        // 봤다는 기록 저장
        PlayerPrefs.SetInt(PlayerPrefsKey, 1);
        PlayerPrefs.Save();

        // 대화창 및 목소리 정리 후 캔버스 끄기
        dialogueManager.HideDialogue();
        gameObject.SetActive(false);
    }
}