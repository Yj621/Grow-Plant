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
        // �� ���� ������Ű�� �޼��带 ���� '����'
        dateCount = weatherUI.GetDateCount();
        UpdateDayText();
    }

    void UpdateDayText()
    {
        dateCount = weatherUI.GetDateCount() + 1;
        // UI�� ���� �� ���� ǥ���ϴ� �޼���
        dayText.text = dateCount.ToString() + "DAY";
    }
}