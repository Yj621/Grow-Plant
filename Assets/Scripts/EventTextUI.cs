using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventTextUI : MonoBehaviour
{
    public TextMeshProUGUI dayText;
    private int dateCount = 0;
    public WeatherUI weatherUI;

    void Start()
    {
        OpenEvent();
    }

    void Update()
    {

    }
    public void OpenEvent()
    {
        string filePath = "Assets/Scripts/event.txt";
        string[] textLines = System.IO.File.ReadAllLines(filePath);

        dateCount = weatherUI.GetDateCount();
        string textValue = textLines[dateCount];



    }
}
