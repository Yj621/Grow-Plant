using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button4Click : MonoBehaviour
{
    public TextMeshProUGUI button4Text;
    private int dateCount = 0;
    public WeatherUI weatherUI;
    public Button1Click button1Click;
    private EventButtonUI eventButtonUI;
    public Button button4;

    FadeInOut fadeInOut;

    void Start()
    {
        eventButtonUI = FindAnyObjectByType<EventButtonUI>();
        fadeInOut = GameObject.FindObjectOfType<FadeInOut>();
        dateCount = weatherUI.GetDateCount() + 1;
        string[] button4Arr = {
            "�����Ѵ�", "���� ���δ�", "����ġ�� �Ѵ�",
            "�Ĺ��� �ű��", "�������� �ش�"
        };

        string textValue;
        bool isButtonInteractable = false;
        if (dateCount == 3)  //dateCount�� ������ ��Ÿ��.
                             //4��° ��ư�� �ִ� �������� ��ư�� Ȱ��ȭ, �ƴ� ������ ��Ȱ��ȭ
        {
            textValue = button4Arr[0];
            isButtonInteractable = true;
        }
        else if (dateCount == 5)
        {
            textValue = button4Arr[1];
            isButtonInteractable = true;
        }
        else if (dateCount == 11)
        {
            textValue = button4Arr[2];
            isButtonInteractable = true;
        }
        else if (dateCount == 13)
        {
            textValue = button4Arr[3];
            isButtonInteractable = true;
        }
        else if (dateCount == 22)
        {
            textValue = button4Arr[4];
            isButtonInteractable = true;
        }
        else
        {
            textValue = button4Arr[0];
            isButtonInteractable = false;
        }

        if (button4Text != null)
        {
            button4Text.text = textValue;
            button4 = GetComponent<Button>(); //button4�� ã�Ƽ� �Ҵ�
            if (button4 != null)
            {
                //������ ���� ��ư�� Ȱ��ȭ or ��Ȱ��ȭ
                button4.interactable = isButtonInteractable;
                button4.image.enabled = isButtonInteractable; //Source Image ��Ȱ��ȭ
                button4Text.enabled = isButtonInteractable;   //�����ִ� text ��Ȱ��ȭ
            }
        }
        else
        {
            Debug.LogError("button4Text�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }

    public void Button4OnClick()
    {
        weatherUI.SetDateCount();

        //��ư�� Ŭ���ϸ� date++, ���� ���ϱ�
        //waterCount �ʱ�ȭ
        button1Click.initWaterCount();

        //â�ݱ�
        eventButtonUI.ClosePopupWindow();
        fadeInOut.StartCoroutine(fadeInOut.FadeAlpha());
    }
}
