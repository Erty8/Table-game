using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TableMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    private float walktimepassed;
    public float walkanimationcooldown = 20f;
    public float turnspeed = 100f;
    bool walking;
    bool walkinputbool;
    bool ontrigger = false;
    bool turnbool = false;
    public GameObject playermodel;
    public Animending endingscript;
    public Enemy_ai aiscript;
    Collider2D col;

    // Update is called once per frame
    void Update()
    {
        Vector2 characterscale = transform.localScale;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterscale.x = -0.2f;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterscale.x = 0.2f;
        }
        transform.localScale = characterscale;
        /*if (!walking && walkinputbool && endingscript.walkingfinish&& endingscript.turnfinish)
        {
            walking = true; 
            playermodel.GetComponent<Animator>().Play("Walk");

        }*/
        
        //walkcheck();
        Debug.Log("ontrigger: " + ontrigger);
        if (ontrigger && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Player turned");
            
            if (col.gameObject.transform.localRotation.z < 180)
            {

                turnbool = true;
            }


        }
        turn();
        Debug.Log("aiscript.stun==" + aiscript.stun);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Çarpıstık Trigger ");
            ontrigger = true;
            col = other;
        }
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Çarpıstık Collider");
            ontrigger = true;
            col = collision.collider;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            ontrigger = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            ontrigger = false;
        }
    }
    void turn()
    {
        Debug.Log("aiscript.stun==" + aiscript.stun);
        if (aiscript.stun) {
            if (turnbool)
            {
                col.gameObject.transform.rotation = Quaternion.Slerp(col.gameObject.transform.rotation, Quaternion.Euler(0, 0, 180), Time.deltaTime * turnspeed);
            }
            if (col.gameObject.transform.rotation.eulerAngles.z == 180)
            {
                turnbool = false;
                Invoke("ChangeScene", 1f);
            }
        }
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
                //playermodel.GetComponent<Animator>().Play("Idle");
            }
           
        }

    }
    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
