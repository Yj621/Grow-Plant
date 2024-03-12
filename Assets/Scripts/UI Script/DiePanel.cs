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
    public bool isDie = false;
    SoundManager soundManager;

    void Start()
    {
        diePanel.SetActive(false);
        soundManager = FindAnyObjectByType<SoundManager>();
    }
    public void PanelOn()
    {
        diePanel.SetActive(true);
        isPanelOn = true;
        soundManager.Sound(5);
    }

    public void PanelOff()
    {
        diePanel.SetActive(false);
        isPanelOn = false;
    }

    public void Btn1SpecialDied(int dateCount)
    {
        isDie = true;
        if(dateCount == 8)
        {
            diedText.text = "이유를 찾지 못해서 죽었습니다. 다시 시작하시겠습니까?";
        }
        else if(dateCount == 14)
        {
            diedText.text = "줄기가 너무 길어서 꺾여죽었습니다. 다시 시작하시겠습니까?";
        }
    }

    public void Btn2SpecialDied(int dateCount)
    {
        isDie = true;
        if(dateCount == 5)
        {
            diedText.text = "벌레들이 잡아먹어 죽었습니다. 다시 시작하시겠습니까?";
        }
        else if(dateCount == 8)
        {
            diedText.text = "이유를 찾지 못해서 죽었습니다. 다시 시작하시겠습니까?";
        }
        else if(dateCount == 14)
        {
            diedText.text = "줄기가 너무 길어서 꺾여죽었습니다. 다시 시작하시겠습니까?";
        }
    }


    public void Btn3SpecialDied(int dateCount)
    {
        isDie = true;
        if(dateCount == 1)
        {
            diedText.text = "씨앗을 건들여서 죽었습니다. 다시 시작하시겠습니까?";
        }
        else if(dateCount == 2)
        {
            diedText.text = "식물을 그늘로 옮겨서 죽었습니다. 다시 시작하시겠습니까?";
        }
        else if(dateCount == 8)
        {
            diedText.text = "이유를 찾지 못해서 죽었습니다. 다시 시작하시겠습니까?";
        }
        else if(dateCount == 13)
        {
            diedText.text = "태풍에 식물이 날라가버렸습니다. 다시 시작하시겠습니까?";
        }
    }
    
    public void Btn4SpecialDied(int dateCount)
    {
        isDie = true;
        if(dateCount == 13)
        {
            diedText.text = "모르고 줄기를 잘라버려서 죽었습니다. 다시 시작하시겠습니까?";
        }
        // else if(dateCount == 2)
        // {
        //     diedText.text = "식물을 그늘로 옮겨서 죽었습니다. 다시 시작하시겠습니까?";
        // }
        // else if(dateCount == 8)
        // {
        //     diedText.text = "이유를 찾지 못해서 죽었습니다. 다시 시작하시겠습니까?";
        // }
    }

    public void SpecialDie(int dateCount)
    {
        PanelOn();
        if(dateCount == 8)
        {
            diedText.text = "지나가던 강아지가 식물을 먹어버렸습니다. 다시 시작하시겠습니까?";
        }
    }
}
