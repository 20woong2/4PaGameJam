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
    [SerializeField] private GameObject AWorld;
    [SerializeField] private GameObject AWorld1;
    [SerializeField] private GameObject BWorld;
    [SerializeField] private GameObject BWorld1;
    [SerializeField] private GameObject CWorld;
    [SerializeField] private GameObject CWorld1;
    [SerializeField] private GameObject DWorld;
    [SerializeField] private GameObject DWorld1;
    public static bool firstturn = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(firstturn == true)
        {
            AWorld.SetActive(false);
            AWorld1.SetActive(false);
            BWorld.SetActive(false);
            BWorld1.SetActive(false);
            CWorld.SetActive(false);
            CWorld1.SetActive(false);
            DWorld.SetActive(false);
            DWorld1.SetActive(false);
        }
        firstturn = false;
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
                if(i==0)
                {
                    AWorld.SetActive(true);
                    AWorld1.SetActive(true);
                }
                else if(i==1)
                {
                    BWorld.SetActive(false);
                    BWorld1.SetActive(false);
                }
                else if(i==2)
                {
                    CWorld.SetActive(false);
                    CWorld1.SetActive(false);
                }
                else if(i==3)
                {
                    DWorld.SetActive(false);
                    DWorld1.SetActive(false);
                }
                Count = 0;
                break;
            }
            else if(Count == 2)
            {
                yellowB = true;
                Count = 0;
            }
            else if(Count == 1)
            {
                orangeB = true;
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
            targetImage.color = new Color(55, 255, 0, 0.2f);
        }
        else if (yellowB == true)
        {
            targetImage.color = new Color(255, 238, 0, 0.2f);
        }
        else if(orangeB == true)
        {
            targetImage.color = new Color(255, 199, 0, 0.2f);
        }
        else if(redB == true)
        {
            targetImage.color = new Color(255, 0, 0, 0.2f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
