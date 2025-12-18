using UnityEngine;
using TMPro;
using UnityEngine.UI;  // 버튼용
public class InputResult : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    
    [SerializeField] private TextMeshProUGUI displayQ;
    [SerializeField] private TextMeshProUGUI displayTextA;
    [SerializeField] private TextMeshProUGUI displayTextB;
    [SerializeField] private TextMeshProUGUI displayTextC;
    [SerializeField] private TextMeshProUGUI displayTextD;
    [SerializeField] private Button submitButton;

    // 선택된 인덱스 (0~3) - 매 프레임 MonitorClick에서 가져옴
    private int airIndex = -1;
    
    void Start()
    {
        inputField.contentType = TMP_InputField.ContentType.IntegerNumber;
        inputField.characterLimit = 3;
        inputField.placeholder.GetComponent<TextMeshProUGUI>().text = "숫자 입력 (0-999)";
        
        // 버튼을 눌렀을 때만 처리
        submitButton.onClick.AddListener(SubmitNumber);
    }
    
    void Update()
    {
        // 현재 선택된 인덱스 동기화
        airIndex = MonitorClick.selectedIndex;
        
        // 결과 표시
        if(MonitorClick.selectedIndex >= 0)displayQ.text = AirSetting.AirQuestion[MonitorClick.selectedIndex];
        
        displayTextA.text = "" + AirSetting.AirResult[0];
        displayTextB.text = "" + AirSetting.AirResult[1];
        displayTextC.text = "" + AirSetting.AirResult[2];
        displayTextD.text = "" + AirSetting.AirResult[3];
    }

    // 버튼 눌렀을 때만 호출
    public void SubmitNumber()
    {
        OnNumberSubmitted(inputField.text);
        // inputField.text = "";  // 필요하면 여기서 지우기
    }
    
    void OnNumberSubmitted(string input)
    {
        // 아직 아무 칸도 선택 안 했으면 무시
        if (airIndex < 0)
        {
            Debug.LogWarning("칸이 선택되지 않았습니다.");
            return;
        }

        if (int.TryParse(input, out int number))
        {
            ProcessNumber(number);
        }
        else
        {
            Debug.LogWarning("정수가 아닙니다.");
        }
    }
    
    void ProcessNumber(int number)
    {
        if (AirSetting.AirResult != null &&
            airIndex >= 0 && airIndex < AirSetting.AirResult.Length)
        {
            AirSetting.AirResult[airIndex] = number;
        }
        else
        {
            Debug.LogWarning("AirResult 인덱스 범위 오류 또는 배열 null");
        }

        Debug.Log($"받은 숫자: {number}, AirResult[{airIndex}]에 저장됨");
    }
}
