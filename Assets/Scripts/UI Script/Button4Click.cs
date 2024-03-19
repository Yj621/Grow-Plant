using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button4Click : MonoBehaviour
{
    public TextMeshProUGUI button4Text;
    public int dateCount = 0;
    public WeatherUI weatherUI;
    public Button1Click button1Click;
    public Button2Click button2Click;
    private EventButtonUI eventButtonUI;
    public Button button4;
    public ConditionUI conditionUI;
    public BlockingButton blockingBtn;

    DiePanel diePanel;
    FadeInOut fadeInOut;
    MemoPanel memoPanel;

    string[] button4MemoArr =
        {
            "식물이 응원을 받아 무럭무럭 자랐다."
        };

    void Start()
    {
        eventButtonUI = FindAnyObjectByType<EventButtonUI>();
        fadeInOut = GameObject.FindObjectOfType<FadeInOut>();
        memoPanel = FindAnyObjectByType<MemoPanel>();
        diePanel = FindAnyObjectByType<DiePanel>();
        dateCount = weatherUI.GetDateCount() + 1;

        string[] button4Arr = {
            "지렁이를 심는다","일광욕을 즐긴다", "응원한다", "제습제를 설치한다",
            "직접 죽인다","피크닉을 간다","SNS에 업로드한다","칭찬이 부족했나? 칭찬해주자",
            "뿌리도 잘 자라나 확인한다","죽인다","SNS에 업로드한다", "손으로 바로 세운다",
            "식물을 옮긴다", "SNS에 업로드한다", "선글라스를 씌운다", "강아지에게 간식을 준다",
            "응원한다", "SNS에 업로드한다", "뿌리를 자른다", "창문을 열다", "SNS에 업로드한다",
            "벌을 잡는다", "눈을 구경해 볼까?", "눈사람을 만든다", "선물을 요구한다", "떨어진 꽃잎을 줍는다",
            "SNS에 업로드한다", "SNS에 업로드한다"
        };

        string textValue = button4Arr[dateCount - 1];

        if (button4Text != null)
        {
            button4Text.text = textValue;
        }
        else
        {
            Debug.LogError("button4Text가 할당되지 않았습니다.");
        }
    }

    public void Button4OnClick()
    {
        StartCoroutine(Button4ClickSequence());
        
        //{}안에 있는 일차에 죽는 이벤트 발생
        int[] specialDateCounts = { 2, 8, 9, 12, 14, 20, 21, 23, 24, 25, 26,  };
        
        if (Array.IndexOf(specialDateCounts, dateCount) != -1)
        {
            diePanel.Btn4SpecialDied(dateCount);
        }
    }

    private IEnumerator Button4ClickSequence()
    {
        yield return StartCoroutine(fadeInOut.FadeAlpha());
        //창닫기
        eventButtonUI.ClosePopupWindow();
        weatherUI.SetDateCount();

        //일차별 버튼2 점수
        int[] btn4ScoreArr = {-10,-999,20,10,-20,-10,-5,-999,-999,-10,         //-999는 즉사, 999는 히든엔딩
            -5,-999,10,-5,-15,-5,0,0,-5,-999,
            -999,-5,-999,-999,-999,-999,0,-5,-5,0};    //30일차 4번 버튼에 들어갈 이벤트 필요
        //점수 더하기
        conditionUI.GetCondPoint(btn4ScoreArr[dateCount - 1]);

        // +점수인지 -점수인지에 따라 메모패널 텍스트 변경(GetCondPoint보다 아래에 있어야 제대로 표시 가능)
        memoPanel.UpdateDayText();// +점수인지 -점수인지에 따라 메모패널 텍스트 변경(GetCondPoint보다 아래에 있어야 제대로 표시 가능)
        if (dateCount == 3)
        {
            memoPanel.contentText.text = button4MemoArr[0];
        }       
        if(diePanel.isDie == false)
        {
            //메모패널 열기 
            memoPanel.MemoPanelOn();
        }
        //waterCount 초기화
        button1Click.initWaterCount();

        //NeglectCount 초기화
        button2Click.initNeglectCount();
        
        //blockingBtn.CloseBlockingButton();
    }
}
