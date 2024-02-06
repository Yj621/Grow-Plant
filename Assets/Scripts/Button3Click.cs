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
            "���� �ĺ���", "�Ĺ��� �ű��", "�Ĺ��� ������ ������ �ű��",
            "â���� ����", "�������� �Ѹ���", "â���� ����", "�ν�Ÿ�� �ø���",
            "������ �����Ѱ�? �������� ����", "�����⸦ ư��", "�����⸦ ư��",
            "ȯ�⸦ ��Ų��", "�����⸦ ư��", "â���� ����", "���𰡸� �����´�",
            "�����⸦ ư��", "�ٿ� ���� ������", "�����⸦ ư��", "�����⸦ ư��",
            "�����⸦ ư��", "�����⸦ ư��", "�����⸦ ư��", "���� ���� �׳࿡�� �ش�"
        };
        string textValue = button3Arr[dateCount];

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
