using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LanguageTextBox : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    int playerAnswer;
    public static int thisQuest;
    public static int[] answerList = new int[4];
    [SerializeField] private TextMeshProUGUI displayTextA;
    [SerializeField] private TextMeshProUGUI displayTextB;
    [SerializeField] private TextMeshProUGUI displayTextC;
    [SerializeField] private TextMeshProUGUI displayTextD;
    void Start()
    {
        inputField.onSubmit.AddListener(OnSubmitInput);
    }

    public void OnSubmitInput(string input)
    {
        if (!string.IsNullOrEmpty(input))
        {
            Debug.Log("플레이어 입력값: " + input);
            if (int.TryParse(input, out playerAnswer))
            {
                answerList[thisQuest] = playerAnswer;
                Debug.Log(answerList[0]);
                Debug.Log(answerList[1]);
                Debug.Log(answerList[2]);
                Debug.Log(answerList[3]);
            }
            inputField.text = "";
            inputField.ActivateInputField();
        }
    }
    void Update()
    {
        displayTextA.text = "" + answerList[0].ToString();
        displayTextB.text = "" + answerList[1].ToString();
        displayTextC.text = "" + answerList[2].ToString();
        displayTextD.text = "" + answerList[3].ToString();
    }
}
