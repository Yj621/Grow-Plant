using System.Collections;
using UnityEngine;
using UnityEngine.UI; // UI ���ӽ����̽� �߰�
using System.IO;
using TMPro;

public class WeatherUI : MonoBehaviour
{
    public TextMeshProUGUI weatherText;
    private int date = 0; // �̺�Ʈ�� �ϳ��� �ѱ� ������ date++

    void Start()
    {       
        string filePath = "Assets/Scripts/weather.txt";
        string[] textLines = System.IO.File.ReadAllLines(filePath);

        string textValue = textLines[date];

        if (weatherText != null)
        {
            weatherText.text += textValue;
        }
        else
        {
            Debug.LogError("weatherText�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }
    public int GetDateCount()
    {
        return date;
    }
}
