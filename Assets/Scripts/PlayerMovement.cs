using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    private float walktimepassed;
    public float walkanimationcooldown = 20f;
    bool walking;
    bool walkinputbool;
    public GameObject playermodel;
    public Animending endingscript;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("endingscript" + endingscript);
        Debug.Log("walking" +walkinputbool);
        Vector2 characterscale = transform.localScale;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterscale.x = -0.15f;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterscale.x = 0.15f;
        }
        transform.localScale = characterscale;
        /*if (!walking && walkinputbool && endingscript.walkingfinish&& endingscript.turnfinish)
        {
            walking = true; 
            playermodel.GetComponent<Animator>().Play("Walk");

        }*/
        
        walkcheck();

    }

    void FixedUpdate()
    {
        
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    public void walkcheck() {
        if (endingscript.turnfinish && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
          {
            walkinputbool = true;
            if (endingscript.turnfinish)
            {
                playermodel.GetComponent<Animator>().Play("Walk");
            }
        }
        else if (!endingscript.turnfinish  && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            walkinputbool = false;
            if (endingscript.turnfinish)
            {
                //playermodel.GetComponent<Animator>().Play("Walk");
            }
        }
        else
        {
            walkinputbool = false;
            walking = false;
            if (endingscript.turnfinish)
            {
                playermodel.GetComponent<Animator>().Play("Idle");
            }
           
        }

    }

}
