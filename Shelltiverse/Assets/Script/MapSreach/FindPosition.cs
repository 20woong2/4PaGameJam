using UnityEngine;
using UnityEngine.UI;  // ← 이 줄 추가!
using TMPro;           // 이미 있으면 OK
using UnityEngine.EventSystems;
public class FindPosition : MonoBehaviour, IPointerDownHandler
{
    private int Count=0;
    private bool greenB = false;
    private bool orangeB = false;
    private bool yellowB = false;
    private bool redB = false;
    [SerializeField] private Image targetImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("zmf");
        for(int i = 0;i<4;i++)
        {
            for(int j = 0; j<3;j++)
            {
                if(ResultManager.resultXYZ[j] == DataManager.Multiverse[i,j])
                {
                    Count++;
                }
            }
            if(Count == 3)
            {
                greenB = true;
                Count = 0;
                break;
            }
            else if(Count == 2)
            {
                orangeB = true;
                Count = 0;
            }
            else if(Count == 1)
            {
                yellowB = true;
                Count = 0;
            }
            else if(Count == 0)
            {
                redB = true;
                Count = 0;
            }
        }
        if(greenB == true)
        {
            targetImage.color = Color.green;
        }
        else if(orangeB == true)
        {
            targetImage.color = Color.orange;
        }
        else if(yellowB == true)
        {
            targetImage.color = Color.yellow;
        }
        else if(redB == true)
        {
            targetImage.color = Color.red;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
