using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour
{
    public GameObject fish;

    void Start()
    {      
        StartCoroutine("spawnFish");

    }

    public IEnumerator spawnFish()
    {
        int timer = Random.Range(6, 18);
        yield return new WaitForSeconds(timer);
        Instantiate(fish, this.gameObject.transform.position, Quaternion.identity);      
        StartCoroutine("spawnFish");
    }
     

}
