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
            //식물 죽었을 때 실행할 메서드 호출
        }
        else
        {
            if (conditionPoint > 90 && conditionPoint <= 100)
            {
                conditionText.text += "정말 많이 좋음";
            }
            if (conditionPoint > 80 && conditionPoint <= 90)
            {
                conditionText.text += "매우 좋음";
            }
            if (conditionPoint > 70 && conditionPoint <= 80)
            {
                conditionText.text += "좋음";
            }
            if (conditionPoint > 60 && conditionPoint <= 70)
            {
                conditionText.text += "좋아지려 함";
            }
            if (conditionPoint > 40 && conditionPoint <= 60)
            {
                conditionText.text += "보통";
            }
            if (conditionPoint > 30 && conditionPoint <= 40)
            {
                conditionText.text += "나빠지려 함";
            }
            if (conditionPoint > 20 && conditionPoint <= 30)
            {
                conditionText.text += "나쁨";
            }
            if (conditionPoint > 10 && conditionPoint <= 20)
            {
                conditionText.text += "매우 나쁨";
            }
            if (conditionPoint > 30 && conditionPoint <= 40)
            {
                conditionText.text += "죽으려 함";
            }
        }
    }

    void Update()
    {
        
    }
}
