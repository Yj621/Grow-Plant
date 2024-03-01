using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button3Click : MonoBehaviour
{
    public TextMeshProUGUI button3Text;
    public int dateCount = 0;
    public WeatherUI weatherUI;
    public Button1Click button1Click;
    public Button2Click button2Click;
    private EventButtonUI eventButtonUI;
    public ConditionUI conditionUI;
    public BlockingButton blockingBtn;

    FadeInOut fadeInOut;
    MemoPanel memoPanel;

    void Start()
    {
        eventButtonUI = FindAnyObjectByType<EventButtonUI>();
        fadeInOut = GameObject.FindObjectOfType<FadeInOut>();
        memoPanel = FindAnyObjectByType<MemoPanel>();
        dateCount = weatherUI.GetDateCount() + 1;

        string[] button3Arr = {
            "흙을 파본다", "식물을 옮긴다", "식물을 따뜻한 곳으로 옮긴다",
            "창문을 연다", "살충제를 뿌린다", "창문을 연다", "인스타에 올린다",
            "영양이 부족한가? 영양제를 주자", "가습기를 튼다", "가습기를 튼다",
            "환기를 시킨다", "가습기를 튼다", "창문을 연다", "무언가를 가져온다",
            "가습기를 튼다", "잎에 물을 묻힌다", "가습기를 튼다", "가습기를 튼다",
            "가습기를 튼다", "가습기를 튼다", "가습기를 튼다", "꽃을 꺾어 그녀에게 준다"
        };
        string textValue = button3Arr[dateCount - 1];

        if (button3Text != null)
        {
            button3Text.text = textValue;
        }
        else
        {
            Debug.LogError("button3Text가 할당되지 않았습니다.");
        }
    }

    public void Button3OnClick()
    {
        weatherUI.SetDateCount();

        //일차별 버튼2 점수
        int[] btn3ScoreArr = {-999,-999,3,-50,5,10,20,20,20,10,         //-999는 즉사, 999는 히든엔딩
            10,10,-999,10,10,0,10,10,10,10,10,999};                     //4일차 1번 버튼은 비가 들이쳐서 물을 많이 먹음 -50
        //점수 더하기
        conditionUI.GetCondPoint(btn3ScoreArr[dateCount - 1]);

        //waterCount 초기화
        button1Click.initWaterCount();

        //NeglectCount 초기화
        button2Click.initNeglectCount();

        //창닫기
        eventButtonUI.ClosePopupWindow();
        blockingBtn.CloseBlockingButton();
        fadeInOut.StartCoroutine(fadeInOut.FadeAlpha());

        //페이드 인/아웃이 끝난 후(일차 끝) 메모 패널 활성화
        memoPanel.memoPanel.SetActive(true);
    }
}
