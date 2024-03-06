using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MemoPanel : MonoBehaviour
{
    public GameObject memoPanel;
    public TextMeshProUGUI dateText;
    public TextMeshProUGUI weatherText;
    public TextMeshProUGUI contentText;

    ConditionUI conditionUI;
    WeatherUI weatherUI;
    void Start()
    {
        memoPanel.SetActive(false);
        weatherUI = FindAnyObjectByType<WeatherUI>();
        conditionUI = FindAnyObjectByType<ConditionUI>();
    }

    void Update()
    {
        
    }

    public void UpdateDayText()
    {
        dateText.text = weatherUI.date + 1 + "일차";
        weatherText.text = weatherUI.weatherText.text;
        //내용에 들어갈 텍스트
        if(conditionUI.isGood)
        {
            contentText.text = "식물이 호전되었습니다.";
        }
        else if(conditionUI.isSoso)
        {
            contentText.text = "식물이 양호합니다.";
        }
        else if(conditionUI.isBad)
        {
            contentText.text = "식물이 악화되었습니다.";
        }

        conditionUI.isGood = false;
        conditionUI.isSoso = false;
        conditionUI.isBad = false;
}
}
