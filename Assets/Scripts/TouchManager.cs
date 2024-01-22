using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{    public float perspectiveZoomSpeed = 0.5f;  //줌인,줌아웃할때 속도(perspective모드 용)      
    public float orthoZoomSpeed = 0.5f;      //줌인,줌아웃할때 속도(OrthoGraphic모드 용)  


    void Update()
    {
        if (Input.touchCount == 2) //손가락 2개가 눌렸을 때
        {
            Touch touchZero = Input.GetTouch(0); //첫번째 손가락 터치를 저장
            Touch touchOne = Input.GetTouch(1); //두번째 손가락 터치를 저장

            //터치에 대한 이전 위치값을 각각 저장함
            //처음 터치한 위치(touchZero.position)에서 이전 프레임에서의 터치 위치와 이번 프로임에서 터치 위치의 차이를 뺌
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition; //deltaPosition는 이동방향 추적할 때 사용
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
			
            // 각 프레임에서 터치 사이의 벡터 거리 구함
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude; //magnitude는 두 점간의 거리 비교(벡터)
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // 거리 차이 구함(거리가 이전보다 크면(마이너스가 나오면)손가락을 벌린 상태_줌인 상태)
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // 만약 카메라가 OrthoGraphic모드 라면
            if (GetComponent<Camera>().orthographic)
            {
                GetComponent<Camera>().orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;
                GetComponent<Camera>().orthographicSize = Mathf.Max(GetComponent<Camera>().orthographicSize, 0.1f);
            }
            else
            {
                GetComponent<Camera>().fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;
                GetComponent<Camera>().fieldOfView = Mathf.Clamp(GetComponent<Camera>().fieldOfView, 0.1f, 179.9f);
            }
        }
    }
}
//     private Vector2 nowPos, prePos;
//     private Vector2 movePosDiff;

//     // 터치 드래그 값을 가져오는 메서드
//     private Vector2 getTouchDragValue()
//     {
//         movePosDiff = Vector3.zero;

//         if (Input.touchCount == 1)
//         {
//             Touch touch = Input.GetTouch(0);
//             if (touch.phase == TouchPhase.Began)
//             {
//                 prePos = touch.position - touch.deltaPosition;
//             }
//             else if (touch.phase == TouchPhase.Moved)
//             {
//                 nowPos = touch.position - touch.deltaPosition;
//                 movePosDiff = (Vector2)(prePos - nowPos) * Time.deltaTime;
//                 prePos = touch.position - touch.deltaPosition;
//             }
//         }
//         return movePosDiff;
//     }

//     float m_fSpeed = 0.1f;       // 변경 속도를 설정합니다
//     float m_fFieldOfView = 60f;  // 카메라의 FieldOfView의 기본값을 60으로 정합니다.

//     void Update()
//     {
//         CheckTouch();
//     }

//     void CheckTouch()
//     {
//         if (Input.touchCount == 2)
//         {
//             Vector2 vecPreTouchPos0 = Input.touches[0].position - Input.touches[0].deltaPosition;
//             Vector2 vecPreTouchPos1 = Input.touches[1].position - Input.touches[1].deltaPosition;

//             // 이전 두 터치의 차이
//             float fPreDis = (vecPreTouchPos0 - vecPreTouchPos1).magnitude;
//             // 현재 두 터치의 차이
//             float fToucDis = (Input.touches[0].position - Input.touches[1].position).magnitude;

//             // 이전 두 터치의 거리와 지금 두 터치의 거리의 차이
//             float fDis = fPreDis - fToucDis;

//             // 이전 두 터치의 거리와 지금 두 터치의 거리의 차이를 FleldOfView를 차감합니다.
//             m_fFieldOfView += (fDis * m_fSpeed);

//             // 최대는 100, 최소는 20으로 더이상 증가 혹은 감소가 되지 않도록 합니다.
//             m_fFieldOfView = Mathf.Clamp(m_fFieldOfView, 20.0f, 100.0f);

//             Camera.main.fieldOfView = m_fFieldOfView;
//         }
//     }
// }
