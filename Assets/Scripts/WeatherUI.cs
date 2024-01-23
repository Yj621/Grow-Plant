using System.Collections;
using UnityEngine;
using UnityEngine.UI; // UI 네임스페이스 추가
using System.IO;
using TMPro;

public class WeatherUI : MonoBehaviour
{
    public TextMeshProUGUI weatherText;
    private int date = 0; // 이벤트를 하나씩 넘길 때마다 date++

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
            Debug.LogError("weatherText가 할당되지 않았습니다.");
        }
    }
    public int GetDateCount()
    {
        return date;
    }
}
