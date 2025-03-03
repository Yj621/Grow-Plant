using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource[] backgroundMusic;
    public AudioSource[] arrAudio;
    public GameObject turnTableEffect;
    public GameObject SoundPanel;
    public Slider musicSlider;
    public Slider soundSlider;
    public int currentIndex;

    private bool isMusicPlaying = true;
    public bool isMusicOn = true; 
    private bool[] soundStates;


    void Awake()
    {

        isMusicOn = true;
        // 처음에 음악 재생
        if (isMusicOn) { backgroundMusic[currentIndex].Play(); }
    }

    void Start()
    {

        // 효과음 상태 초기화
        soundStates = new bool[arrAudio.Length];
        for (int i = 0; i < arrAudio.Length; i++)
        {
            soundStates[i] = true; // 기본적으로 모든 효과음을 켭니다.
        }
    }

    void Update()
    {
    }

    public void IsOn()
    {
        Debug.Log("Ison () lastMusicState: "+FindAnyObjectByType<GameManager>().lastMusicState);

        isMusicOn = FindAnyObjectByType<GameManager>().lastMusicState;

        Debug.Log("isMusicOn : " + isMusicOn);
        if (isMusicOn) 
        { 
            PlayMusic(); 
        }
        else
        {
            StopMusic();
        }
    }

    // 모든 음악 정지를 처리하는 함수
    // public void StopAllMusic()
    // {
    //     foreach (var musicSource in backgroundMusic)
    //     {
    //         musicSource.Stop();
    //     }

    //     isMusicOn = false;
    //     // 모든 음악 재생 상태 업데이트
    //     isMusicPlaying = false;
    // }

    public void OnPanelSound()
    {
        SoundPanel.SetActive(true);
        TouchManager.Instance.isPanelActive = true;
        Sound(1); // 패널 온 효과음 재생
    }

    public void OffPanelSound()
    {
        SoundPanel.SetActive(false);
        TouchManager.Instance.isPanelActive = false;
        Sound(2); // 패널 오프 효과음 재생
    }

    // 음악 재생을 처리하는 함수
    public void PlayMusic()
    {
        if (!isMusicPlaying)
        {
            // 음악 재생
            backgroundMusic[currentIndex].Play();
            turnTableEffect.SetActive(true);
            isMusicOn = true;
        }
        // 음악 재생 상태 업데이트
        isMusicPlaying = true;
    }

    // 음악 정지를 처리하는 함수
    public void StopMusic()
    {
        if (isMusicPlaying)
        {
            // 음악 정지
            backgroundMusic[currentIndex].Stop();
            // 턴테이블 이펙트 없애기
            turnTableEffect.SetActive(false);
            isMusicOn = false;
        }
        // 음악 재생 상태 업데이트
        isMusicPlaying = false;
    }

    public void UpdateMusicVolume()
    {
        // 현재 재생 중인 배경 음악의 볼륨을 조절
        foreach (AudioSource musicSource in backgroundMusic)
        {
            musicSource.volume = musicSlider.value;
        }
    }

    public void UpdateEffectVolume()
    {
        // 효과음 볼륨 업데이트
        foreach (AudioSource audioSource in arrAudio)
        {
            audioSource.volume = soundSlider.value;
        }
    }

    public void Sound(int arr)
    {
        // 소리가 켜져 있는지 확인
        if (soundStates[arr])
        {
            arrAudio[arr].Play();
        }
    }

    // 모든 효과음 켜기
    public void TurnOnAllSounds()
    {
        for (int i = 0; i < arrAudio.Length; i++)
        {
            soundStates[i] = true;
        }
    }

    // 모든 효과음 끄기
    public void TurnOffAllSounds()
    {
        for (int i = 0; i < arrAudio.Length; i++)
        {
            soundStates[i] = false;
        }
    }

    // 효과음 볼륨 일괄 업데이트
    public void UpdateEffectsVolume(float volume)
    {
        foreach (AudioSource audioSource in arrAudio)
        {
            audioSource.volume = volume;
        }
    }
}
