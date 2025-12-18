using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    // static 변수로 유일한 인스턴스를 저장합니다.
    private static BackgroundMusic instance;

    void Awake()
    {
        // 1. 이미 실행 중인 BGM이 있는지 확인합니다.
        if (instance == null)
        {
            // 없다면, 지금 이 오브젝트를 유일한 주인(instance)으로 설정합니다.
            instance = this;

            // 씬이 넘어가도 파괴되지 않도록 설정합니다.
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // 만약 이미 instance가 존재한다면? (메인 씬으로 다시 돌아온 경우 등)
            // 지금 새로 생긴 이 오브젝트는 '중복'이므로 스스로 파괴합니다.
            Destroy(gameObject);
        }
    }
}