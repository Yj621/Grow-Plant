using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    //줌 속도 변수
    private float perspectiveZoomSpeed = 0.008f;
    private float orthoZoomSpeed = 0.0001f;

    //이동 속도
    private float moveSpeed = 0.001f;
    //회전 속도
    private float rotateSpeed = 0.1f;

    //회전할 오브젝트
    public Transform otherObjectTransform;

    private bool isObjectSelected = false; // 오브젝트가 선택되었는지 여부

    void Update()
    {
        // 오브젝트 클릭 여부에 따라 처리
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // 터치가 시작될 때 클릭된 오브젝트를 확인
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out hit))
                {
                    //레이가 객체와 충돌했을때
                    if (hit.transform == otherObjectTransform)
                    {
                        isObjectSelected = true;
                    }
                    //충돌 X
                    else
                    {
                        isObjectSelected = false;
                    }
                }
            }

            //충돌이 나면
            if (isObjectSelected)
            {
                //터치 정보에 따라
                switch (touch.phase)
                {
                    //터치가 움직이면
                    case TouchPhase.Moved:
                        //터치의 이동량을 저장
                        Vector2 touchDelta = touch.deltaPosition;

                        //x또는 y가 하나라도 0이 아니면 회전(움직이면 회전)
                        if (touchDelta.x != 0 || touchDelta.y != 0)
                        {
                            //회전 수행
                            float rotationY = touchDelta.x * rotateSpeed;
                            otherObjectTransform.Rotate(Vector3.up, rotationY, Space.World);
                        }
                        break;
                }
            }

            //충돌X
            else
            {
                switch (touch.phase)
                {
                    //터치가 이동하면
                    case TouchPhase.Moved:
                        Vector2 touchDelta = touch.deltaPosition;

                        //터치가 이동했는지 확인
                        if (touchDelta.x != 0 || touchDelta.y != 0)
                        {
                            //카메라 터치의 이동량에 비례해 x와 y방향으로 이동하고, 이동량은 moveSpeed에 비례한다.
                            //-를 붙인 이유는 유니티 좌표계에서 카메라가 움직이는 방향을 반대로 하기 위해서임
                            transform.Translate(-touchDelta.x * moveSpeed, -touchDelta.y * moveSpeed, 0);
                        }
                        break;
                }
            }
        }

        //접촉되어 있는 손가락 개수가 2일때(두 손가락을 터치했을때)
        else if (Input.touchCount == 2)
        {
            //첫번째 터치 정보 저장
            Touch touchZero = Input.GetTouch(0);
            //두번째 터치 정보 저장
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

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


