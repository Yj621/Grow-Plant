using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button2Click : MonoBehaviour
{
    public TextMeshProUGUI button2Text;
    public int dateCount = 0;
    private static int NeglectCount;
    public WeatherUI weatherUI;
    public Button1Click button1Click;
    private EventButtonUI eventButtonUI;
    public ConditionUI conditionUI;
    public BlockingButton blockingBtn;

    FadeInOut fadeInOut;
    MemoPanel memoPanel;
    GameManager gameManager;
    DiePanel diePanel;

    void Start()
    {
        eventButtonUI = FindAnyObjectByType<EventButtonUI>();
        fadeInOut = GameObject.FindObjectOfType<FadeInOut>();
        gameManager = FindObjectOfType<GameManager>();
        memoPanel = FindAnyObjectByType<MemoPanel>();
        diePanel = FindObjectOfType<DiePanel>();
        dateCount = weatherUI.GetDateCount() + 1;
        
        string[] button2Arr = {
            "냅둔다",
            "가습기를 튼다",
            "습도가 높은 것 같다. 확인해보자",
            "잎에 물을 묻힌다"
        };
        string textValue;
        if (dateCount == 7)  //dateCount는 일차를 나타냄.
                             //7일차, 8일차, 16일차에는 txt파일의 각각 2번째 줄, 3번째 줄, 4번째 줄의 내용을 넣음.
        {
            textValue = button2Arr[1];
        }
        else if (dateCount == 8)
        {
            textValue = button2Arr[2];
        }
        else if (dateCount == 16)
        {
            textValue = button2Arr[3];
        }
        else
        {
            textValue = button2Arr[0];
        }

        if (button2Text != null)
        {
            button2Text.text = textValue;
        }
        else
        {
            Debug.LogError("button2Text가 할당되지 않았습니다.");
        }
    }

    public void Button2OnClick()
    {
        StartCoroutine(Button2ClickSequence());
        if (dateCount == 5) //벌레가 잡아먹음
        {
            diePanel.Btn2SpecialDied(dateCount);
        }
        else if(dateCount == 8) //이유찾기
        {
            diePanel.Btn2SpecialDied(dateCount);
        }
        else if(dateCount == 13) //줄기가 길어짐
        {
            diePanel.Btn2SpecialDied(dateCount);
        }
    }
    private IEnumerator Button2ClickSequence()
    {
        yield return StartCoroutine(fadeInOut.FadeAlpha());
        //창닫기
        eventButtonUI.ClosePopupWindow();

        weatherUI.SetDateCount();
        
        NeglectCount++;
        Debug.Log("NeglectCount : "+NeglectCount);
        if (NeglectCount >= 3)
        {
            diePanel.PanelOn();
            diePanel.diedText.text = "식물을 오랫동안 방치해서 죽었습니다.";
        }

        //일차별 버튼2 점수
        int[] btn2ScoreArr = {0,0,0,10,-999,0,10,-999,0,0,        //-999는 즉사, 999는 히든엔딩
            0,0,0,-999,0,10,0,0,0,0,0,0};                         //4일차 1번 버튼은 습한데 물을 많이 먹음 -50
        //점수 더하기
        conditionUI.GetCondPoint(btn2ScoreArr[dateCount - 1]);

        memoPanel.UpdateDayText();// +점수인지 -점수인지에 따라 메모패널 텍스트 변경(GetCondPoint보다 아래에 있어야 제대로 표시 가능)

        //메모패널 열기 
        memoPanel.MemoPanelOn();

        //waterCount 초기화
        button1Click.initWaterCount();

        blockingBtn.CloseBlockingButton();
    }
    public int initNeglectCount()
    {
        NeglectCount = 0;
        return NeglectCount; //다른 버튼이 눌릴 시 NeglectCount 0으로 초기화
    }
}
