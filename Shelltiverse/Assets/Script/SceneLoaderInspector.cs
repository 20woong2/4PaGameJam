using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneLoaderInspector : MonoBehaviour
{
    [Header("SceneLoader 연결")]
    public SceneLoader sceneLoader;
    [Header("맵 이름 입력")]
    public string mapName = "";

    void OnMouseDown()
    {
        sceneLoader.LoadScene(mapName);
        Debug.Log("Scene 이동!");
    }
    
}
