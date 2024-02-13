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
    
    FadeInOut fadeInOut;


    void Start()
    {
        eventButtonUI = FindAnyObjectByType<EventButtonUI>();
        fadeInOut = GameObject.FindObjectOfType<FadeInOut>();
        dateCount = weatherUI.GetDateCount() + 1;
        string[] button3Arr = {
            "흙을 파본다", "식물을 옮긴다", "식물을 따뜻한 곳으로 옮긴다",
            "창문을 연다", "살충제를 뿌린다", "창문을 연다", "인스타에 올린다",
            "영양이 부족한가? 영양제를 주자", "가습기를 튼다", "가습기를 튼다",
            "환기를 시킨다", "가습기를 튼다", "창문을 연다", "무언가를 가져온다",
            "가습기를 튼다", "잎에 물을 묻힌다", "가습기를 튼다", "가습기를 튼다",
            "가습기를 튼다", "가습기를 튼다", "가습기를 튼다", "꽃을 꺾어 그녀에게 준다"
        };
        string textValue = button3Arr[dateCount];

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
        
       
        //버튼을 클릭하면 date++, 점수 더하기
        //waterCount 초기화
        button1Click.initWaterCount();
        //NeglectCount 초기화
        button2Click.initNeglectCount();
        //창닫기
        eventButtonUI.ClosePopupWindow();
        fadeInOut.StartCoroutine(fadeInOut.FadeAlpha());

        //페이드 인/아웃이 끝난 후(일차 끝) 메모 패널 활성화
        GameManager.memoPanel.SetActive(true);
    }
}
