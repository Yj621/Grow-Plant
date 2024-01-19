using System.Collections;
using UnityEngine;
using UnityEngine.UI; // UI ���ӽ����̽� �߰�
using System.IO;
using TMPro;

public class WeatherUI : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI; // TextMeshProUGUI�� ����ϴ� ���
    int date = 0; // �̺�Ʈ�� �ϳ��� �ѱ� ������ date++

    void Start()
    {       
        string filePath = "Assets/Scripts/weather.txt";
        string[] textLines = System.IO.File.ReadAllLines(filePath);

        string textValue = textLines[date];

        if (textMeshProUGUI != null)
        {
            textMeshProUGUI.text += textValue;
        }
        else
        {
            Debug.LogError("TextMeshProUGUI�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }
    public int GetDateCount()
    {
        return date;
    }
}
