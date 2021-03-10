using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BattleSimulation : MonoBehaviour
{
    public PlayerResources PlayerManager;
    public int toggleVar = 0;
    public GameObject MenuBox;

    public GameObject WinScriptHolder;
    public GameObject LoseScriptHolder;
    public bool PlayerWins = false;

    CrewMember sword = new CrewMember("sword", 5);
    CrewMember axe = new CrewMember("axe", 8);
    CrewMember gunner = new CrewMember("gunner", 6);
    CrewMember looter = new CrewMember("looter", 7);

    public Text swordAmount;
    public Text axeAmount;
    public Text gunnerAmount;
    public Text looterAmount;

    private int costToBattle = 2;
    public Text BattleCost;
    public int maxPirates;
    public float attackPower = 0;
    public float defencePower = 0;
    public int enemyAttack = 35;
    public int enemyDefence = 0;

    private string loss = " ";
    private string reward = " ";
     public Text lossText;
     public Text rewardsText;


    void Awake()
    {
        PlayerManager = GameObject.Find("PlayerManager").GetComponentInChildren<PlayerResources>();
        maxPirates = PlayerManager.GetMaxCrew();
    }

    void Update()
    {
        UpdateGUI();
        
        if (toggleVar == 1)
        {

            MenuBox.SetActive(true);
        }
        else
        {
            MenuBox.SetActive(false);
        }
    }

    public void UpdateGUI()
    {
        swordAmount.text = sword.GetAmount().ToString();
        axeAmount.text = axe.GetAmount().ToString();
        gunnerAmount.text = gunner.GetAmount().ToString();
        looterAmount.text = looter.GetAmount().ToString();

        BattleCost.text = "x" + (costToBattle).ToString();
        lossText.text = loss;
        rewardsText.text = reward;
    }

    public void DoFight()
    {
        StartCoroutine("CommenceBattle");

    }

    public string PrintLossText(int one, int two, int three, int four)
    {
        loss = "You Lost: \n ";

        if (one >= 1)
        {
            loss += one + "  Swordsmen. \n";
        }

        if (two >= 1)
        {
            loss += two + "  Axemen. \n";
        }

        if (three >= 1)
        {
            loss += three + "  Gunmen. \n";
        }

        if (four >= 1)
        {
            loss += four + "  Looters. \n";
        }

        return loss;

    }

    public string PrintRewardsText()
    {
        int goldEarned = (20  + (looter.GetAmount() * 4));
        reward = "Rewards: \n" + goldEarned + " Gold\n" + "3 Food";
        PlayerManager.SetFood(PlayerManager.GetFood() + 3);
        PlayerManager.SetGold(PlayerManager.GetGold() + (int)goldEarned);
        return reward;
    }

    public void RevisedButtonInc(string name)
    {
        if (sword.GetAmount() + axe.GetAmount() + gunner.GetAmount() + looter.GetAmount() < maxPirates)
        {
            Debug.Log("You Incremented.");
            if (name == "sword")
            {
                if (sword.GetAmount() + 1 <= PlayerManager.GetSword())
                    sword.SetAmount(sword.GetAmount() + 1);
            }

            if (name == "axe")
            {
                if (axe.GetAmount() + 1 <= PlayerManager.GetAxe())
                    axe.SetAmount(axe.GetAmount() + 1);
            }

            if (name == "gunner")
            {
                if (gunner.GetAmount() + 1 <= PlayerManager.GetGunner())
                    gunner.SetAmount(gunner.GetAmount() + 1);
            }

            if (name == "looter")
            {
                if (looter.GetAmount() + 1 <= PlayerManager.GetLooter())
                    looter.SetAmount(looter.GetAmount() + 1);
            }
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

    public IEnumerator CommenceBattle()
    {
        if (PlayerManager.GetFood() >= costToBattle)
        {
            PlayerManager.SetFood(PlayerManager.GetFood() - costToBattle);
            toggleVar = 0;
            enemyAttack *= 1 + ((PlayerManager.GetLevel() * 2) / 10);
            enemyDefence = 40 + (PlayerManager.GetLevel() * 10);

            int amountOfFirstLost = 0;
            int amountOfSecondLost = 0;
            int amountOfThirdLost = 0;
            int amountOfFourthLost = 0;

            attackPower = (sword.GetAmount() * 5) + (axe.GetAmount() * 8) + (gunner.GetAmount() * 6) + (looter.GetAmount() * 2);
            defencePower = (sword.GetAmount() * 5) + (axe.GetAmount() * 2) + (gunner.GetAmount() * 4) + (looter.GetAmount() * 2);


            if (attackPower >= enemyDefence && defencePower >= enemyAttack) // Then Player Wins the Fight! 
            {

                int deaths = (int)((enemyAttack / defencePower / 2) * 10);
                Debug.Log(deaths + " pirates must die.");

                for (int x = 0; x < deaths; x++)
                {


                    int killing = Random.Range(1, 5);

                    if (killing == 1 && sword.GetAmount() >= 1)
                    {
                        amountOfFirstLost++;
                        PlayerManager.SetCrewMate("sword", PlayerManager.GetSword() - 1);
                        sword.SetAmount(sword.GetAmount() - 1);

                        Debug.Log(" A swordsman died.");
                    }

                    else if (killing == 2 && axe.GetAmount() >= 1)
                    {
                        amountOfSecondLost++;
                        PlayerManager.SetCrewMate("axe", PlayerManager.GetAxe() - 1);
                        axe.SetAmount(axe.GetAmount() - 1);

                        Debug.Log(" An axeman died.");
                    }

                    else if (killing == 3 && gunner.GetAmount() >= 1)
                    {
                        amountOfThirdLost++;
                        PlayerManager.SetCrewMate("gunner", PlayerManager.GetGunner() - 1);
                        gunner.SetAmount(gunner.GetAmount() - 1);

                        Debug.Log(" A gunner died.");
                    }

                    else if (killing == 4 && looter.GetAmount() >= 1)
                    {
                        amountOfFourthLost++;
                        PlayerManager.SetCrewMate("looter", PlayerManager.GetLooter() - 1);
                        looter.SetAmount(looter.GetAmount() - 1);

                        Debug.Log(" A looter died.");
                    }
                    else
                    {
                        Debug.Log("Index out of range.");
                        x--;
                    }
                }
                PlayerWins = true;
                toggleVar = 0;
                PrintLossText(amountOfFirstLost, amountOfSecondLost, amountOfThirdLost, amountOfFourthLost);
                PrintRewardsText();
                WinScriptHolder.GetComponent<SimpleMenu>().toggleVar = 1;
                PlayerManager.SetLevel(PlayerManager.GetLevel() + 1);
                yield return null;
                //Lots more can happen here.
            }
            else
            {
                PlayerManager.SetCrewMate("sword", PlayerManager.GetSword() - sword.GetAmount());
                PlayerManager.SetCrewMate("axe", PlayerManager.GetAxe() - axe.GetAmount());
                PlayerManager.SetCrewMate("gunner", PlayerManager.GetGunner() - gunner.GetAmount());
                PlayerManager.SetCrewMate("looter", PlayerManager.GetLooter() - looter.GetAmount());
                Debug.Log("You lost.");
                toggleVar = 0;
                LoseScriptHolder.GetComponent<SimpleMenu>().toggleVar = 1;
                PlayerManager.SetGold(PlayerManager.GetGold() / 2);
                yield return null;
            }

            Debug.Log("Finished Battle.");
        }

    }//Method



    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            toggleVar = 2;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        sword.SetAmount(0);                              //These values may need to be reset somewhere else. 
        axe.SetAmount(0);
        gunner.SetAmount(0);
        looter.SetAmount(0);
    }

    public void ExitMenu()
    {
        toggleVar = 0;
        Debug.Log("You've pressed the exit button!");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        sword.SetAmount(0);                              //These values may need to be reset somewhere else. 
        axe.SetAmount(0);
        gunner.SetAmount(0);
        looter.SetAmount(0);
    }

}//End
