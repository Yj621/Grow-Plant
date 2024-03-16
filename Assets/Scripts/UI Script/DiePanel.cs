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
        
        switch(dateCount)
        {
            case 2:
                diedText.text = "선탠을 즐기는 동안 식물이 말라 죽었습니다. 다시 시작하시겠습니까?";
                break;
            case 8:
                diedText.text = "이유를 찾지 못해서 죽었습니다. 다시 시작하시겠습니까?";
                break;
            case 9:
                diedText.text = "뿌리가 손상되어 죽었습니다.";
                break;
            case 12:
                diedText.text = "줄기가 꺾여버렸다.";
                break;
            case 14:
                diedText.text = "줄기가 너무 길어서 꺾여 죽었습니다. 다시 시작하시겠습니까?";
                break;
            case 20:
                diedText.text = "실수로 뿌리가 다 잘렸습니다.";
                break;
            case 21:
                diedText.text = "벌레가 너무 많이 꼬여 죽었습니다.";
                break;
            case 23:
                diedText.text = "화난 꿀벌 집단에 쏘여 죽었습니다.";
                break;
            case 24:
                diedText.text = "창문을 열어서 동사했습니다.";
                break;
            case 25:
                diedText.text = "눈사람을 만드는 동안 식물이 동사했습니다.";
                break;
            case 26:
                diedText.text = "나쁜아이라며 식물을 빼앗겼습니다.";
                break;
            default:
                diedText.text = "알 수 없는 이유로 죽었습니다.";
                break;
        }
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
