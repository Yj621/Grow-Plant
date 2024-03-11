using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherChange : MonoBehaviour
{
    // ��ī�̹ڽ� ��Ƽ����
    public Material skyboxMaterial;

    void Update()
    {
        // ��Ƽ���� ���
        RenderSettings.skybox = skyboxMaterial;
        //RenderSettings.skybox.SetFloat("_Rotation", Time.time * 0.5f);
    }
}