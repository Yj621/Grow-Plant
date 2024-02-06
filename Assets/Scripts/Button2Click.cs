using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button2Click : MonoBehaviour
{
    public TextMeshProUGUI button2Text;
    private int dateCount = 0;
    public WeatherUI weatherUI;
    public Button1Click button1Click;
    private EventButtonUI eventButtonUI;
    
    void Start()
    {
        eventButtonUI = FindAnyObjectByType<EventButtonUI>();

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

    void Update()
    {

    }

    public void Button2OnClick()
    {
        weatherUI.SetDateCount();
       
        //버튼을 클릭하면 date++, 점수 더하기
        //waterCount 초기화
        button1Click.initWaterCount();

        //창닫기
        eventButtonUI.ClosePopupWindow();
    }
}
