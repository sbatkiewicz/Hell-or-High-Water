using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playerHUD : MonoBehaviour
{
    public PlayerResources PlayerManager;

    public Text goldAmount;
    public Text foodAmount;
    public Text swordAmount;
    public Text axeAmount;
    public Text gunnerAmount;
    public Text looterAmount;

    void Awake()
    {
        PlayerManager = GameObject.Find("PlayerManager").GetComponentInChildren<PlayerResources>();
        goldAmount = GameObject.Find("GoldText").GetComponent<Text>();
        foodAmount = GameObject.Find("FoodText").GetComponent<Text>(); 
        swordAmount = GameObject.Find("SwordText").GetComponent<Text>(); 
        axeAmount = GameObject.Find("AxeText").GetComponent<Text>(); 
        gunnerAmount = GameObject.Find("GunnerText").GetComponent<Text>(); 
        looterAmount = GameObject.Find("LooterText").GetComponent<Text>(); 
}
  
    void Update()
    {
        UpdateGUI();
    }

    public void UpdateGUI()
    {
        goldAmount.text = "x" + PlayerManager.GetGold().ToString();
        foodAmount.text = "x" + PlayerManager.GetFood().ToString();
        swordAmount.text = "x" + PlayerManager.GetSword().ToString();
        axeAmount.text = "x" + PlayerManager.GetAxe().ToString();
        gunnerAmount.text = "x" + PlayerManager.GetGunner().ToString();
        looterAmount.text = "x" + PlayerManager.GetLooter().ToString();

    }
}
