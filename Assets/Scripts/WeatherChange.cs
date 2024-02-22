using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherChange : MonoBehaviour
{
    // 스카이박스 머티리얼
    public Material skyboxMaterial;

    void Update()
    {
        // 머티리얼 등록
        RenderSettings.skybox = skyboxMaterial;
    }
}