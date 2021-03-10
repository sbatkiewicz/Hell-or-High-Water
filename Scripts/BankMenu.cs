using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BankMenu : Menu
{
    public int aboutToDeposit = 0;
    public int aboutToWithdraw = 0;

    public Text DepositText;
    public Text WithdrawText;

    public Text bankedGold;
    public Text PlayerGold;

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
                //ShowMenu();
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


   /* IEnumerator ShowMenu()
    {

        yield return new WaitForSeconds(.5f);
        DialogueBox.SetActive(false);

    }*/

    public void UpdateGUI()
    {
        bankedGold.text = "x" + PlayerManager.GetBankedGold().ToString();
        PlayerGold.text = "x" + PlayerManager.GetGold().ToString();
        DepositText.text = aboutToDeposit.ToString();
        WithdrawText.text = aboutToWithdraw.ToString();

    }

    public void DepositButtonInc()
    {
        aboutToDeposit += 10;
    }

    public void DepositButtonDec()
    {
        aboutToDeposit -= 10;

        if (aboutToDeposit < 0)
        {
            aboutToDeposit = 0;
        }
    }

    public void WithdrawButtonInc()
    {
        aboutToWithdraw += 10;
    }

    public void WithdrawButtonDec()
    {
        aboutToWithdraw -= 10;

        if (aboutToWithdraw < 0)
        {
            aboutToWithdraw = 0;
        }
    }


    public void Deposit()
    {

        if (PlayerManager.GetGold() >= aboutToDeposit)
        {
            PlayerManager.SetGold(PlayerManager.GetGold() - aboutToDeposit);
            PlayerManager.SetBankedGold(PlayerManager.GetBankedGold() + aboutToDeposit);

            aboutToDeposit = 0;
            goldSound.Play();
        }

    }

    public void Withdraw()
    {

        if (PlayerManager.GetBankedGold() >= aboutToWithdraw)
        {
            PlayerManager.SetGold(PlayerManager.GetGold() + aboutToWithdraw);
            PlayerManager.SetBankedGold(PlayerManager.GetBankedGold() - aboutToWithdraw);

            aboutToDeposit = 0;
            goldSound.Play();
        }

    }


}
