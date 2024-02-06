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
        string filePath = "Assets/TextFiles/button2Text.txt";
        string[] textLines = System.IO.File.ReadAllLines(filePath);
        string textValue;
        if (dateCount == 7)  //dateCount�� ������ ��Ÿ��.
                             //7����, 8����, 16�������� txt������ ���� 2��° ��, 3��° ��, 4��° ���� ������ ����.
        {
            textValue = textLines[1];
        }
        else if (dateCount == 8)
        {
            textValue = textLines[2];
        }
        else if (dateCount == 16)
        {
            textValue = textLines[3];
        }
        else
        {
            textValue = textLines[0];
        }

        if (button2Text != null)
        {
            button2Text.text = textValue;
        }
        else
        {
            Debug.LogError("button2Text�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }

    void Update()
    {

    }

    public void Button2OnClick()
    {
        weatherUI.SetDateCount();
       
        //��ư�� Ŭ���ϸ� date++, ���� ���ϱ�
        //waterCount �ʱ�ȭ
        button1Click.initWaterCount();

        //â�ݱ�
        eventButtonUI.ClosePopupWindow();
    }
}
