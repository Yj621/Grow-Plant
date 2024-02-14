/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameObject diePanel;
    public static GameObject memoPanel;

    public ConditionUI conditionUI;
    public DateUI dateUI;
    public EventTextUI eventTextUI;
    public EventButtonUI eventButtonUI;
    public FadeInOut fadeInOut;
    public TouchManager touchManager;
    public WeatherUI weatherUI;
    public Button1Click button1Click;
    public Button2Click button2Click;
    public Button3Click button3Click;
    public Button4Click button4Click;
    
    void Start()
    {
        GameLoad();
        diePanel = GameObject.Find("Die_PopUp");
        memoPanel = GameObject.Find("Memo_PopUp");
        diePanel.SetActive(false);
        memoPanel.SetActive(false);
    }

    public void Retry()
    {
	    SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void GameSave()
    {
        PlayerPrefs.SetInt("ConditionPoint", conditionUI.conditionPoint);
        PlayerPrefs.SetInt("Button1Click", button1Click.dateCount);
        PlayerPrefs.SetInt("Button2Click", button2Click.dateCount);
        PlayerPrefs.SetInt("Button3Click", button3Click.dateCount);
        PlayerPrefs.SetInt("Button4Click", button4Click.dateCount);
        PlayerPrefs.SetInt("EventTextUI", eventTextUI.dateCount);  
        PlayerPrefs.SetInt("DateUI", dateUI.dateCount);  
        PlayerPrefs.SetInt("WeatherUI", weatherUI.date);  
        PlayerPrefs.Save();
    }
    public void GameLoad()
    { 
        int conditionPoint = PlayerPrefs.GetInt("ConditionPoint");
        int dateCount1 = PlayerPrefs.GetInt("Button1Click");
        int dateCount2 = PlayerPrefs.GetInt("Button2Click");
        int dateCount3 = PlayerPrefs.GetInt("Button3Click");
        int dateCount4 = PlayerPrefs.GetInt("Button4Click");
        int dateCount5 = PlayerPrefs.GetInt("EventTextUI");
        int dateCount6 = PlayerPrefs.GetInt("DateUI");
        int date = PlayerPrefs.GetInt("WeatherUI");

        conditionUI.conditionPoint = conditionPoint;
        button1Click.dateCount = dateCount1;
        button2Click.dateCount = dateCount2;
        button3Click.dateCount = dateCount3;
        button4Click.dateCount = dateCount4;
        eventTextUI.dateCount = dateCount5;
        dateUI.dateCount = dateCount6;
        weatherUI.date = date;
    }
}
*/