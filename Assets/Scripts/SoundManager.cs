using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : Singleton<SoundManager>
{
    [Header("배경음악 트랙들")]
    public AudioSource[] backgroundMusic;
    [Header("효과음 클립들")]
    public AudioSource[] arrAudio;
    [Header("턴테이블 이펙트")]
    public GameObject turnTableEffect;
    [Header("사운드 설정 패널")]
    public GameObject soundPanel;
    [Header("볼륨 슬라이더")]
    public Slider musicSlider;
    public Slider soundSlider;

    [HideInInspector] public int currentIndex = 0;     // 현재 재생 중인 배경음악 인덱스
    [HideInInspector] public bool isMusicOn = true;    // 전체 음악 온/오프 플래그
    [HideInInspector] public bool isEffectsOn = true;  // 전체 효과음 On/Off 플래그

    private bool[] soundStates;    // 개별 효과음 온/오프
    private bool isMusicPlaying = false;

    void Awake()
    {
        // 게임 시작 시 음악이 켜져 있으면 초기 트랙 재생
        if (isMusicOn)
            PlayMusic(currentIndex);
    }

    void Start()
    {
        // 효과음 상태 초기화 (모두 켬)
        soundStates = new bool[arrAudio.Length];
        for (int i = 0; i < soundStates.Length; i++)
            soundStates[i] = true;

        // 슬라이더 이벤트 연결
        musicSlider.onValueChanged.AddListener(UpdateMusicVolume);
        soundSlider.onValueChanged.AddListener(UpdateEffectsVolume);

        // 초기 볼륨 세팅
        UpdateMusicVolume(musicSlider.value);
        UpdateEffectsVolume(soundSlider.value);
    }

    /// <summary>
    /// 음악 전체 On/Off 토글
    /// </summary>
    public void ToggleMusic(bool on)
    {
        isMusicOn = on;
        if (isMusicOn)
        {
            PlayMusic(currentIndex);
            PlayEffect(0);
        }
        else
            StopMusic();
    }

    /// <summary>
    /// 효과음 전체 On/Off 토글
    /// </summary>
    public void ToggleEffects(bool on)
    {
        isEffectsOn = on;
        for (int i = 0; i < soundStates.Length; i++)
            soundStates[i] = on;
    }

    /// <summary>
    /// 배경음악 재생(인덱스 지정)
    /// </summary>
    public void PlayMusic(int index)
    {
        if (!isMusicOn)
            return;

        currentIndex = index;

        for (int i = 0; i < backgroundMusic.Length; i++)
        {
            if (i == index)
            {
                if (!backgroundMusic[i].isPlaying)
                {
                    backgroundMusic[i].Play();
                    turnTableEffect.SetActive(true);
                }
            }
            else
            {
                if (backgroundMusic[i].isPlaying)
                    backgroundMusic[i].Stop();
            }
        }
        isMusicPlaying = true;
    }

    /// <summary>
    /// 배경음악 완전 정지
    /// </summary>
    public void StopMusic()
    {
        for (int i = 0; i < backgroundMusic.Length; i++)
            if (backgroundMusic[i].isPlaying)
                backgroundMusic[i].Stop();

        turnTableEffect.SetActive(false);
        isMusicPlaying = false;
    }

    /// <summary>
    /// 배경음악 볼륨 변경 (0~1)
    /// </summary>
    public void UpdateMusicVolume(float vol)
    {
        foreach (var src in backgroundMusic)
            src.volume = vol;
    }

    /// <summary>
    /// 효과음 볼륨 변경 (0~1)
    /// </summary>
    public void UpdateEffectsVolume(float vol)
    {
        foreach (var src in arrAudio)
            src.volume = vol;
    }

    /// <summary>
    /// 특정 효과음 재생
    /// </summary>
    public void PlayEffect(int idx)
    {
        if (idx < 0 || idx >= arrAudio.Length) return;
        if (soundStates[idx] && arrAudio[idx] != null)
            arrAudio[idx].Play();
    }


    /// <summary>
    /// 사운드 설정 패널 열기 (효과음 idx=1)
    /// </summary>
    public void ShowSoundPanel()
    {
        soundPanel.SetActive(true);
        TouchManager.Instance.isPanelActive = true;
        PlayEffect(1);
    }

    /// <summary>
    /// 사운드 설정 패널 닫기 (효과음 idx=2)
    /// </summary>
    public void HideSoundPanel()
    {
        soundPanel.SetActive(false);
        TouchManager.Instance.isPanelActive = false;
        PlayEffect(2);
    }
}
