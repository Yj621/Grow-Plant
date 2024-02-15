using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingPanel : MonoBehaviour
{
    public GameObject blockingPanel;
    public FadeInOut fadeInOut;
    private bool currentIsFading;

    void Start()
    {
        blockingPanel.SetActive(false);
    }

    void Update()
    {
        
        
    }
    public void OpenBlockingPanel()
    {   
        blockingPanel.SetActive(true);  
    }
    public void CloseBlockingpanel()
    {
        blockingPanel.SetActive(false);
    }
}
