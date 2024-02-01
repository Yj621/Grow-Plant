using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    private float perspectiveZoomSpeed = 0.008f;
    private float orthoZoomSpeed = 0.0001f;
    private float moveSpeed = 0.001f;
    private float rotateSpeed = 0.1f;
    public Transform otherObjectTransform;
    private Vector2[] previousTouchPositions = new Vector2[3];
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
                    if (hit.transform == otherObjectTransform)
                    {
                        isObjectSelected = true;
                    }
                    else
                    {
                        isObjectSelected = false;
                    }
                }
            }

            if (isObjectSelected)
            {
                // 오브젝트가 선택된 경우 오브젝트 회전
                switch (touch.phase)
                {
                    case TouchPhase.Moved:
                        Vector2 touchDelta = touch.deltaPosition;

                        if (touchDelta.x != 0 || touchDelta.y != 0)
                        {
                            float rotationY = touchDelta.x * rotateSpeed;
                            otherObjectTransform.Rotate(Vector3.up, rotationY, Space.World);
                        }
                        break;
                }
            }
            else
            {
                // 오브젝트가 선택되지 않은 경우 카메라 이동
                switch (touch.phase)
                {
                    case TouchPhase.Moved:
                        Vector2 touchDelta = touch.deltaPosition;

                        if (touchDelta.x != 0 || touchDelta.y != 0)
                        {
                            transform.Translate(-touchDelta.x * moveSpeed, -touchDelta.y * moveSpeed, 0);
                        }
                        break;
                }
            }
        }
        else if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
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
