using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInfo : MonoBehaviour
{
    public GameObject TutorialUI;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("key"))
        {
            TutorialUI.SetActive(false);
        }
        else
        {
            TutorialUI.SetActive(true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        PlayerPrefs.SetInt("key", 0);
        PlayerPrefs.Save();
        TutorialUI.SetActive(false);
        Destroy(this.gameObject);
      
    }

}
