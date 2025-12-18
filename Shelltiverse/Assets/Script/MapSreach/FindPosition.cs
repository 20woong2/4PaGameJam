using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class FindPosition : MonoBehaviour, IPointerDownHandler
{
    [Header("UI")]
    [SerializeField] private Image targetImage;
    
    [Header("World Objects")]
    [SerializeField] private GameObject[] worlds = new GameObject[4];
    [SerializeField] private GameObject[] worlds1 = new GameObject[4];

    private bool isInitialized = false;  // 초기화 플래그

    private void Awake()
    {
        // 1순위: 강제 모든 월드 비활성화 (Inspector 상태 무시)
        ForceDeactivateAllWorlds();
        
        // 2순위: 정상 초기화
        if (!isInitialized)
        {
            InitializeOnFirstRun();
            isInitialized = true;
        }
    }

    // 새로 추가: Inspector 상태 무시하고 강제 비활성화
    private void ForceDeactivateAllWorlds()
    {
        for (int i = 0; i < 4; i++)
        {
            if (worlds[i] != null) worlds[i].SetActive(false);
            if (worlds1[i] != null) worlds1[i].SetActive(false);
        }
        Debug.Log("강제 초기화: 모든 월드 비활성화");
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // 최초 실행 시 모든 월드 비활성화
    private void InitializeOnFirstRun()
    {
        if (DataManager.IsFirstRun)
        {
            InitializeAllWorlds(false);
            DataManager.IsFirstRun = false;
            Debug.Log("최초 실행: 모든 월드 비활성화 완료");
        }
        else
        {
            RestoreWorldStates();
            Debug.Log("저장된 상태 복원 완료");
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬 전환 후 상태 복원 (최초 실행 제외)
        if (!DataManager.IsFirstRun)
        {
            RestoreWorldStates();
        }
    }

    private void RestoreWorldStates()
    {
        for (int i = 0; i < 4; i++)
        {
            bool shouldBeActive = DataManager.activatedWorlds[i] == 1;
            if (worlds[i] != null) worlds[i].SetActive(shouldBeActive);
            if (worlds1[i] != null) worlds1[i].SetActive(shouldBeActive);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("클릭 감지");
        
        // ? 3개 월드 활성화 체크 추가
        CheckAllWorldsActivated();
        
        int matchCount = 0;
        int perfectMatchIndex = -1;
        
        for (int i = 0; i < 4; i++)
        {
            int rowMatch = 0;
            for (int j = 0; j < 3; j++)
            {
                if (ResultManager.resultXYZ[j] == DataManager.Multiverse[i, j])
                    rowMatch++;
            }
            
            Debug.Log($"World {i}: {rowMatch}/3 일치");
            
            if (rowMatch == 3)
            {
                perfectMatchIndex = i;
                matchCount = 3;
                break;
            }
            matchCount = Mathf.Max(matchCount, rowMatch);
        }
        
        Debug.Log($"최종: matchCount={matchCount}, perfect={perfectMatchIndex}");
        
        // 색상 적용
        targetImage.color = perfectMatchIndex >= 0 ? 
            new Color(55f / 255f, 1f, 0f, 0.2f) :
            matchCount switch
            {
                2 => new Color(1f, 238f / 255f, 0f, 0.2f),
                1 => new Color(1f, 199f / 255f, 0f, 0.2f),
                0 => new Color(1f, 0f, 0f, 0.2f),
                _ => Color.white
            };
        
        if (perfectMatchIndex >= 0)
        {
            ActivateWorld(perfectMatchIndex);
        }
    }

    private void ActivateWorld(int index)
    {
        if (worlds[index] != null)
        {
            worlds[index].SetActive(true);
            DataManager.activatedWorlds[index] = 1;
        }
        if (worlds1[index] != null)
        {
            worlds1[index].SetActive(true);
            DataManager.activatedWorlds[index] = 1;
        }
        Debug.Log($"World {index} 활성화됨");
    }

    private void InitializeAllWorlds(bool active)
    {
        for (int i = 0; i < 4; i++)
        {
            if (worlds[i] != null) worlds[i].SetActive(active);
            if (worlds1[i] != null) worlds1[i].SetActive(active);
            DataManager.activatedWorlds[i] = active ? 1 : 0;
        }
    }
    private void CheckAllWorldsActivated()
    {
        int activeCount = 0;
        for (int i = 0; i < 4; i++)
        {
            bool isActive = DataManager.activatedWorlds[i] == 1;
            if (isActive) activeCount++;
        }
        
        Debug.Log($"현재 활성화된 월드: {activeCount}/4");
            // 보너스: 4개 모두 활성화 시
            if (activeCount == 4)
            {
                Debug.Log("? 모든 멀티버스 완전 해금! TRUE ENDING 가능!");
            }
        
    }
}