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
            "응원한다", "직접 죽인다", "가지치기 한다",
            "식물을 옮긴다", "영양제를 준다"
        };

        string textValue;
        bool isButtonInteractable = false;
        if (dateCount == 3)  //dateCount는 일차를 나타냄.
                             //4번째 버튼이 있는 일차에는 버튼이 활성화, 아닌 날에는 비활성화
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
            button4 = GetComponent<Button>(); //button4를 찾아서 할당
            if (button4 != null)
            {
                //일차에 따라서 버튼이 활성화 or 비활성화
                button4.interactable = isButtonInteractable;
                button4.image.enabled = isButtonInteractable; //Source Image 비활성화
                button4Text.enabled = isButtonInteractable;   //남아있는 text 비활성화
            }
        }
        else
        {
            Debug.LogError("button4Text가 할당되지 않았습니다.");
        }
    }

    public void Button4OnClick()
    {
        weatherUI.SetDateCount();

        //버튼을 클릭하면 date++, 점수 더하기
        //waterCount 초기화
        button1Click.initWaterCount();

        //창닫기
        eventButtonUI.ClosePopupWindow();
        fadeInOut.StartCoroutine(fadeInOut.FadeAlpha());
    }
}
