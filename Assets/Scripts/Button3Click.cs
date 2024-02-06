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
    
    FadeInOut fadeInOut;


    void Start()
    {
        eventButtonUI = FindAnyObjectByType<EventButtonUI>();
        fadeInOut = GameObject.FindObjectOfType<FadeInOut>();
        dateCount = weatherUI.GetDateCount() + 1;
        string filePath = "Assets/TextFiles/button3Text.txt";
        string[] textLines = System.IO.File.ReadAllLines(filePath);
        string textValue = textLines[dateCount];

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
        fadeInOut.StartCoroutine(fadeInOut.FadeAlpha());
    }
}
