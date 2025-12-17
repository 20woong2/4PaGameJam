using UnityEngine;
using System.Collections.Generic;
public class AirSetting : MonoBehaviour
{
    public static int[] AirResult = new int[4];
    public static string[] AirQuestion = new string[4];
    public static string[] AirOrigin = new string[4]{"질소 : 79% 산소 : 11% 아르곤 : 15%","질소 : 60% 산소 : 20% 아르곤 : 3%","질소 : 70% 산소 : 25% 아르곤 3%","질소 : 90 산소 : 10% 아르곤 : 0%"};
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShuffleToDest();
        Debug.Log($"dest: {dest[0]}, {dest[1]}, {dest[2]}, {dest[3]}");
    }

    // Update is called once per frame
    void Update()
    {
        int length = source.Length; // 4
        int[] indices = { 0, 1, 2, 3 };

        // Fisher-Yates ����
        for (int i = length - 1; i > 0; i--)
        {
            int r = Random.Range(0, i + 1);
            int temp = indices[i];
            indices[i] = indices[r];
            indices[r] = temp;
        }

        
        for (int i = 0; i < length; i++)
        {
            AirQuestion[i] = AirOrigin[indices[i]];
        }
    }
}
