using UnityEngine;
using TMPro;
using UnityEngine.UI;  // 버튼용
public class ResultInputButton : MonoBehaviour
{
    public int myIndex;
    public void OnButtonClick()  // 정확히 이렇게
    {
        if(myIndex <= 3)
        ResultManager.resultXYZ[0] = AirSetting.AirResult[myIndex];
        else if(myIndex>3 && myIndex<=7)
        ResultManager.resultXYZ[1] = FrequencyPuzzle.HertzResult[myIndex-4];
        else if(myIndex>7 && myIndex<=11)
        ResultManager.resultXYZ[2] = LanguageTextBox.answerList[myIndex-8];
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
