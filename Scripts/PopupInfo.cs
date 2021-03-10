using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupInfo : MonoBehaviour
{
    public GameObject popUpText;

    void Start()
    {
        popUpText.SetActive(false);
    }

    public void OnMouseOver()
    {
        popUpText.SetActive(true);
        Debug.Log("Mouse On!");
    }

    public void OnMouseExit()
    {
        popUpText.SetActive(false);
        Debug.Log("Mouse Off!");
    }

}
