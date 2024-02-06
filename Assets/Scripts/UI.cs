using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static GameObject diePanel;
    void Start()
    {
        diePanel = GameObject.Find("DiePanel");
        diePanel.SetActive(false);
    }

    public void Retry()
    {
	    SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }


}
