using Unity.VisualScripting;
using UnityEngine;

public class HintManager : MonoBehaviour
{
    public GameObject hintImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void ShowHint()
    {
        hintImage.SetActive(!hintImage.activeSelf);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
