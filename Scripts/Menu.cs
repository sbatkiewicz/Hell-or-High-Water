using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Menu : MonoBehaviour
{

    public PlayerResources PlayerManager;
    public GameObject DialogueBox;
    public GameObject MenuBox;
    public int toggleVar = 0;
    public DialogueScript showMenuScript;
    public CameraController camera;

    public AudioSource closeSound;
    public AudioSource goldSound;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKey("f"))
        {

            camera = GameObject.Find("Camera").GetComponentInChildren<CameraController>();
            toggleVar = 1;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            camera.enabled = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            toggleVar = 2;
            showMenuScript.printingIP = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            camera.enabled = true;
        }

    }

    public void ExitMenu()
    {
        
        toggleVar = 0;
        Debug.Log("You've pressed the exit button!");
        showMenuScript.isDone = false;
        showMenuScript.printingIP = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        camera.enabled = true;
    }
}
