using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button2Click : MonoBehaviour
{
    public TextMeshProUGUI button2Text;
    public int dateCount = 0;
    private static int NeglectCount;
    public WeatherUI weatherUI;
    public Button1Click button1Click;
    private EventButtonUI eventButtonUI;
    public ConditionUI conditionUI;
    public BlockingButton blockingBtn;

    FadeInOut fadeInOut;

    void Start()
    {
        eventButtonUI = FindAnyObjectByType<EventButtonUI>();
        fadeInOut = GameObject.FindObjectOfType<FadeInOut>();
        dateCount = weatherUI.GetDateCount() + 1;
        string[] button2Arr = {
            "냅둔다",
            "가습기를 튼다",
            "습도가 높은 것 같다. 확인해보자",
            "잎을 만져본다"
        };
        string textValue;
        if (dateCount == 7)  //dateCount는 일차를 나타냄.
                             //7일차, 8일차, 16일차에는 txt파일의 각각 2번째 줄, 3번째 줄, 4번째 줄의 내용을 넣음.
        {
            textValue = button2Arr[1];
        }
        else if (dateCount == 8)
        {
            textValue = button2Arr[2];
        }
        else if (dateCount == 16)
        {
            textValue = button2Arr[3];
        }
        else
        {
            textValue = button2Arr[0];
        }

        if (button2Text != null)
        {
            button2Text.text = textValue;
        }
        else
        {
            Debug.LogError("button2Text가 할당되지 않았습니다.");
        }
    }

    public void Button2OnClick()
    {
        weatherUI.SetDateCount();
        
        NeglectCount++;
        Debug.Log("NeglectCount : "+NeglectCount);
        if (NeglectCount >= 3)
        {
            Debug.Log("Die");
            //GameManager.diePanel.SetActive(true);
        }

        //일차별 버튼2 점수
        int[] btn2ScoreArr = {0,0,0,10,-999,0,10,-999,0,0,        //-999는 즉사, 999는 히든엔딩
            0,0,0,-999,0,10,0,0,0,0,0,0};                         //4일차 1번 버튼은 습한데 물을 많이 먹음 -50
        //점수 더하기
        conditionUI.GetCondPoint(btn2ScoreArr[dateCount - 1]);

        //waterCount 초기화
        button1Click.initWaterCount();

        //창닫기
        eventButtonUI.ClosePopupWindow();
        blockingBtn.CloseBlockingButton();
        fadeInOut.StartCoroutine(fadeInOut.FadeAlpha());
        
        //페이드 인/아웃이 끝난 후(일차 끝) 메모 패널 활성화
        //GameManager.memoPanel.SetActive(true);
    }
    public int initNeglectCount()
    {
        NeglectCount = 0;
        return NeglectCount; //다른 버튼이 눌릴 시 NeglectCount 0으로 초기화
    }
}
