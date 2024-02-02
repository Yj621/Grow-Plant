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
        string filePath = "Assets/TextFiles/button3Text.txt";
        string[] textLines = System.IO.File.ReadAllLines(filePath);
        string textValue;
        if (dateCount == 7)  //dateCount�� ������ ��Ÿ��. 7����, 8�������� txt������ ���� 2��° �ٰ� 3��° ���� ������ ����.
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

        if (button3Text != null)
        {
            button3Text.text = textValue;
        }
        else
        {
            Debug.LogError("button3Text�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }

    void Update()
    {

    }

    public void Button3OnClick()
    {
        weatherUI.SetDateCount();
        
       
        //��ư�� Ŭ���ϸ� date++, ���� ���ϱ�
        //waterCount �ʱ�ȭ
        button1Click.initWaterCount();

        //â�ݱ�
        eventButtonUI.ClosePopupWindow();
    }
}
