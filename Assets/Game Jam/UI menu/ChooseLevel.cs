using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseLevel : MonoBehaviour
{
    public List<Button> buttons;

    public void ChangeLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    private void OnEnable()
    {
        int maxlevel=LevelChanger.Instance.GetIndexOfLevel();

        if (maxlevel == 0)
            buttons[0].interactable = true;
        for(int i=0;i<maxlevel;i++)
        {
            buttons[i].interactable = true;
        }
            
    }


}
