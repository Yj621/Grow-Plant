using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button3Click : MonoBehaviour
{
    public TextMeshProUGUI button3Text;
    public int dateCount = 0;
    public WeatherUI weatherUI;
    public Button1Click button1Click;
    public Button2Click button2Click;
    private EventButtonUI eventButtonUI;
    public ConditionUI conditionUI;
    public BlockingButton blockingBtn;

    FadeInOut fadeInOut;
    MemoPanel memoPanel;
    private DiePanel diePanel;

    string[] button3MemoArr =
        {
            "비가 들이쳐서 식물이 물을 많이 먹었다."
            
        };

    void Start()
    {
        eventButtonUI = FindAnyObjectByType<EventButtonUI>();
        fadeInOut = GameObject.FindObjectOfType<FadeInOut>();
        memoPanel = FindAnyObjectByType<MemoPanel>();
        diePanel = FindAnyObjectByType<DiePanel>();
        dateCount = weatherUI.GetDateCount() + 1;

        string[] button3Arr = {
            "흙을 파본다", "식물을 옮긴다", "식물을 따뜻한 곳으로 옮긴다",
            "창문을 연다", "살충제를 뿌린다", "창문을 연다", "가습기를 튼다",
            "영양이 부족한가? 영양제를 주자", "가습기를 튼다", "가습기를 튼다",
            "가지치기한다", "무언가를 가져온다", "창문을 연다", "젓가락을 덧댄다",
            "햇볕에 옮긴다", "살충제를 뿌린다", "가습기를 튼다", "가습기를 튼다",
            "가습기를 튼다", "분갈이를 해준다", "가습기를 튼다", "꽃을 꺾어 그녀에게 준다",
            "살충제를 뿌린다", "식물을 옮긴다", "눈을 치운다", "정중하게 인사한다",
            "자책하며 식물을 버린다", "열매를 먹어본다", "열매를 먹어본다", 
            "열매를 딴다" //"열매 수확" 엔딩
        };
        string textValue = button3Arr[dateCount - 1];

        if (button3Text != null)
        {
            button3Text.text = textValue;
        }
        else
        {
            Debug.LogError("button3Text가 할당되지 않았습니다.");
        }
    }

    public void Button3OnClick()
    {
        StartCoroutine(Button3lickSequence());

        if (dateCount == 1) //씨앗 건드림.
        {
            diePanel.Btn3SpecialDied(dateCount);
        }
        else if (dateCount == 2) //식물을 그늘로 옮김
        {
            diePanel.Btn3SpecialDied(dateCount);
        }
        else if (dateCount == 8) //이유찾기
        {
            diePanel.Btn3SpecialDied(dateCount);
        }
        else if (dateCount == 13) //태풍에 날라감
        {
            diePanel.Btn3SpecialDied(dateCount);
        }
    }
    
    private IEnumerator Button3lickSequence()
    {
        yield return StartCoroutine(fadeInOut.FadeAlpha());
        //창닫기
        eventButtonUI.ClosePopupWindow();
          
        weatherUI.SetDateCount();

        //일차별 버튼3 점수
        int[] btn3ScoreArr = {-999,-999,3,-50,5,10,20,20,20,10,         //-999는 즉사, 999는 히든엔딩
            10,10,-999,10,10,0,10,10,10,10,10,999};                     //4일차 1번 버튼은 비가 들이쳐서 물을 많이 먹음 -50
        
        //점수 더하기
        conditionUI.GetCondPoint(btn3ScoreArr[dateCount - 1]);

        //메모패널 콘텐츠텍스트
        memoPanel.UpdateDayText(); // +점수인지 -점수인지에 따라 메모패널 텍스트 변경(GetCondPoint보다 아래에 있어야 제대로 표시 가능)
        if (dateCount == 4)
        {
            memoPanel.contentText.text = button3MemoArr[0]; //memoPanel.UpdateDayText()보다 밑에 있어야 함.
        }
        
        if(diePanel.isDie == false)
        {
            //메모패널 열기 
            memoPanel.MemoPanelOn();
        }
        else
        {
            Debug.Log("close block");
            blockingBtn.CloseBlockingButton();
        }
        
        //waterCount 초기화
        button1Click.initWaterCount();

        //NeglectCount 초기화
        button2Click.initNeglectCount();

        //창닫기
        //blockingBtn.CloseBlockingButton();      
    }
}
