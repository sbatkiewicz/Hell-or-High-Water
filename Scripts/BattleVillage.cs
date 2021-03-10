using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleVillage : Menu
{

    public GameObject BattleBox;

    void Update()
    {

        if (toggleVar == 1)
        {
            MenuBox.SetActive(true);
        }
        else
        {
            MenuBox.SetActive(false);
        }
    }

    public void NewExitMenu()
    {
        toggleVar = 0;
        closeSound.Play();

    }


    public void Battle()
    {
        closeSound.Play();
        BattleBox.GetComponent<BattleSimulation>().toggleVar = 1;
        toggleVar = 0;
    }



}
