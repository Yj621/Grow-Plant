// WeatherUI.cs
using UnityEngine;
using TMPro;

public class WeatherUI : Singleton<WeatherUI>
{
    public TextMeshProUGUI weatherText;
    private string originWeatherText;
    public int date = 0;  // 이벤트 진행에 따라 증가

    [Header("날씨별 라이트/이펙트")]
    public DateUI dateUI;
    public SunnyLight sunnyLight;
    public RainyLight rainyLight;
    public StormyLight stormyLight;
    public SnowyLight snowyLight;
    public PlantsLevelChange plantsLevelChange;

    private readonly string[] weatherArr = {
        "맑음","맑음","흐림","비","비","맑음","맑음","맑음","건조함",
        "맑음","맑음","흐림","태풍","태풍","맑음","맑음","맑음","습함",
        "습함","비","맑음","맑음","흐림","눈","눈","맑음","맑음",
        "흐림","비","맑음","맑음"
    };

    void Start()
    {
        originWeatherText = weatherText.text;  // "날씨 : " 부분 저장
        WeatherTextUpdate();
        WeatherLightUpdate();
    }

    public void WeatherTextUpdate()
    {
        if (date < weatherArr.Length)
            weatherText.text = originWeatherText + weatherArr[date];
    }

    /// <summary>
    /// 날씨별 라이트/음악 제어
    /// </summary>
    public void WeatherLightUpdate()
    {
        // 플레이어가 이미 죽었다면 음악만 정지
        if (DiePanel.Instance.isDie)
        {
            SoundManager.Instance.StopMusic();
            return;
        }

        // 음악이 꺼져 있을 땐 아예 처리 중단
        if (!SoundManager.Instance.isMusicOn)
            return;

        if (date >= weatherArr.Length)
            return;

        switch (weatherArr[date])
        {
            case "맑음":
                sunnyLight.ActivateSunnyLight();
                rainyLight.DeactivateCloudyLight();
                rainyLight.DeactivateRainEffect();
                stormyLight.DeactivateStormEffect();
                stormyLight.DeactivateStormWindZone();
                snowyLight.DeactivateSnowEffect();
                SoundManager.Instance.PlayMusic(0);
                break;
            case "흐림":
                sunnyLight.DeactivateSunnyLight();
                rainyLight.ActivateCloudyLight();
                rainyLight.DeactivateRainEffect();
                stormyLight.DeactivateStormEffect();
                stormyLight.DeactivateStormWindZone();
                snowyLight.DeactivateSnowEffect();
                SoundManager.Instance.PlayMusic(4);
                break;
            case "비":
                sunnyLight.DeactivateSunnyLight();
                rainyLight.ActivateCloudyLight();
                rainyLight.ActivateRainEffect();
                stormyLight.DeactivateStormEffect();
                stormyLight.DeactivateStormWindZone();
                snowyLight.DeactivateSnowEffect();
                SoundManager.Instance.PlayMusic(1);
                break;
            case "태풍":
                sunnyLight.DeactivateSunnyLight();
                rainyLight.ActivateCloudyLight();
                rainyLight.DeactivateRainEffect();
                stormyLight.ActivateStormEffect();
                stormyLight.ActivateStormWindZone();
                snowyLight.DeactivateSnowEffect();
                SoundManager.Instance.PlayMusic(2);
                break;
            case "눈":
                sunnyLight.DeactivateSunnyLight();
                rainyLight.ActivateCloudyLight();
                rainyLight.DeactivateRainEffect();
                stormyLight.DeactivateStormEffect();
                stormyLight.DeactivateStormWindZone();
                snowyLight.ActivateSnowEffect();
                SoundManager.Instance.PlayMusic(3);
                break;
        }
    }

    public void OnNextDay()
    {
        if (date >= weatherArr.Length - 1) return;
        date++;
        plantsLevelChange.CheckDate();
        dateUI.IncreaseDateCount();
        WeatherTextUpdate();
        WeatherLightUpdate();
    }
    public int GetDateCount()
    {
        return date;
    }
}
