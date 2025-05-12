using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject blockingImg;
    public GameObject quitPanel;
    public ConditionUI conditionUI;
    public DateUI dateUI;
    public EventTextUI eventTextUI;
    public EventButtonUI eventButtonUI;
    public FadeInOut fadeInOut;
    public Button1Click button1Click;
    public Button2Click button2Click;
    public Button3Click button3Click;
    public Button4Click button4Click;
    public Notice _notice;
    public PlantsLevelChange plantsLevelChange;
    public DiePanel diePanel;
    public GameObject SettingPanel;

    [HideInInspector]
    public bool lastMusicState; // 마지막으로 선택된 음악 On/Off 상태

    void Start()
    {
        GameLoad();

        // 처음 시작할 때만 50점으로 초기화
        if (ConditionUI.conditionPoint <= 0)
            ConditionUI.conditionPoint = 50;

        dateUI.UpdateDayText();
        conditionUI.ReturnCondPoint();
        WeatherUI.Instance.WeatherTextUpdate();
        WeatherUI.Instance.WeatherLightUpdate();

        blockingImg.SetActive(false);
        quitPanel.SetActive(false);
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android && Input.GetKey(KeyCode.Escape))
            OpenQuitPanel();
    }

    public void OpenQuitPanel()
    {
        quitPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenSettingPanel()
    {
        SettingPanel.SetActive(true);
        TouchManager.Instance.isPanelActive = true;
    }

    public void CloseSettingPanel()
    {
        SettingPanel.SetActive(false);
        TouchManager.Instance.isPanelActive = false;
    }

    public void GameSave()
    {
        PlayerPrefs.SetInt("ConditionPoint", ConditionUI.conditionPoint);
        PlayerPrefs.SetInt("Button1Click", button1Click.dateCount);
        PlayerPrefs.SetInt("Button2Click", button2Click.dateCount);
        PlayerPrefs.SetInt("Button3Click", button3Click.dateCount);
        PlayerPrefs.SetInt("Button4Click", button4Click.dateCount);
        PlayerPrefs.SetInt("EventTextUI", eventTextUI.dateCount);
        PlayerPrefs.SetInt("DateUI", dateUI.dateCount);
        PlayerPrefs.SetInt("WeatherUI", WeatherUI.Instance.date);
        PlayerPrefs.Save();
        _notice.SUB("저장되었습니다.");
    }

    public void GameLoad()
    {
        ConditionUI.conditionPoint = PlayerPrefs.GetInt("ConditionPoint", 50);
        button1Click.dateCount = PlayerPrefs.GetInt("Button1Click");
        button2Click.dateCount = PlayerPrefs.GetInt("Button2Click");
        button3Click.dateCount = PlayerPrefs.GetInt("Button3Click");
        button4Click.dateCount = PlayerPrefs.GetInt("Button4Click");
        eventTextUI.dateCount = PlayerPrefs.GetInt("EventTextUI");
        dateUI.dateCount = PlayerPrefs.GetInt("DateUI");
        WeatherUI.Instance.date = PlayerPrefs.GetInt("WeatherUI");
    }

    public void Restart()
    {
        // 현재 음악 On/Off 상태 저장
        lastMusicState = SoundManager.Instance.isMusicOn;

        // 게임 상태 초기화
        ConditionUI.conditionPoint = 50;
        button1Click.initWaterCount();
        button2Click.initNeglectCount();
        dateUI.dateCount = 0;
        WeatherUI.Instance.date = 0;
        DateUI.isExecuted = false;
        DateUI.isExecuted2 = false;
        EndingScenesManager.isEnding = false;
        diePanel.isDie = false;
        TouchManager.Instance.isPanelActive = false;

        dateUI.UpdateDayText();
        conditionUI.ReturnCondPoint();
        WeatherUI.Instance.WeatherTextUpdate();
        WeatherUI.Instance.WeatherLightUpdate();
        plantsLevelChange.CheckDate();

        // 리셋 직후엔 음악을 무조건 끔
        SoundManager.Instance.ToggleMusic(false);

        // 1초 뒤에 이전 상태로 복원
        StartCoroutine(DelayRestoreMusic());
    }

    private IEnumerator DelayRestoreMusic()
    {
        yield return new WaitForSeconds(1f);
        SoundManager.Instance.ToggleMusic(lastMusicState);
    }

    public void ClosePanel()
    {
        TouchManager.Instance.isPanelActive = false;
    }
}
