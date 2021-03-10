using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFish : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "FishR" || other.gameObject.tag == "FishL")
        {
            Destroy(other.gameObject);
        }
    }
}
