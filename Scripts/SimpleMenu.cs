using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SimpleMenu : MonoBehaviour
{

    public PlayerResources PlayerManager;
    public GameObject MenuBox;
    public int toggleVar = 0;
    public AudioSource closeSound;

    void Update()
    {
        if (toggleVar == 1)
        {
             MenuBox.SetActive(true);
             Cursor.visible = true;
             Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            MenuBox.SetActive(false);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKey("f"))
        {
            toggleVar = 1;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            toggleVar = 2;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    public void ExitMenu()
    {
        toggleVar = 0;
        Debug.Log("You've pressed the exit button!");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
