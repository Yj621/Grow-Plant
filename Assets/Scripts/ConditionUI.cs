using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConditionUI : MonoBehaviour
{
    public int conditionPoint = 50;
    public TextMeshProUGUI conditionText;

    void Start()
    {
        if (conditionPoint <= 0)
        {
            //�Ĺ� �׾��� �� ������ �޼��� ȣ��
        }
        else
        {
            if (conditionPoint > 90 && conditionPoint <= 100)
            {
                conditionText.text += "���� ���� ����";
            }
            if (conditionPoint > 80 && conditionPoint <= 90)
            {
                conditionText.text += "�ſ� ����";
            }
            if (conditionPoint > 70 && conditionPoint <= 80)
            {
                conditionText.text += "����";
            }
            if (conditionPoint > 60 && conditionPoint <= 70)
            {
                conditionText.text += "�������� ��";
            }
            if (conditionPoint > 40 && conditionPoint <= 60)
            {
                conditionText.text += "����";
            }
            if (conditionPoint > 30 && conditionPoint <= 40)
            {
                conditionText.text += "�������� ��";
            }
            if (conditionPoint > 20 && conditionPoint <= 30)
            {
                conditionText.text += "����";
            }
            if (conditionPoint > 10 && conditionPoint <= 20)
            {
                conditionText.text += "�ſ� ����";
            }
            if (conditionPoint > 30 && conditionPoint <= 40)
            {
                conditionText.text += "������ ��";
            }
        }
    }

    void Update()
    {
        
    }
}
