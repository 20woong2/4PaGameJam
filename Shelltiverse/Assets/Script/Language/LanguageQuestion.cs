using TMPro;
using UnityEngine;
using static UnityEngine.UI.Image;

public class LanguageQuestion : MonoBehaviour
{
    public static string question;
    public static int changeNum;
    public string questionResult;
    [SerializeField] private TextMeshProUGUI myText;
    void Start()
    {
        question = "APPLE";
        changeNum = Random.Range(1, 27);
        questionResult = ShiftASCII(question, changeNum);
        myText.text = questionResult;
    }
    public string ShiftASCII(string text, int n)
    {
        char[] charArray = text.ToCharArray();

        for (int i = 0; i < charArray.Length; i++)
        {
            if(charArray[i] + n > 90) 
            { 
                charArray[i] = (char)(charArray[i] + n + 6); 
            } else 
            { 
                charArray[i] = (char)(charArray[i] + n); 
            }
                
        }

        return new string(charArray);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
