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
        // 예를 들어, 사용자가 어떤 이벤트를 트리거할 때마다 일 수를 증가시킬 수 있습니다.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseDayCount();
        }
    }

    void IncreaseDayCount()
    {
        // 일 수를 증가시키는 메서드를 만들 '예정'
        UpdateDayText();
    }

    void UpdateDayText()
    {
        dateCount = weatherUI.GetDateCount() + 1;
        // UI에 현재 일 수를 표시하는 메서드
        dayText.text = dateCount.ToString() + "DAY";
    }
}