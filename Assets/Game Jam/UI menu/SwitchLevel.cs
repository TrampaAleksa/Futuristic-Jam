using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLevel : MonoBehaviour
{
    public StartMenu startMenu;
    public GameObject anim;
    public ChooseLevel chooseLevel;

    public void Switch(bool isChoose)
    {
        chooseLevel.gameObject.SetActive(isChoose);
        anim.gameObject.SetActive(!isChoose);
        startMenu.gameObject.SetActive(!isChoose);
    }
}
