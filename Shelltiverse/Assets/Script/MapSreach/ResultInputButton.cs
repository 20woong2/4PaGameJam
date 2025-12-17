using UnityEngine;

public class ResultInputButton : MonoBehaviour
{
    public int myIndex;
    public static int selectedIndex = -1;
    void OnMouseDown()  // 정확히 이렇게
    {
        
        selectedIndex = myIndex;
        Debug.Log("Square 클릭, index = " + selectedIndex);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
