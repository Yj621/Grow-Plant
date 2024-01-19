using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DateUI : MonoBehaviour
{
    public TextMeshProUGUI dayText;
    private int dayCount = 0;
    public WeatherUI weatherUI;

    void Start()
    {
        UpdateDayText();
    }

    void Update()
    {
        // ���� ���, ����ڰ� � �̺�Ʈ�� Ʈ������ ������ �� ���� ������ų �� �ֽ��ϴ�.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseDayCount();
        }
    }

    void IncreaseDayCount()
    {
        // �� ���� ������Ű�� �޼��带 ���� '����'
        UpdateDayText();
    }

    void UpdateDayText()
    {
        dayCount = weatherUI.GetDateCount() + 1;
        // UI�� ���� �� ���� ǥ���ϴ� �޼���
        dayText.text = dayCount.ToString() + "����";
    }
}