﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button1Click : MonoBehaviour
{
    public TextMeshProUGUI button1Text;
    public int dateCount = 0;
    public WeatherUI weatherUI;
    private EventButtonUI eventButtonUI;
    public Button2Click button2Click;
    public ConditionUI conditionUI;
    public BlockingButton blockingBtn;

    public static int waterCount;

    FadeInOut fadeInOut;
    MemoPanel memoPanel;
    GameManager gameManager;
    DiePanel diePanel;

    void Start()
    {
        memoPanel = FindAnyObjectByType<MemoPanel>();
        eventButtonUI = FindAnyObjectByType<EventButtonUI>();
        fadeInOut = GameObject.FindObjectOfType<FadeInOut>();
        diePanel = FindAnyObjectByType<DiePanel>();
        dateCount = weatherUI.GetDateCount() + 1;
        gameManager = FindObjectOfType<GameManager>();
        string[] button1Arr = {
            "물을 준다",
            "냉/난방기 때문인 것 같다. 끄자",
            "식물을 옮긴다"
        };
        string textValue;
        if (dateCount == 8)  //dateCount는 일차를 나타냄. 8일차, 16일차에는 txt파일의 각각 2번째 줄과 3번째 줄의 내용을 넣음.
        {
            textValue = button1Arr[1];
        }
        else if (dateCount == 16)
        {
            textValue = button1Arr[2];
        }
        else
        {
            textValue = button1Arr[0];
        }

        if (button1Text != null)
        {
            button1Text.text = textValue;
        }
        else
        {
            Debug.LogError("button1Text가 할당되지 않았습니다.");
        }
    }

    void Update()
    {

    }

    public void Button1OnClick()
    {
        StartCoroutine(Button1ClickSequence()); 
        if (dateCount == 8) //이유찾기
        {
            diePanel.Btn1SpecialDied(dateCount);
        }
        else if (dateCount == 13) //줄기가 길어짐
        {
            diePanel.Btn1SpecialDied(dateCount);
        }
    }
    
    private IEnumerator Button1ClickSequence()
    {
        yield return StartCoroutine(fadeInOut.FadeAlpha());
        //창닫기
        eventButtonUI.ClosePopupWindow();
        memoPanel.memoPanel.SetActive(true);
        
        weatherUI.SetDateCount();
        waterCount++;

        Debug.Log("waterCount : "+waterCount);
        if (waterCount >= 5)
        {
            diePanel.PanelOn();
            diePanel.diedText.text = "물을 너무 많이 주어서 식물이 죽었습니다.";
        }

        //일차별 버튼1 점수
        int[] btn1ScoreArr = {5,5,5,-50,5,5,10,0,5,10,      //-999는 즉사
            10,10,5,-999,10,10,10,10,10,10,10,5};           //4일차 1번 버튼은 습한데 물을 많이 줘서 비실해짐 -50
        //점수 더하기
        conditionUI.GetCondPoint(btn1ScoreArr[dateCount - 1]);

        //NeglectCount 초기화
        button2Click.initNeglectCount();

        blockingBtn.CloseBlockingButton();
    }

    public int initWaterCount()
    {
        waterCount = 0;
        return waterCount; //다른 버튼이 눌릴 시 waterCount를 0으로 초기화
    }

}