using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantStateUI : MonoBehaviour
{

    public PlantsLevelChange plantsLevelChange;
    [SerializeField] private TextMeshProUGUI levelAmountText;
    [SerializeField] private Slider hpSlider;
    void Start()
    {

    }

    private void OnEnable()
    {
        int currentLevel = plantsLevelChange.GetCurrentLevel();
        Debug.Log($"currentLevel : {currentLevel}");
        levelAmountText.text = currentLevel.ToString();
    }

    void Update()
    {

    }
}
