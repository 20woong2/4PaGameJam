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
        displayTextE.text = AirSetting.AirResult[0].ToString();
        displayTextF.text = AirSetting.AirResult[1].ToString();
        displayTextG.text = AirSetting.AirResult[2].ToString();
        displayTextH.text = AirSetting.AirResult[3].ToString();
        displayTextI.text = AirSetting.AirResult[0].ToString();
        displayTextJ.text = AirSetting.AirResult[1].ToString();
        displayTextK.text = AirSetting.AirResult[2].ToString();
        displayTextL.text = AirSetting.AirResult[3].ToString();
    }
}
