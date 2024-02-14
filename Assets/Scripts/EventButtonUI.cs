using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventButtonUI : MonoBehaviour
{
    public GameObject popupWindow;
    public GameObject blockingPanel;
    public Transform eventCanvas; // EventCanvas

    private bool isPopupOpen = false;
    
    private GameObject popupInstance;

    void Start()
    {
        if (popupWindow != null)
            popupWindow.SetActive(false);
        if (blockingPanel != null)
            blockingPanel.SetActive(false);
    }

    public void OpenPopupWindow()
    {
        if (isPopupOpen)
        {
            return;
        }

        if (eventCanvas != null)
        {
            Vector3 centerScreenPosition = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);

            popupInstance = Instantiate(popupWindow, centerScreenPosition, Quaternion.identity, eventCanvas);
            popupInstance.SetActive(true);

            isPopupOpen = true;
        }
        else
        {
            Debug.LogError("Null eventCanvas");
        }
    }

    public void ClosePopupWindow()
    {
        if (!isPopupOpen)
        {
            return;
        }
        if (popupInstance != null)
        {
            popupInstance.SetActive(false);
        }

        isPopupOpen = false;
    }
}
