using UnityEngine;
using UnityEngine.InputSystem;
public class ObjectHover : MonoBehaviour
{
    [SerializeField] private float hoverScale = 1.1f;
    [SerializeField] private float hoverHeight = 0.2f;
    [SerializeField] private float smoothSpeed = 5f;
    
    private Vector3 originalScale;
    private Vector3 originalPos;
    private Camera cam;
    
    void Start()
    {
        originalScale = transform.localScale;
        originalPos = transform.position;
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
        Vector3 targetPos = isHover ? originalPos + Vector3.up * hoverHeight : originalPos;
        
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, smoothSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);
    }
}
