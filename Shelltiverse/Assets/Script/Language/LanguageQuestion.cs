using TMPro;
using UnityEngine;
using System.Collections.Generic;
using static UnityEngine.UI.Image;

public class LanguageQuestion : MonoBehaviour
{
    public static string[] questions = new string[4];
    public static int[] changeNums = new int[4];
    public static List<string> questionLineUp = new List<string>();
    [SerializeField] private TextMeshProUGUI myText;
    void Start()
    {
        questions[0] = "AIR"; 
        questions[1] = "PARALLEL";
        questions[2] = "SHELL";
        questions[3] = "WORLD";
        changeNums[0] = -20;
        changeNums[1] = 14;
        changeNums[2] = -32;
        changeNums[3] = 30;
        for(int i = 0; i < 4; i++)
        {
            questions[i] = ShiftASCII(questions[i], changeNums[i]);
        }
        myText.text = "NULL";
    }
    public static void SetQuestion(int num)
    {
        questionLineUp.Add(questions[num]);
    }
    public string ShiftASCII(string text, int n)
    {
        char[] charArray = text.ToCharArray();

        for (int i = 0; i < charArray.Length; i++)
        {
            charArray[i] = (char)(charArray[i] + n); 
        }
        return new string(@charArray);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
