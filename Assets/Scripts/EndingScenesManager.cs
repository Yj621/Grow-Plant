using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScenesManager : MonoBehaviour
{
    public Image endingScene;       //�⺻ ����
    //public Image snsEndingScene;    //������ �ν�Ÿ �ӽñ�..
    public Image hiddenEndingScene; //�׳࿡�� ���� �ش�

    Image[] endingSceneArr = new Image[3];

    void Start()
    {
        endingSceneArr = new Image[] { endingScene, hiddenEndingScene };
    }

    public void printEndingScene()
    {
        endingScene.gameObject.SetActive(true);
    }
    public void printHiddenEndingScene()
    {
        hiddenEndingScene.gameObject.SetActive(true);
    }

}
