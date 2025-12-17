using UnityEngine;
using UnityEngine.InputSystem;
public class ObjectHover : MonoBehaviour
{
    [SerializeField] private float hoverScale = 1.2f;
    [SerializeField] private float smoothSpeed = 10;
    
    private Vector3 originalScale;
    private Camera cam;
    
    void Start()
    {
        originalScale = transform.localScale;
        cam = Camera.main;
    }
    
    void Update()
    {
        // Input System으로 마우스 위치 가져오기
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector2 worldPos = cam.ScreenToWorldPoint(mousePos);
        
        // 2D Raycast로 호버 감지
        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
        bool isHover = hit.collider != null && hit.collider.gameObject == gameObject;
        
        // 호버 애니메이션
        Vector3 targetScale = isHover ? originalScale * hoverScale : originalScale;
        
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, smoothSpeed * Time.deltaTime);
        
    }
}
