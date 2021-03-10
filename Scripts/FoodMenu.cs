using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class FoodMenu : Menu
{

    public int priceOfFood = 5;
    public Text FoodPrice;
    public int amountOfFood = 1;
    public Text FoodAmount;

    private void Awake()
    {

        showMenuScript = DialogueBox.GetComponentInChildren<DialogueScript>();
        PlayerManager = GameObject.Find("PlayerManager").GetComponentInChildren<PlayerResources>();

    }

    void Update()
    {
        UpdateGUI();
        if (toggleVar == 1)
        {
            DialogueBox.SetActive(true);
            showMenuScript.PrintText();
            if (showMenuScript.isDone == true)
            {

                MenuBox.SetActive(true);
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

    public void UpdateGUI()
    {     
        FoodAmount.text = amountOfFood.ToString();
        FoodPrice.text = (priceOfFood * amountOfFood).ToString();
    }

    public void Purchase()
    {
        Debug.Log("Player has " + PlayerManager.GetGold() + "gold, and " + PlayerManager.GetFood() + " food.");
        if (PlayerManager.GetGold() >= priceOfFood * amountOfFood)
        {
            PlayerManager.SetGold(PlayerManager.GetGold() - priceOfFood * amountOfFood);

            PlayerManager.SetFood(PlayerManager.GetFood() + amountOfFood);
           

            toggleVar = 0;
            amountOfFood = 0;
            showMenuScript.isDone = false;
            goldSound.Play();

            Debug.Log("Player now has " + PlayerManager.GetGold() + " gold, and " + PlayerManager.GetFood() + " food.");
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            camera.enabled = true;
        }


    }

    public void ButtonInc()
    {
        amountOfFood++;
    }

    public void ButtonDec()
    {
        amountOfFood--;

        if (amountOfFood < 0)
        {
            amountOfFood = 0;
        }
    }

}
