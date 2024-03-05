using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiePanel : MonoBehaviour
{
    public TextMeshProUGUI diedText;
    public GameObject diePanel;
    public bool isPanelOn = false;

    void Start()
    {
        diePanel.SetActive(false);
    }
    public void PanelOn()
    {
        diePanel.SetActive(true);
        isPanelOn = true;
    }

    public void PanelOff()
    {
        diePanel.SetActive(false);
        isPanelOn = false;
    }

    public void Btn1SpecialDied(int dateCount)
    {
        if(dateCount == 8)
        {
            diedText.text = "이유를 찾지 못해서 죽었습니다.";
        }
    }

    public void Btn2SpecialDied(int dateCount)
    {
        if(dateCount == 5)
        {
            diedText.text = "벌레들이 잡아먹어 죽었습니다.";
        }
        else if(dateCount == 8)
        {
            diedText.text = "이유를 찾지 못해서 죽었습니다.";
        }
    }


    public void Btn3SpecialDied(int dateCount)
    {
        if(dateCount == 1)
        {
            diedText.text = "씨앗을 건들여서 죽었습니다.";
        }
        else if(dateCount == 2)
        {
            diedText.text = "식물을 그늘로 옮겨서 죽었습니다.";
        }
        else if(dateCount == 8)
        {
            diedText.text = "이유를 찾지 못해서 죽었습니다.";
        }
        else if(dateCount == 13)
        {
            diedText.text = "태풍에 식물이 날라가버렸습니다.";
        }
    }

}
