using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventTextUI : MonoBehaviour
{
    public TextMeshProUGUI eventText;
    private int dateCount = 0;
    public WeatherUI weatherUI;

    void Start()
    {
        OpenEvent();
    }

    void Update()
    {

    }
    void OpenEvent()
    {
        string filePath = "Assets/TextFiles/event.txt";
        string[] textLines = System.IO.File.ReadAllLines(filePath);

        dateCount = weatherUI.GetDateCount();
        string textValue = textLines[dateCount];

        eventText.text = textValue;

    }
}
