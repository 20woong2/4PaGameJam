using UnityEngine;

public static class DataManager  // MonoBehaviour 제거!
{
    public static int[,] Multiverse = new int[4, 3]
    {
        {339, 57, -20},    // 0행
        {-98, -36, 14},    // 1행
        {124, -16, -32},   // 2행
        {-92, 32, 30}      // 3행
    };
    
    public static int[] activatedWorlds = new int[4] {0, 0, 0, 0};
    public static bool IsFirstRun = true;
}