using UnityEngine;
using TMPro;
using UnityEngine.UI;  // 버튼용
public class ResultInputButton : MonoBehaviour
{
    public int myIndex;
    [SerializeField] private TextMeshProUGUI displayText;
    public void OnButtonClick()  // 정확히 이렇게
    {
        Debug.Log("Square 클릭, index = ");
        if(myIndex <= 3)
        displayText.text = AirSetting.AirResult[myIndex].ToString();
        else if(myIndex>3 && myIndex<=7)
        displayText.text = AirSetting.AirResult[myIndex-4].ToString();
        else if(myIndex>7 && myIndex<=11)
        displayText.text = AirSetting.AirResult[myIndex-8].ToString();
        Debug.Log("Square 클릭, index = ");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
