using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic;

    // 버튼 클릭 상태를 나타내는 변수
    private bool isMusicPlaying = true;
    // public Image buttonImage;

    // public Sprite playSprite;
    // public Sprite pauseSprite;
    public GameObject turnTableEffect;
    public GameObject SoundPanel;
    TouchManager touchManager;
    void Start()
    {
        touchManager = FindAnyObjectByType<TouchManager>();
        // 처음에 음악 재생
        backgroundMusic.Play();
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
            backgroundMusic.Play();
            // buttonImage.sprite = playSprite; // 재생 이미지로 변경
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
            backgroundMusic.Stop();
            // buttonImage.sprite = pauseSprite; // 일시정지 이미지로 변경
            turnTableEffect.SetActive(false);
        }

        // 음악 재생 상태 업데이트
        isMusicPlaying = false;
    }
}