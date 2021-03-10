using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LoadScreen : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
        {
            StartCoroutine(WasteTime());
        }
    }
    public void LoadLevel(int index)
    {
        StartCoroutine(LoadAsychronously(index));
    }

    IEnumerator LoadAsychronously(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;

            yield return null;

        }
        


    }


    IEnumerator WasteTime()
    {
        slider.value = 100f;
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(2);
        loadingScreen.SetActive(false);
    }


}
