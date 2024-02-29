using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic;

    // 버튼 클릭 상태를 나타내는 변수
    private bool isMusicPlaying = true;
    public Image buttonImage;

    public Sprite playSprite;
    public Sprite pauseSprite;
    public GameObject turnTableEffect;
    void Start()
    {
        // 처음에 음악 재생
        backgroundMusic.Play();
    }

    // 버튼 클릭 이벤트에 연결될 함수
    public void ToggleMusic()
    {
        if (isMusicPlaying)
        {
            // 음악 일시정지
            backgroundMusic.Pause();
            buttonImage.sprite = pauseSprite; // 재생 이미지로 변경
            turnTableEffect.SetActive(false);
        }
        else
        {
            // 일시정지된 음악 재생
            backgroundMusic.UnPause();
            buttonImage.sprite = playSprite; // 일시정지 이미지로 변경
            turnTableEffect.SetActive(true);
        }

        // 버튼 클릭 상태 업데이트
        isMusicPlaying = !isMusicPlaying;
    }
}
