using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] backgroundMusic;

    private bool isMusicPlaying = true;
    private float musicVolume = 1f; // 음악 볼륨
    private float soundVolume = 1f; // 효과음 볼륨
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
        // 볼륨 조절
        foreach (var audio in backgroundMusic)
        {
            audio.volume = musicVolume;
        }

        // SoundManager에서 효과음 배열을 가져와서 볼륨을 조절
        if (soundManager != null)
        {
            foreach (var audio in soundManager.arrAudio)
            {
                audio.volume = soundVolume;
            }
        }
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

    // 음악 볼륨 조절 함수
    public void MusicVolume(float volume)
    {
        musicVolume = volume;
    }

    // 효과음 볼륨 조절 함수
    public void EffectVolume(float volume)
    {
        soundVolume = volume;
    }
}
