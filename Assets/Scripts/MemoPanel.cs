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
    public TextMeshProUGUI contenetText;

    WeatherUI weatherUI;
    void Start()
    {
        memoPanel.SetActive(false);
        weatherUI = FindAnyObjectByType<WeatherUI>();
    }

    void Update()
    {
        UpdateDayText();
    }

    void UpdateDayText()
    {
        dateText.text = weatherUI.date+1 + "일차";
        weatherText.text = weatherUI.weatherText.text;
        //내용에 들어갈 텍스트
        //contenetText.text = 
    }
}
