using TMPro;
using UnityEngine;

public class LanguageTextBox : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    int playerAnswer;
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
                FindXYZ.Z = playerAnswer;
                if (playerAnswer == LanguageQuestion.changeNum)
                {
                    Debug.Log("정답");
                }
                else {
                    Debug.Log("오답");
                }
            }
            inputField.text = "";
            inputField.ActivateInputField();
        }
    }
}
