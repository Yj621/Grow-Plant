using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventTextUI : MonoBehaviour
{
    public TextMeshProUGUI eventText;
    public int dateCount = 0;
    public WeatherUI weatherUI;

    void Start()
    {
        OpenEvent();
    }

    void OpenEvent()
    {
        string[] eventTextArr = {
            "흙이 말라있다", "해가 쨍쨍하다", "싹이 나오기 시작했다",
            "비가 내려 습하다", "습해서 벌레가 많이 생겼다", "날씨가 화창하다",
            "싹이 텄다", "식물이 시들었다. 이유를 찾자", "식물이 잘 자라고 있다",
            "이벤트 없음", "태풍이 일어났다", "줄기가 점점 길어진다",
            "이벤트 없음", "잎이 자랐다", "이벤트 없음",
            "이벤트 없음", "봉오리가 맺혔다", "이벤트 없음",
            "이벤트 없음", "꽃이 폈다"
            };
        /*, "이벤트 없음",
        "눈이 내린다", "이벤트 없음", "이벤트 없음",  //22일 이후 일정(꽃이 피면 끝나는 건가?)
        "꽃이 졌다", "이벤트 없음", "이벤트 없음"
        */

        dateCount = weatherUI.GetDateCount();
        string textValue = eventTextArr[dateCount];

        eventText.text = textValue;

    }
}
