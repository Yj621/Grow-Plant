using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DateUI : MonoBehaviour
{
    public TextMeshProUGUI dayText;
    public int dateCount = 0;
    public WeatherUI weatherUI;

    DiePanel diePanel;

    void Start()
    {
        UpdateDayText();
        diePanel = FindAnyObjectByType<DiePanel>();
    }

    void Update()
    {
        //이렇게 하는게 맞는지..
        if(dateCount == 8)
        {
            int randomNumber = Random.Range(0, 101);
            // 10%의 확률로 강아지 이벤트
            if (randomNumber <= 10)
            {
                diePanel.SpecialDie(dateCount);
            }
        }
    }

    public void IncreaseDateCount()
    {
        // 일 수를 증가시키는 메서드
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