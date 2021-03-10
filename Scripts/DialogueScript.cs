using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{

    //public AudioSource audioSound;

    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";
    public bool isDone = false;
    public bool printingIP = false;

    public void PrintText()
    {
        if (printingIP == false)
        {
            printingIP = true;
            currentText = "";
            StartCoroutine(ShowText());
        }

    }


    IEnumerator ShowText()
    {
        for (int x = 0; x <= fullText.Length; x++)
        {
            currentText = fullText.Substring(0, x);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }

        isDone = true;
        //audioSound.Play();

    }
}
