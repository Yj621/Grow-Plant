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
            "���� �ش�",
            "��/����� ������ �� ����. ����",
            "�Ĺ��� �ű��"
        };
        string textValue;
        if (dateCount == 8)  //dateCount�� ������ ��Ÿ��. 8����, 16�������� txt������ ���� 2��° �ٰ� 3��° ���� ������ ����.
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
            Debug.LogError("button1Text�� �Ҵ���� �ʾҽ��ϴ�.");
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
        //��ư�� Ŭ���ϸ� date++, ���� ���ϱ�, �˾�â �ݱ�, waterCount++ (5�� ���� �� �Ĺ� ���� * ��, ������ �ƴϸ� ī��Ʈ �ʱ�ȭ)

        //â�ݱ�
        eventButtonUI.ClosePopupWindow();
    }

    public int initWaterCount()
    {
        waterCount = 0;
        return waterCount; //�ٸ� ��ư�� ���� �� waterCount�� 0���� �ʱ�ȭ
    }
}
