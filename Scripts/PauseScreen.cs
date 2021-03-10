using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    int currentScene;
    public GameObject Pause;
    OperateDB DB;
    public CameraController camera;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        DB = GameObject.Find("DatabaseManager").GetComponentInChildren<OperateDB>();
        
    }
 
    void Update()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 1 || currentScene == 2)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                camera = GameObject.Find("Camera").GetComponentInChildren<CameraController>();
                Debug.Log("You paused the game.");
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Pause.SetActive(true);
                camera.enabled = false;
            }
        }
    } 

    public void ResumeGame()
    {
        Pause.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        camera.enabled = true;
    }

    public void ExitGame()
    {
        Application.Quit();

    }

    public void SaveGame()
    {
        DB.SaveData();
    }
}
