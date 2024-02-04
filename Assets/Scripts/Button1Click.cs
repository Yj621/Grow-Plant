using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button1Click : MonoBehaviour
{
    public TextMeshProUGUI button1Text;
    private int dateCount = 0;
    public WeatherUI weatherUI;
    private EventButtonUI eventButtonUI;
    private static int waterCount;

    void Start()
    {
        eventButtonUI = FindAnyObjectByType<EventButtonUI>();

        dateCount = weatherUI.GetDateCount() + 1;
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
        weatherUI.SetDateCount();
        waterCount++;
       
        if (waterCount >= 5)
        {
            Debug.Log("Die");
        }
        //버튼을 클릭하면 date++, 점수 더하기, 팝업창 닫기, waterCount++ (5가 쌓일 시 식물 죽음 * 단, 연속이 아니면 카운트 초기화)

        //창닫기
        eventButtonUI.ClosePopupWindow();
    }

    public int initWaterCount()
    {
        waterCount = 0;
        return waterCount; //다른 버튼이 눌릴 시 waterCount를 0으로 초기화
    }
}
