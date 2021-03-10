using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMotor : MonoBehaviour
{
    public int speed = 4;
    Vector3 Movement;
    void Start()
    {
        if(this.gameObject.tag == "FishR")
        {
            transform.Rotate(new Vector3(0f, -90f, 0f), Space.Self);
        }
        else
        {
            transform.Rotate(new Vector3(0f, -270f, 0f), Space.Self);
        }
        Movement = new Vector3(0f, 0f, 1f) * speed * Time.deltaTime; 
    }
    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Movement, Space.Self);
    }
}
