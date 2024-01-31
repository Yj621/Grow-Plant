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
            Debug.LogError("button1Text�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }

    void Update()
    {
        
    }
    
    public void Button1OnClick()
    {
        //��ư�� Ŭ���ϸ� date++, ���� ���ϱ�, waterCount++ (5�� ���� �� �Ĺ� ���� * ��, ������ �ƴϸ� ī��Ʈ �ʱ�ȭ)
    }
}
