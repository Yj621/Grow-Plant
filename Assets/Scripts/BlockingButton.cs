using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingButton : MonoBehaviour
{
    public GameObject BlockingBtn;
 
    void Start()
    {
        BlockingBtn.SetActive(false);
    }
    public void OpenBlockingButton()
    {
        BlockingBtn.SetActive(true);
    }

    public void CloseBlockingButton()
    {
        BlockingBtn.SetActive(false);
    }
}
