using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource[] arrAudio;
    void Start()
    {
        
    }
    /*
    0 클릭(버튼)
    1 패널온
    2 패널 오프
    3 식물 자라기
    4 식물 시들기
    5 죽기
    */
    public void Sound(int arr) 
    {
        arrAudio[arr].Play();
    }
}
