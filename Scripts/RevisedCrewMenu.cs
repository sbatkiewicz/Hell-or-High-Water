using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RevisedCrewMenu : Menu
{
    CrewMember sword = new CrewMember("sword", 6);
    CrewMember axe = new CrewMember("axe", 5);
    CrewMember gunner = new CrewMember("gunner", 7);
    CrewMember looter = new CrewMember("looter", 7);

    public Text miscPrice1;
    public Text miscAmount1;
    public Text miscPrice2;
    public Text miscAmount2;
    public Text miscPrice3;
    public Text miscAmount3;
    public Text miscPrice4;
    public Text miscAmount4;

    public int totalCost;
    public Text CostText;

    private void Awake()
    {
        showMenuScript = DialogueBox.GetComponentInChildren<DialogueScript>();
        PlayerManager = GameObject.Find("PlayerManager").GetComponentInChildren<PlayerResources>();
    }


    void Update()
    {
        totalCost = (sword.GetAmount() * sword.GetPrice()) + (axe.GetAmount() * axe.GetPrice()) + (gunner.GetAmount() * gunner.GetPrice()) + (looter.GetAmount() * looter.GetPrice());
        UpdateGUI();
        if (toggleVar == 1)
        {
            DialogueBox.SetActive(true);
            showMenuScript.PrintText();
            if (showMenuScript.isDone == true)
            {
                MenuBox.SetActive(true);
                ShowMenu();

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

            }

        }
        else
        {
            DialogueBox.SetActive(false);
            MenuBox.SetActive(false);
        }
    }

    IEnumerator ShowMenu()
    {

        yield return new WaitForSeconds(.5f);
        DialogueBox.SetActive(false);

    }

    public void UpdateGUI()
    {
        miscPrice1.text = sword.GetPrice().ToString();
        miscPrice2.text = axe.GetPrice().ToString();
        miscPrice3.text = gunner.GetPrice().ToString();
        miscPrice4.text = looter.GetPrice().ToString();

        miscAmount1.text = sword.GetAmount().ToString();
        miscAmount2.text = axe.GetAmount().ToString();
        miscAmount3.text = gunner.GetAmount().ToString();
        miscAmount4.text = looter.GetAmount().ToString();

        CostText.text = "x" + (totalCost).ToString();
    }


    public void Purchase()
    {

        if (PlayerManager.GetGold() >= totalCost)
        {
            PlayerManager.SetGold(PlayerManager.GetGold() - totalCost);

            PlayerManager.SetCrewMate("sword", PlayerManager.GetSword() + sword.GetAmount());
            PlayerManager.SetCrewMate("axe", PlayerManager.GetAxe() + axe.GetAmount());
            PlayerManager.SetCrewMate("gunner", PlayerManager.GetGunner() + gunner.GetAmount());
            PlayerManager.SetCrewMate("looter", PlayerManager.GetLooter() + looter.GetAmount());

            toggleVar = 0;
            sword.SetAmount(0);
            axe.SetAmount(0);
            gunner.SetAmount(0);
            looter.SetAmount(0);
            showMenuScript.isDone = false;
            showMenuScript.printingIP = false;
            goldSound.Play();

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            camera.enabled = true;
        }//IfPlayerCanAfford


    }

    public void RevisedButtonInc(string name)                         
    {

        if (name == "sword")
        {
            sword.SetAmount(sword.GetAmount() + 1);
        }

        if (name == "axe")
        {
            axe.SetAmount(axe.GetAmount() + 1);
        }

        if (name == "gunner")
        {
            gunner.SetAmount(gunner.GetAmount() + 1);
        }

        if (name == "looter")
        {
            looter.SetAmount(looter.GetAmount() + 1);
        }

    }

    public void RevisedButtonDec(string name)                         
    {
        if (name == "sword")
        {
            sword.SetAmount(sword.GetAmount() - 1);
        }

        if (name == "axe")
        {
            axe.SetAmount(axe.GetAmount() - 1);
        }

        if (name == "gunner")
        {
            gunner.SetAmount(gunner.GetAmount() - 1);
        }

        if (name == "looter")
        {
            looter.SetAmount(looter.GetAmount() - 1);
        }

    }


}
