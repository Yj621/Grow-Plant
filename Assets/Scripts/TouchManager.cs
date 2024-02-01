using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{    
    private float perspectiveZoomSpeed = 0.008f;  // 줌인, 줌아웃할 때 속도(perspective 모드 용)      
    private float orthoZoomSpeed = 0.0001f;      // 줌인, 줌아웃할 때 속도(OrthoGraphic 모드 용)  
    private float moveSpeed = 0.001f;             // 카메라 이동 속도
    private float rotateSpeed = 1f;               // 오브젝트 회전 속도

    void Update()
    {
        if (Input.touchCount == 2) // 손가락 2개가 눌렸을 때
        {
            Touch touchZero = Input.GetTouch(0); // 첫 번째 손가락 터치를 저장
            Touch touchOne = Input.GetTouch(1); // 두 번째 손가락 터치를 저장

            // 터치에 대한 이전 위치 값을 각각 저장함
            // 처음 터치한 위치(touchZero.position)에서 이전 프레임에서의 터치 위치와 이번 프레임에서 터치 위치의 차이를 뺌
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition; // deltaPosition은 이동 방향 추적할 때 사용
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // 각 프레임에서 터치 사이의 벡터 거리 구함
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude; // magnitude는 두 점 간의 거리 비교(벡터)
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // 거리 차이 구함(거리가 이전보다 크면(마이너스가 나오면) 손가락을 벌린 상태_줌인 상태)
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // 만약 카메라가 OrthoGraphic 모드 라면
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
        else if (Input.touchCount == 1) // 싱글 터치로 카메라 이동 및 오브젝트 회전
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    // 터치 델타를 기반으로 이동 벡터 계산
                    Vector2 touchDelta = touch.deltaPosition;

                    if (touchDelta.x != 0 || touchDelta.y != 0)
                    {
                        // 터치 델타 및 이동 속도를 곱하여 카메라 이동
                        transform.Translate(-touchDelta.x * moveSpeed, -touchDelta.y * moveSpeed, 0);
                    }

                    // 오브젝트 회전
                    float rotationX = touchDelta.y * rotateSpeed;
                    float rotationY = -touchDelta.x * rotateSpeed;

                    transform.Rotate(rotationX, rotationY, 0, Space.World);
                    break;
            }
        }
    }
}
