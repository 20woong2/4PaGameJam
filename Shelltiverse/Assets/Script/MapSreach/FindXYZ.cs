using UnityEngine;

public class FindXYZ : MonoBehaviour
{
    public SpriteRenderer mySprite;
    public static int X, Y, Z;
    public int[, ] horizon = new int[4, 3];
    public int[] horizonStack = new int[4];
    //horizon1 = 10, 4, 5
    //horizon2 = 6, 7, 8
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        X = 0;
        Y = 0; 
        Z = 0;
        horizon[0, 0] = 10;
        horizon[0, 1] = 4;
        horizon[0, 2] = 5;
        horizon[1, 0] = 6;
        horizon[1, 1] = 7;
        horizon[1, 2] = 8;
        horizon[2, 0] = 1;
        horizon[2, 1] = 2;
        horizon[2, 2] = 3;
        horizon[3, 0] = 9;
        horizon[3, 1] = 11;
        horizon[3, 2] = 12;
        mySprite = GetComponent<SpriteRenderer>();
    }
    void OnMouseDown()
    {
        Debug.Log("클릭 감지");
        CheckColor();
    }
    public void CheckColor()
    {
        for(int i = 0; i < 4; i++)
        {
            horizonStack[i] = 0;
        }
        for(int i = 0; i < 4; i++)
        {
            if (horizon[i, 0] == X)
            {
                horizonStack[i]++;
            }
            if (horizon[i, 1] == Y)
            {
                horizonStack[i]++;
            }
            if (horizon[i, 2] == Z)
            {
                horizonStack[i]++;
            }
        }
        int MaxCount = 0;
        for(int i = 0; i < 4; i++)
        {
            if(MaxCount < horizonStack[i])
            {
                MaxCount = horizonStack[i];
            }
        }
        switch (MaxCount)
        {
            case 0: 
                mySprite.color = Color.red;
                break;
            case 1:
                mySprite.color = Color.orange;
                break;
            case 2:
                mySprite.color = Color.yellow;
                break;
            case 3:
                mySprite.color = Color.green;
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
