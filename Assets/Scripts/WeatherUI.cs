using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class WeatherUI : MonoBehaviour
{
    public TextMeshProUGUI weatherText;
    private int date = 0; // �̺�Ʈ�� �ϳ��� �ѱ� ������ date++
    string originWeatherText;
    public DateUI dateUI;

    void Start()
    {
        originWeatherText = weatherText.text;  // "���� : "�� �����ϴ� ����
        string[] weatherArr = {
            "����", "����", "�帲", "��", "��", "����", "����", "����", "������",
            "����", "����", "�帲", "��ǳ", "����", "����", "����", "����", "����",
            "����", "����", "����", "����", "����", "�帲", "��", "����", "����",
            "����", "����", "����", "����", "����", "����"
        };

        string textValue = weatherArr[date];

        if (weatherText != null)
        {
            // ���� �ؽ�Ʈ �ʱ�ȭ �� ���ο� �ؽ�Ʈ ����
            weatherText.text += textValue;
        }
        else
        {
            Debug.LogError("weatherArr�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }

    public int GetDateCount()
    {
        return date;
    }

    public void SetDateCount()
    {
        date += 1;

        // �̺�Ʈ�� �ϳ��� �ѱ� ������ �ؽ�Ʈ ������Ʈ
        string[] textLines = new string[] {
            "����", "����", "�帲", "��", "��", "����", "����", "����", "������",
            "����", "����", "�帲", "��ǳ", "����", "����", "����", "����", "����",
            "����", "����", "����", "����", "����", "�帲", "��", "����", "����",
            "����", "����", "����", "����", "����", "����"
        };

        // ��踦 �ʰ����� �ʵ��� ���� �߰�
        if (date < textLines.Length)
        {
            string textValue = textLines[date];

            if (weatherText != null)
            {
                // ���� �ؽ�Ʈ �ʱ�ȭ �� ���ο� �ؽ�Ʈ �߰�
                weatherText.text = originWeatherText;
                weatherText.text += textValue;
            }
            else
            {
                Debug.LogError("weatherText�� �Ҵ���� �ʾҽ��ϴ�.");
            }
        }
        else
        {
            Debug.LogWarning("�� �̻� �ؽ�Ʈ�� �����ϴ�.");
        }
        dateUI.IncreaseDateCount();
    }
}
