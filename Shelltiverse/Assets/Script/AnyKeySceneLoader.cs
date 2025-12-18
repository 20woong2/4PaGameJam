using UnityEngine;
// 씬 관리를 위해 반드시 필요한 네임스페이스입니다.
using UnityEngine.SceneManagement;

public class AnyKeySceneLoader : MonoBehaviour
{
    [Header("연결")]
    public SceneLoader sceneLoader;

    [Header("이동할 씬 이름 설정")]
    public string nextSceneName = "Main";

    private bool isTriggered = false;

    void Update()
    {
        // 이미 한 번 눌렸다면 더 이상 체크하지 않음 (중복 실행 방지)
        if (isTriggered) return;

        // Input.anyKeyDown: 마우스 클릭을 포함한 키보드의 아무 키가 눌린 순간 true 반환
        // 만약 마우스 클릭은 제외하고 싶다면 이 코드는 적합하지 않을 수 있습니다.
        if (Input.anyKeyDown)
        {
            Debug.Log("아무 키나 눌렸습니다. 다음 씬으로 이동합니다.");
            isTriggered = true; // 중복 방지 플래그 설정
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        // 입력된 이름의 씬을 로드합니다.
        sceneLoader.LoadScene(nextSceneName);
    }
}