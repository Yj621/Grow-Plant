using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainyLight : MonoBehaviour
{
    public GameObject rainyLight;

    public void ActivateRainyLight() //�� ���� ���� ���� Ȱ��ȭ
    {
        
        rainyLight.SetActive(true);
    }

    public void DeactivateRainyLight()//�� ���� ���� ���� ��Ȱ��ȭ
    {
        rainyLight.SetActive(false);
    }
}
