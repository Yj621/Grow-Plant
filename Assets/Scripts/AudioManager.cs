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
    public int currentIndex;
    public bool isOn;

    /*
    0 배경음악
    1 비
    2 태풍
    3 눈
    4 흐림
    5 찐엔딩
    6 꽃엔딩
    7 인스타엔딩
    */
    void Awake()
    {
        isOn = true;
        Debug.Log("isOn : "+isOn);
        // 처음에 음악 재생
        if (isOn) { backgroundMusic[currentIndex].Play(); }
    }
    void Start()
    {
    }

    void Update()
    {

    }
    public void IsOn()
    {
        isOn = FindAnyObjectByType<GameManager>().lastMusicState;
    }
    // 모든 음악 정지를 처리하는 함수
    public void StopAllMusic()
    {
        foreach (var musicSource in backgroundMusic)
        {
            musicSource.Stop();
        }

        isOn = false;
        // 모든 음악 재생 상태 업데이트
        isMusicPlaying = false;
    }

    public void OnPanelSound()
    {
        SoundPanel.SetActive(true);
        TouchManager.Instance.isPanelActive = true;
    }

    public void OffPanelSound()
    {
        SoundPanel.SetActive(false);
        TouchManager.Instance.isPanelActive = false;
    }

    // 음악 재생을 처리하는 함수
    public void PlayMusic()
    {
        if (!isMusicPlaying)
        {
            // 음악 재생
            backgroundMusic[currentIndex].Play();
            turnTableEffect.SetActive(true);
            isOn = true;
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
            isOn = false;
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
        // SoundManager에서 효과음 볼륨 업데이트
        SoundManager.Instance.UpdateEffectsVolume(soundSlider.value);
    }

    public void TurnOffAndOn()  //죽은 뒤 die_popup이 뜨고 confirm을 누르면 노래를 껐다 킴
    {
        StopMusic();
        if(isOn){PlayMusic();}
    }
}
