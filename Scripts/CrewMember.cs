using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewMember
{
    private int price;
    private int amount = 0;
    private string name;

    public CrewMember(string crewName, int cost)
    {
        price = cost;
        name = crewName;
    }

    public int GetPrice()
    {
        return price;
    }

    public int GetAmount()
    {
        return amount;

    }

    public void SetAmount(int number)
    {
         amount = number;

        if(amount < 0)
        {
            amount = 0;
        }

    }


}
