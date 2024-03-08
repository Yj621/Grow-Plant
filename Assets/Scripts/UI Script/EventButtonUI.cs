using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventButtonUI : MonoBehaviour
{
    public GameObject popupWindow;
    public GameObject blockingButton;
    public Transform eventCanvas; // EventCanvas

    private bool isPopupOpen = false;
    
    private GameObject popupInstance;

    SoundManager soundManager;

    void Start()
    {
        if (popupWindow != null)
            popupWindow.SetActive(false);
        if (blockingButton != null)
            blockingButton.SetActive(false);
        soundManager = FindAnyObjectByType<SoundManager>();
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
            Destroy(popupInstance);
        }
        isPopupOpen = false;
        soundManager.Sound(2);
    }

}
