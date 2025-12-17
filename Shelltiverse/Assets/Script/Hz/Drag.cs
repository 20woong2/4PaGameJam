// using UnityEngine;
// using TMPro;

// public class Drag : MonoBehaviour
// {

//     //Debug.Log("wow");
        

//     private Vector3 offset;
//     private float zDistance;

//     public Vector3 targetPosition = new Vector3(0f, 0f, 0f); // 정답 위치

//     public AudioSource audioSource; // 오디오 소스 컴포넌트 연결용
//     public AudioSource audioSource2; // 오디오 소스 컴포넌트 연결용
//     public AudioClip noise;    // 재생할 MP3 파일 연결용
//     public AudioClip morse;    // 재생할 MP3 파일 연결용

//     public TextMeshProUGUI hzText;
//     private float hertz;

//     private float timer = 0f;
//     private bool isClear = false;



//     void PlaySound(string sound) 
//     {
//         if (sound == "noise") 
//         {
//             if (noise != null && !audioSource.isPlaying) 
//             {
//                 audioSource.clip = noise;
//                 audioSource.Play();
//             }
//         }

//         if (sound == "morse") 
//         {
//             if (morse != null && !audioSource2.isPlaying) 
//             {
//                 audioSource2.clip = morse;
//                 audioSource2.Play();
//             }
//         }
        
//     }


//     // 볼륨 조절 함수
//     void Volume(AudioSource audio) 
//     {
//         float distance = Vector3.Distance(transform.position, targetPosition); // 정답 위치와 오브젝트 위치간 거리

//         float maxDistance = 5.0f;
//         float newVolume = (distance / maxDistance);  // 거리로 볼륨 조절
//         if (audio == audioSource2) newVolume = 1.0f - (distance / maxDistance);
        
//         // 볼륨 입력
//         audio.volume = Mathf.Clamp(newVolume, 0f, 1f);  // 볼륨 최소 0, 최대 1
//     }



//     // 마우스 좌표값 반환하는 함수
//     private Vector3 GetMouseWorldPos()
//     {
//         Vector3 mousePoint = Input.mousePosition;  //스크린 픽셀 좌표값
//         mousePoint.z = zDistance;

//         return Camera.main.ScreenToWorldPoint(mousePoint);  // 월드 좌표값으로 변환해서 리턴
//     }



//     // 마우스 클릭했을 때
//     void OnMouseDown()
//     {
//         // 카메라와 물체 사이의 거리(Z)를 반드시 구하기
//         zDistance = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

//         // 오프셋 계산
//         offset = gameObject.transform.position - GetMouseWorldPos();

//         //일단 클릭했을 때 소리 나오게 함
//         PlaySound("noise");
//         PlaySound("morse");
//     }



//     // 마우스 드래그 할 떄
//     void OnMouseDrag()
//     {
//         // 오브젝트 위치
//         Vector3 targetPos = GetMouseWorldPos() + offset;

//         // Y축 위치 제한 
//         float minY = -4.5f;
//         float maxY = 4.5f;
//         float clampedY = Mathf.Clamp(targetPos.y, minY, maxY);

//         // 최종 위치 적용 
//         transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);


//         // 볼륨 조절
//         Volume(audioSource);
//         Volume(audioSource2);
        
//         // 텍스트 지정
//         hertz = (transform.position.y + 5.0f)*28 + 23.0f;
//         hertz = Mathf.Clamp(hertz, 37f, 289f);
//         hzText.text = hertz + "Hz";
//     }





//     void Start()
//     {
//         hertz = (transform.position.y + 5.0f)*28 + 23.0f;
//         hzText.text = hertz + "Hz";
//     }



//     void Update()
//     {

//         float minY = targetPosition.y - 1.0f;
//         float maxY = targetPosition.y + 1.0f;


//         if (transform.position.y >= minY && transform.position.y <= maxY)
//         {
//             // 범위 안에 있을 때
//             timer += Time.deltaTime;

//             // 클리어
//             if (timer >= 2.5f && !isClear)
//             {
//                 isClear = true; 
//                 Debug.Log("clear");
//             }
//         }
//         else
//         {
//             // 범위 안에 없을 때
//             timer = 0f;
//             isClear = false; 
//         }
        
//     }

// }
