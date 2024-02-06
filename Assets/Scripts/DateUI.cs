using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DateUI : MonoBehaviour
{
    public TextMeshProUGUI dayText;
    private int dateCount = 0;
    public WeatherUI weatherUI;

    void Start()
    {
        UpdateDayText();
    }

    void Update()
    {
        
    }

    public void IncreaseDateCount()
    {
        // 일 수를 증가시키는 메서드를 만들 '예정'
        dateCount = weatherUI.GetDateCount();
        UpdateDayText();
    }

    void UpdateDayText()
    {
        dateCount = weatherUI.GetDateCount() + 1;
        // UI에 현재 일 수를 표시하는 메서드
        dayText.text = dateCount.ToString() + "DAY";
    }
}