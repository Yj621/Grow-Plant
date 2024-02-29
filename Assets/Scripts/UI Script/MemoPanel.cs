using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MemoPanel : MonoBehaviour
{
    public GameObject memoPanel;
    public TextMeshProUGUI dateText;
    public TextMeshProUGUI weatherText;
    public TextMeshProUGUI contenetText;

    ConditionUI conditionUI;
    WeatherUI weatherUI;
    void Start()
    {
        memoPanel.SetActive(false);
        weatherUI = FindAnyObjectByType<WeatherUI>();
        conditionUI = FindAnyObjectByType<ConditionUI>();
    }

    void Update()
    {
        UpdateDayText();
    }

    void UpdateDayText()
    {
        dateText.text = weatherUI.date+1 + "일차";
        weatherText.text = weatherUI.weatherText.text;
        //내용에 들어갈 텍스트
        // 버튼1 클릭으로 얻은 점수 확인
        //int btn1Score = conditionUI.GetCondPoint(btn1ScoreArr[dateCount - 1]);

        // 점수가 양수인 경우
        // if (btn1Score >= 0)
        // {
        //     contenetText.text = "식물 상태가 좋습니다";
        // }
        // // 점수가 음수인 경우
        // else
        // {
        //     contenetText.text = "식물 상태가 나쁩니다";
        // }
    }
}
