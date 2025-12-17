using TMPro;
using UnityEngine;
using System.Collections.Generic;
using static UnityEngine.UI.Image;
using System.Threading;

public class LanguageQuestion : MonoBehaviour
{
    public static LanguageQuestion instance;
    public static string[] questions = new string[4];
    public static int[] changeNums = new int[4];
    public static bool[] questActive = new bool[4];
    public Canvas myCanvas;
    public static List<string> questionLineUp = new List<string>();
    [SerializeField] private TextMeshProUGUI myText;
    private int activeCount = 0;
    public static int waitCount = 0;

    void Awake()
    {
        instance = this;
    }
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
        for (int i = 0; i < 4; i++) 
        {
            if (questActive[i])
            {
                ActivateNextUI(i);
            }
        }
    }
    public static void SetQuestion(int num)
    {

        Debug.Log("SetQuestion 호출됨");
        questActive[num] = true;
        questionLineUp.Add(questions[num]);
        if (instance != null)
        {
            Debug.Log("ActivateNextUI 실행");
            instance.ActivateNextUI(num);
        }
    }
    private void ActivateNextUI(int num)
    {
        Debug.Log("ActivateNextUI 호출");
        string targetName = "Quest" + (num+1);
        Transform target = myCanvas.transform.Find(targetName);
        string boxName = "num" + (num + 1);
        Transform numTransform = target.transform.Find(boxName);
        if (numTransform != null)
        {
            Debug.Log("numTransform null ??");
            BoxReaction reaction = numTransform.GetComponent<BoxReaction>();
            if (reaction != null)
            {
                Debug.Log("reaction null ??");
                reaction.thisNum = num;
            }
        }
        if (target != null)
        {
            Debug.Log("오브젝트 활성화");
            target.gameObject.SetActive(true);
            TextMeshProUGUI qText = target.GetComponentInChildren<TextMeshProUGUI>();
            if (qText != null)
            {
                qText.text = questionLineUp[num];
            }
        }
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
    public void SetText(int num)
    {
        myText.text = questionLineUp[num];
    }
    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.A))  
            {
            SetQuestion(activeCount);
            activeCount++;
        }
    }
}
