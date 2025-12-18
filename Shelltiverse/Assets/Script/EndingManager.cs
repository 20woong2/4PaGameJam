using UnityEngine;

public class EndingManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("파괴할 사운드 매니저 이름")]
    [Tooltip("이전 씬에서 넘어온 SoundManager 오브젝트의 정확한 이름을 입력하세요.")]
    public string targetManagerName = "SoundManager";

    void Start()
    {
        // 1. 이름으로 오브젝트 찾기
        // GameObject.Find는 활성화된 오브젝트 중에서 이름을 검색합니다.
        GameObject soundManager = GameObject.Find(targetManagerName);

        // 2. 오브젝트가 존재하는지 확인 후 파괴
        if (soundManager != null)
        {
            Debug.Log($"[EndingScene] 기존의 {soundManager.name}를 발견하여 파괴합니다.");
            // DontDestroyOnLoad로 살아남은 오브젝트를 파괴합니다.
            // 이 오브젝트의 자식으로 있던 BGM, 효과음 오브젝트들도 같이 파괴됩니다.
            Destroy(soundManager);
        }
        else
        {
            Debug.LogWarning($"[EndingScene] '{targetManagerName}' 이름을 가진 오브젝트를 찾을 수 없습니다. 이미 파괴되었거나 이름이 다를 수 있습니다.");
        }
    }
}
