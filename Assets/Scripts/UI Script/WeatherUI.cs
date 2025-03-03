using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class WeatherUI : Singleton<WeatherUI>
{
    public TextMeshProUGUI weatherText;
    public int date = 0; // 이벤트를 하나씩 넘길 때마다 date++
    string originWeatherText;
    public DateUI dateUI;
    public SunnyLight sunnyLight;
    public RainyLight rainyLight;
    public StormyLight stormyLight;
    public SnowyLight snowyLight;
    public PlantsLevelChange plantsLevelChange;

    private readonly string[] weatherArr = {
        "맑음", "맑음", "흐림", "비", "비", "맑음", "맑음", "맑음", "건조함",
        "맑음", "맑음", "흐림", "태풍", "태풍", "맑음", "맑음", "맑음", "습함",
        "습함", "비", "맑음", "맑음", "흐림", "눈", "눈", "맑음", "맑음",
        "흐림", "비", "맑음", "맑음"
    };

    void Start()
    {
        originWeatherText = weatherText.text;  // "날씨 : "를 저장하는 변수

        UpdateWeatherText();
    }

    void UpdateWeatherText()
    {
        if (weatherText != null && date < weatherArr.Length)
        {
            weatherText.text = originWeatherText + weatherArr[date];
        }
        else
        {
            Debug.LogError("weatherText가 할당되지 않았거나 date가 범위를 초과했습니다.");
        }
    }

    public void WeatherTextUpdate()
    {
        // 이벤트를 하나씩 넘길 때마다 텍스트 업데이트
        if (date < weatherArr.Length)
        {
            weatherText.text = originWeatherText + weatherArr[date];
        }
        else
        {
            Debug.LogWarning("더 이상 텍스트가 없습니다.");
        }
    }

    public void WeatherLightUpdate()
    {
        if (DiePanel.Instance.isDie)
        {
            SoundManager.Instance.backgroundMusic[SoundManager.Instance.currentIndex].Stop();
            return;
        }

        if (date >= weatherArr.Length) return;

        switch (weatherArr[date])
        {
            case "맑음":
                sunnyLight.ActivateSunnyLight();
                rainyLight.DeactivateCloudyLight();
                rainyLight.DeactivateRainEffect();
                stormyLight.DeactivateStormEffect();
                stormyLight.DeactivateStormWindZone();
                snowyLight.DeactivateSnowEffect();
                PlayMusic(0);
                break;
            case "흐림":
                sunnyLight.DeactivateSunnyLight();
                rainyLight.ActivateCloudyLight();
                rainyLight.DeactivateRainEffect();
                stormyLight.DeactivateStormEffect();
                stormyLight.DeactivateStormWindZone();
                snowyLight.DeactivateSnowEffect();
                PlayMusic(4);
                break;
            case "비":
                sunnyLight.DeactivateSunnyLight();
                rainyLight.ActivateCloudyLight();
                rainyLight.ActivateRainEffect();
                stormyLight.DeactivateStormEffect();
                stormyLight.DeactivateStormWindZone();
                snowyLight.DeactivateSnowEffect();
                PlayMusic(1);
                break;
            case "태풍":
                sunnyLight.DeactivateSunnyLight();
                rainyLight.ActivateCloudyLight();
                rainyLight.DeactivateRainEffect();
                stormyLight.ActivateStormEffect();
                stormyLight.ActivateStormWindZone();
                snowyLight.DeactivateSnowEffect();
                PlayMusic(2);
                break;
            case "눈":
                sunnyLight.DeactivateSunnyLight();
                rainyLight.ActivateCloudyLight();
                rainyLight.DeactivateRainEffect();
                stormyLight.DeactivateStormEffect();
                stormyLight.DeactivateStormWindZone();
                snowyLight.ActivateSnowEffect();
                PlayMusic(3);
                break;
        }
    }
    void PlayMusic(int musicIndex)
    {
        SoundManager.Instance.currentIndex = musicIndex;
        
        if (!SoundManager.Instance.isMusicOn) return;

        for (int i = 0; i < SoundManager.Instance.backgroundMusic.Length; i++)
        {
            if (i == musicIndex)
            {
                if (!SoundManager.Instance.backgroundMusic[i].isPlaying)
                {
                    SoundManager.Instance.backgroundMusic[i].Play();
                }
            }
            else
            {
                if (SoundManager.Instance.backgroundMusic[i].isPlaying)
                {
                    SoundManager.Instance.backgroundMusic[i].Stop();
                }
            }
        }
    }



    public int GetDateCount()
    {
        return date;
    }

    public void SetDateCount()
    {
        if (date >= weatherArr.Length - 1) return;

        date++;
        plantsLevelChange.CheckDate();
        dateUI.IncreaseDateCount();
        WeatherTextUpdate();
        WeatherLightUpdate();
    }
}
