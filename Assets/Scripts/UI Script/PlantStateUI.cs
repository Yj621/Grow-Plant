using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantStateUI : Singleton<PlantStateUI>
{
    public PlantsLevelChange plantsLevelChange;
    [SerializeField] private TextMeshProUGUI levelAmountText;
    [SerializeField] private TextMeshProUGUI plantNameText;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private TMP_InputField plantName;

    public Slider HPSlider => hpSlider; //hpslider Getter

    void Start()
    {
        TouchManager.Instance.isPanelActive = true;
    }

    public void StateUpdate()
    {
        int currentLevel = plantsLevelChange.GetCurrentLevel();
        Debug.Log($"currentLevel : {currentLevel}");
        levelAmountText.text = currentLevel.ToString();
        plantNameText.text = plantName.text;
    }

   public void OnClickNameConfirm()
    {
        plantNameText.text = plantName.text;
        TouchManager.Instance.isPanelActive = false;
    }

    void Update()
    {

    }

    

}
