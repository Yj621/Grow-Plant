using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventButtonUI : MonoBehaviour
{
    public GameObject popupWindow;
    public GameObject blockingPanel;

    void Start()
    {
        if (popupWindow != null)
            popupWindow.SetActive(false);
        if (blockingPanel != null)
            blockingPanel.SetActive(false);
    }

    public void OpenPopupWindow()
    {
        // 화면의 중앙 위치 계산
        Vector3 centerScreenPosition = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);

        // 화면 중앙에 팝업 생성
        GameObject popupInstance = Instantiate(popupWindow, centerScreenPosition, Quaternion.identity);
        popupWindow.SetActive(true);
    }
}
