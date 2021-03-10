using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    private int player_Level = 0;
    private int player_choice = 0;
    private int player_sex = 0;

    public int gold = 0;
    private int banked_gold = 0;
    public int food = 0;

    private int maxCrew = 10;
    public int sword = 0;
    public int axe = 0;
    public int gun = 0;
    public int loot = 0;


    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

    }

    //Mutator Methods for player values.
    public void SetLevel(int level)
    {
        player_Level = level;
    }

    public int GetLevel()
    {
        return player_Level;
    }

    public int GetChoice()
    {
        return player_choice;
    }

    public void SetChoice(int choice)
    {
        player_choice = choice;
    }

    public int GetSex()
    {
        return player_sex;
    }

    public void SetSex(int sex)
    {
        player_sex = sex;
    }

    public int GetGold()  
    {
         return gold;
    }

    public void SetGold(int amount)
    {
        gold = amount;
    }

    public int GetFood()
    {
        return food;
    }

    public void SetFood(int amount)
    {
        food = amount;
    }

    public int GetBankedGold()
    {
        return banked_gold;
    }

    public void SetBankedGold(int amount)
    {
        banked_gold = amount;
    }
    public int GetMaxCrew()
    {
        return maxCrew;
    }
    public void IncreaseCrewSize(int amount)
    {
        maxCrew += amount;
    }

    public void SetCrewMate(string crewmate, int amount)  //Adjust amount of specified crewmember.
    {
        crewmate = crewmate.ToLower();

        if (crewmate == "sword")
        {
            sword = amount;
        }

        if (crewmate == "axe")
        {
            axe = amount;
        }

        if (crewmate == "gunner")
        {
            gun = amount;
        }

        if (crewmate == "looter")
        {
            loot = amount;
        }
    }

    // Return individual crew member amounts.
    public int GetSword()
    {
        return sword;
    }

    public int GetAxe()
    {
        return axe;
    }

    public int GetGunner()
    {
        return gun;
    }

    public int GetLooter()
    {
        return loot;
    }

}
