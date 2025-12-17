using UnityEngine;

public class BoxReaction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public LanguageQuestion languageQuestion;
    public int thisNum;
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        languageQuestion.SetText(thisNum);
        LanguageTextBox.thisQuest = thisNum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
