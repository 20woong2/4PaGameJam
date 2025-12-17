using UnityEngine;

public class MonitorClick : MonoBehaviour
{
    // 이 오브젝트가 몇 번 인덱스인지 (0~3)
    public int myIndex;
    public static int selectedIndex = -1;

    void OnMouseDown()  // 정확히 이렇게
    {
        selectedIndex = myIndex;
        Debug.Log("Square 클릭, index = " + selectedIndex);
    }
}
