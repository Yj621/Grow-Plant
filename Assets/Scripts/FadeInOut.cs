using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public Image image; // 이미지 컴포넌트를 참조할 변수
    public float fadeDuration = 1.0f; // 투명도가 서서히 변하는 데 걸리는 시간 (초)
    public float initialAlpha = 0f; // 초기 투명도 값
    public float targetAlpha = 1.0f; // 최종 투명도 값

    private float currentAlpha; // 현재 투명도 값
    private bool isFading = false; // 페이드 중인지 여부

    void Start()
    {
        image = GetComponent<Image>(); // 현재 게임 오브젝트의 Image 컴포넌트를 가져옴
        currentAlpha = initialAlpha; // 초기 투명도 값으로 설정
        Color startColor = image.color;
        startColor.a = initialAlpha;
        image.color = startColor;
    }

    void Update()
    {
    }

    // 투명도를 서서히 변화시키는 코루틴
    public IEnumerator FadeAlpha()
    {
        isFading = true; // 페이드 중임을 표시

        // 페이드 인
        while (currentAlpha < targetAlpha)
        {
            currentAlpha += Time.deltaTime / fadeDuration;
            Color newColor = image.color;
            newColor.a = currentAlpha;
            image.color = newColor;
            yield return null;
        }

        // 대기
        yield return new WaitForSeconds(1.0f);

        // 페이드 아웃
        while (currentAlpha > initialAlpha)
        {
            currentAlpha -= Time.deltaTime / fadeDuration;
            Color newColor = image.color;
            newColor.a = currentAlpha;
            image.color = newColor;
            yield return null;
        }

        isFading = false; // 페이드 종료
    }
}