using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    OperateDB DB;
    LoadScreen Loader;
    public GameObject ErrorMessage;
    int togglevar = 0;

    private void Awake()
    {
        DB = GameObject.Find("DatabaseManager").GetComponentInChildren<OperateDB>();
        Loader = GameObject.Find("LoadManager").GetComponentInChildren<LoadScreen>();
    }

    private void Update()
    {
        if (togglevar == 1)
        {
            ErrorMessage.SetActive(true);
        }
        else
        {
            ErrorMessage.SetActive(false);
        }
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        DB.LoadData(1);
        Loader.LoadLevel(1);
        

    }

    public void ExitGame()
    {
        Application.Quit();

    }

    public void LoadGame()
    {
        if (DB.CheckSavedData())
        {
            DB.LoadData(2);
            Loader.LoadLevel(1);
            
        }
        else
        {
            togglevar = 1;
        }

    }

    public void ExitError()
    {
        togglevar = 0;
    }




}