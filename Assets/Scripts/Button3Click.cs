using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button3Click : MonoBehaviour
{
    public TextMeshProUGUI button3Text;
    private int dateCount = 0;
    public WeatherUI weatherUI;
    public Button1Click button1Click;
    private EventButtonUI eventButtonUI;

    void Start()
    {
        eventButtonUI = FindAnyObjectByType<EventButtonUI>();

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

    void Update()
    {

    }

    public void Button3OnClick()
    {
        weatherUI.SetDateCount();
        
       
        //버튼을 클릭하면 date++, 점수 더하기
        //waterCount 초기화
        button1Click.initWaterCount();

        //창닫기
        eventButtonUI.ClosePopupWindow();
    }
}
