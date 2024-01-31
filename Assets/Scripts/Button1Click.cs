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

    void Start()
    {
        dateCount = weatherUI.GetDateCount() + 1;
        string filePath = "Assets/TextFiles/button1Text.txt";
        string[] textLines = System.IO.File.ReadAllLines(filePath);
        string textValue;
        if(dateCount == 8)
        {
            textValue = textLines[1];
        }
        else if(dateCount == 16)
        {
            textValue = textLines[2];
        }
        else
        {
            textValue = textLines[0];
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
        //버튼을 클릭하면 date++, 점수 더하기, waterCount++ (5가 쌓일 시 식물 죽음 * 단, 연속이 아니면 카운트 초기화)
    }
}
