using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsLevelChange : MonoBehaviour
{
    int dateCount = 0;
    int condPoint = 0;
    public DateUI dateUI;
    public ConditionUI conditionUI;

    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;
    public GameObject level6;

    public GameObject sickLevel2;
    public GameObject sickLevel3;
    public GameObject sickLevel4;
    public GameObject sickLevel5;
    public GameObject sickLevel6;

    private int currentLevel = 1; // 현재 활성화된 레벨 번호

    void Start()
    {        
        level1.SetActive(true);
        level2.SetActive(false);
        level3.SetActive(false);
        level4.SetActive(false);
        level5.SetActive(false);
        level6.SetActive(false);

        currentLevel = 1; // 초기 레벨 설정
    }

    public int GetCurrentLevel()
    {
        return currentLevel; // 현재 레벨 번호 반환
    }

    public void CheckDate()
    {
        dateCount = dateUI.dateCount + 1;
        condPoint = ConditionUI.conditionPoint;

        if (dateCount >= 0 && dateCount < 7)        //Level_1
        {
            SetActiveLevel(1);
        }
        else if (dateCount >= 7 && dateCount < 11)   //Level_2
        {
            if (condPoint > 40)
            {                
                SetActiveLevel(2);
            }
            else
            {
                SetActiveSickLevel(2);
            }
        }
        else if (dateCount >= 11 && dateCount < 22)  //Level_3
        {
            if (condPoint > 40)
            {
                SetActiveLevel(3);
            }
            else
            {
                SetActiveSickLevel(3);
            }
        }
        else if (dateCount >= 22 && dateCount < 28) //Level_4
        {
            if (condPoint > 40)
            {
                SetActiveLevel(4);
            }
            else
            {
                SetActiveSickLevel(4);
            }
        }
        else if (dateCount >= 28 && dateCount < 29) //Level_5
        {
            if (condPoint > 40)
            {
                SetActiveLevel(5);
            }
            else
            {
                SetActiveSickLevel(5);
            }
        }
        else if (dateCount >= 29 && dateCount < 30) //Level_6
        {
            if (condPoint > 40)
            {
                SetActiveLevel(6);
            }
            else
            {
                SetActiveSickLevel(6);
            }
        }
    }

    private void SetActiveLevel(int level)
    {
        // 모든 레벨과 병든 상태 비활성화
        level1.SetActive(false);
        level2.SetActive(false);
        level3.SetActive(false);
        level4.SetActive(false);
        level5.SetActive(false);
        level6.SetActive(false);
        sickLevel2.SetActive(false);
        sickLevel3.SetActive(false);
        sickLevel4.SetActive(false);
        sickLevel5.SetActive(false);
        sickLevel6.SetActive(false);

        // 현재 레벨 활성화
        currentLevel = level; // 현재 레벨 업데이트
        switch (level)
        {
            case 1: level1.SetActive(true); break;
            case 2: level2.SetActive(true); break;
            case 3: level3.SetActive(true); break;
            case 4: level4.SetActive(true); break;
            case 5: level5.SetActive(true); break;
            case 6: level6.SetActive(true); break;
        }
    }

    private void SetActiveSickLevel(int level)
    {
        // 모든 레벨과 병든 상태 비활성화
        level1.SetActive(false);
        level2.SetActive(false);
        level3.SetActive(false);
        level4.SetActive(false);
        level5.SetActive(false);
        level6.SetActive(false);
        sickLevel2.SetActive(false);
        sickLevel3.SetActive(false);
        sickLevel4.SetActive(false);
        sickLevel5.SetActive(false);
        sickLevel6.SetActive(false);

        // 병든 상태 레벨 활성화
        currentLevel = level; // 병든 상태도 해당 레벨로 간주
        switch (level)
        {
            case 2: sickLevel2.SetActive(true); break;
            case 3: sickLevel3.SetActive(true); break;
            case 4: sickLevel4.SetActive(true); break;
            case 5: sickLevel5.SetActive(true); break;
            case 6: sickLevel6.SetActive(true); break;
        }
    }
}
