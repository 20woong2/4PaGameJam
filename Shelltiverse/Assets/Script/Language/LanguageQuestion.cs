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
        myText.text = "NULL";
        questionLineUp.Clear();
        for (int i = 0; i < 4; i++) 
        {
            if (questActive[i])
            {
                SetQuestion(i);
            }
        }
    }
    public static void SetQuestion(int num)
    {

        Debug.Log("SetQuestion 호출됨");
        questActive[num] = true;
        Debug.Log("문제 리스트에 추가" + questions[num]);
        questionLineUp.Add(questions[num]);
        if (instance != null)
        {
            Debug.Log("ActivateNextUI 실행");
            instance.ActivateNextUI(num);
        }
        else
        {
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
                Debug.Log("문제칸에 텍스트 입력" + questionLineUp[num]);
                qText.text = questionLineUp[num];
            }
        }
    }
    public static string ShiftASCII(string text, int n)
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
        Debug.Log("문자열 삽입" + questionLineUp[num]);
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
