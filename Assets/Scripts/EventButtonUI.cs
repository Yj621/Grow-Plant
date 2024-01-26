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
        // ȭ���� �߾� ��ġ ���
        Vector3 centerScreenPosition = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);

        // ȭ�� �߾ӿ� �˾� ����
        GameObject popupInstance = Instantiate(popupWindow, centerScreenPosition, Quaternion.identity);
        popupWindow.SetActive(true);
    }
}
