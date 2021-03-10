using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TravelMenu : Menu
{
    public int scene = 0;
    private void Awake()
    {

        showMenuScript = DialogueBox.GetComponentInChildren<DialogueScript>();
        PlayerManager = GameObject.Find("PlayerManager").GetComponentInChildren<PlayerResources>();

    }
    void Update()
    {
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


    public void Travel()
    {
        SceneManager.LoadScene(scene);
    }


}
