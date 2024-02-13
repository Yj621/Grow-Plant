using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class WeatherUI : MonoBehaviour
{
    public TextMeshProUGUI weatherText;
    public int date = 0; // 이벤트를 하나씩 넘길 때마다 date++
    string originWeatherText;
    public DateUI dateUI;

    void Start()
    {
        originWeatherText = weatherText.text;  // "날씨 : "를 저장하는 변수
        string[] weatherArr = {
            "맑음", "맑음", "흐림", "비", "비", "맑음", "맑음", "맑음", "건조함",
            "맑음", "맑음", "흐림", "태풍", "맑음", "맑음", "맑음", "맑음", "맑음",
            "맑음", "맑음", "맑음", "맑음", "맑음", "흐림", "눈", "맑음", "맑음",
            "맑음", "맑음", "맑음", "맑음", "맑음", "맑음"
        };

        string textValue = weatherArr[date];

        if (weatherText != null)
        {
            // 기존 텍스트 초기화 후 새로운 텍스트 설정
            weatherText.text += textValue;
        }
        else
        {
            Debug.LogError("weatherArr가 할당되지 않았습니다.");
        }
    }

    public int GetDateCount()
    {
        return date;
    }

    public void SetDateCount()
    {
        date += 1;

        // 이벤트를 하나씩 넘길 때마다 텍스트 업데이트
        string[] textLines = new string[] {
            "맑음", "맑음", "흐림", "비", "비", "맑음", "맑음", "맑음", "건조함",
            "맑음", "맑음", "흐림", "태풍", "맑음", "맑음", "맑음", "맑음", "맑음",
            "맑음", "맑음", "맑음", "맑음", "맑음", "흐림", "눈", "맑음", "맑음",
            "맑음", "맑음", "맑음", "맑음", "맑음", "맑음"
        };

        // 경계를 초과하지 않도록 조건 추가
        if (date < textLines.Length)
        {
            string textValue = textLines[date];

            if (weatherText != null)
            {
                // 기존 텍스트 초기화 후 새로운 텍스트 추가
                weatherText.text = originWeatherText;
                weatherText.text += textValue;
            }
            else
            {
                Debug.LogError("weatherText가 할당되지 않았습니다.");
            }
        }
        else
        {
            Debug.LogWarning("더 이상 텍스트가 없습니다.");
        }
        dateUI.IncreaseDateCount();
    }
}
