using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] backgroundMusic;

    private bool isMusicPlaying = true;
    public GameObject turnTableEffect;
    public GameObject SoundPanel;
    public Slider musicSlider;
    public Slider soundSlider;
    public int currentIndex = 0;

    TouchManager touchManager;
    SoundManager soundManager;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        touchManager = FindObjectOfType<TouchManager>(); 
        
        // 처음에 음악 재생
        backgroundMusic[currentIndex].Play();
    }

    void Update()
    {
    }

    public void OnPanelSound()
    {
        SoundPanel.SetActive(true);
        touchManager.isPanelActive = true;
    }

    public void OffPanelSound()
    {
        SoundPanel.SetActive(false);
        touchManager.isPanelActive = false;
    }

    // 음악 재생을 처리하는 함수
    public void PlayMusic()
    {
        if (!isMusicPlaying)
        {
            // 음악 재생
            backgroundMusic[currentIndex].Play();
            turnTableEffect.SetActive(true);
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
            //턴테이블 이펙트 없애기
            turnTableEffect.SetActive(false);
        }

        // 음악 재생 상태 업데이트
        isMusicPlaying = false;
    }

    public void UpdateMusicVolume(float volume)
    {
        foreach (AudioSource musicSource in backgroundMusic)
        {
            musicSource.volume = volume;
        }
    }
    public void UpdateEffectVolume(float volume)
    {
        // 모든 효과음의 볼륨을 주어진 값으로 설정합니다.
        foreach (AudioSource audioSource in soundManager.arrAudio)
        {
            audioSource.volume = volume;
        }
    }

}
