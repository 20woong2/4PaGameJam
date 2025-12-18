using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 1. 프롤로그 기록 초기화 (다른 씬에서 쓸 키와 토시 하나 틀리지 않고 똑같아야 합니다!)
        // "HasSeenPrologue" 라는 이름의 저장된 데이터를 삭제합니다.
        PlayerPrefs.DeleteKey("HasSeenPrologue");

        // (선택사항) 확실하게 디스크에 저장
        PlayerPrefs.Save();

        Debug.Log("프롤로그 기록이 초기화되었습니다.");

        // 2. 메인 게임 씬으로 이동 (씬 이름은 본인 프로젝트에 맞게 수정)
        SceneManager.LoadScene("MainGameScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
