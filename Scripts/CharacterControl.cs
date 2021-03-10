using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float Speed;
    public Animator anim;
    public bool isGrounded;
    public float jumpHeight;

    void Start()
    {
        anim = GetComponent<Animator>();

    }


    void Update()
    {
        PlayerMovement();
        PlayerAnimate();

    }

    public void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
                        
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;

        transform.Translate(playerMovement, Space.Self);

    }

    public void PlayerAnimate()
    {

        if (Input.GetKey(KeyCode.A))  //Left
        {
            anim.SetInteger("Movement", 2);
        }

        else if (Input.GetKey(KeyCode.D))  //Right
        {
            anim.SetInteger("Movement", 3);
        }

        else if (Input.GetKey(KeyCode.W))  //Forwards
        {
            anim.SetInteger("Movement", 1);
        }

        else if (Input.GetKey(KeyCode.S))  //Backwards
        {
            anim.SetInteger("Movement", 4);
            
        }

        else
        {
            anim.SetInteger("Movement", 0);
        }
    }

    void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Terrain")
        {
            isGrounded = false;

        }
    }

    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Terrain")
        {
            isGrounded = true;
        }

    }





}
