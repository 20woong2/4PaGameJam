using UnityEngine;
using TMPro;
using UnityEngine.UI;  // ¹öÆ°¿ë
public class InputBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayTextA;
    [SerializeField] private TextMeshProUGUI displayTextB;
    [SerializeField] private TextMeshProUGUI displayTextC;
    [SerializeField] private TextMeshProUGUI displayTextD;
    [SerializeField] private TextMeshProUGUI displayTextE;
    [SerializeField] private TextMeshProUGUI displayTextF;
    [SerializeField] private TextMeshProUGUI displayTextG;
    [SerializeField] private TextMeshProUGUI displayTextH;
    [SerializeField] private TextMeshProUGUI displayTextI;
    [SerializeField] private TextMeshProUGUI displayTextJ;
    [SerializeField] private TextMeshProUGUI displayTextK;
    [SerializeField] private TextMeshProUGUI displayTextL;
    [SerializeField] private TextMeshProUGUI displayTextAA;
    [SerializeField] private TextMeshProUGUI displayTextBB;
    [SerializeField] private TextMeshProUGUI displayTextCC;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        displayTextA.text = AirSetting.AirResult[0].ToString();
        displayTextB.text = AirSetting.AirResult[1].ToString();
        displayTextC.text = AirSetting.AirResult[2].ToString();
        displayTextD.text = AirSetting.AirResult[3].ToString();
        displayTextE.text = FrequencyPuzzle.HertzResult[0].ToString();
        displayTextF.text = FrequencyPuzzle.HertzResult[1].ToString();
        displayTextG.text = FrequencyPuzzle.HertzResult[2].ToString();
        displayTextH.text = FrequencyPuzzle.HertzResult[3].ToString();
        displayTextI.text = LanguageTextBox.answerList[0].ToString();
        displayTextJ.text = LanguageTextBox.answerList[1].ToString();
        displayTextK.text = LanguageTextBox.answerList[2].ToString();
        displayTextL.text = LanguageTextBox.answerList[3].ToString();
        displayTextAA.text = ResultManager.resultXYZ[0].ToString();
        displayTextBB.text = ResultManager.resultXYZ[1].ToString();
        displayTextCC.text = ResultManager.resultXYZ[2].ToString();
    }
}
