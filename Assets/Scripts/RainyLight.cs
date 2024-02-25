using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainyLight : MonoBehaviour
{
    public GameObject rainyLight;

    public void ActivateRainyLight() //비 오는 날의 조명 활성화
    {
        
        rainyLight.SetActive(true);
    }

    public void DeactivateRainyLight()//비 오는 날의 조명 비활성화
    {
        rainyLight.SetActive(false);
    }
}
