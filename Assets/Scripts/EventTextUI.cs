using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventTextUI : MonoBehaviour
{
    public TextMeshProUGUI eventText;
    private int dateCount = 0;
    public WeatherUI weatherUI;

    void Start()
    {
        OpenEvent();
    }

    void OpenEvent()
    {
        string[] eventTextArr = {
            "���� �����ִ�", "�ذ� ¸¸�ϴ�", "���� ������ �����ߴ�",
            "�� ���� ���ϴ�", "���ؼ� ������ ���� �����", "������ ȭâ�ϴ�",
            "���� �մ�", "�Ĺ��� �õ����. ������ ã��", "�Ĺ��� �� �ڶ�� �ִ�",
            "�̺�Ʈ ����", "��ǳ�� �Ͼ��", "�ٱⰡ ���� �������",
            "�̺�Ʈ ����", "���� �ڶ���", "�̺�Ʈ ����",
            "�̺�Ʈ ����", "�������� ������", "�̺�Ʈ ����",
            "�̺�Ʈ ����", "���� ���"
            };
        /*, "�̺�Ʈ ����",
        "���� ������", "�̺�Ʈ ����", "�̺�Ʈ ����",  //22�� ���� ����(���� �Ǹ� ������ �ǰ�?)
        "���� ����", "�̺�Ʈ ����", "�̺�Ʈ ����"
        */

        dateCount = weatherUI.GetDateCount();
        string textValue = eventTextArr[dateCount];

        eventText.text = textValue;

    }
}
