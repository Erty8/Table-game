using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballin : MonoBehaviour
{
    Vector3 movement;
    public float ballinSpeedHor = 1f;
    public float ballinSpeedVer = 1f;
    public Rigidbody2D rb;
    public float direction;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        movement = new Vector3(0, 0, 0);
    }

    private void startMovement()
    {
        movement = new Vector3(ballinSpeedHor, ballinSpeedVer, 0);
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("isTriggered child: ");
        gameObject.transform.position += movement * direction * Time.deltaTime;
        if (gameObject.transform.parent.gameObject.GetComponent<TriggerAllBalls>().isTriggered)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            startMovement();
            
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Ground"))
        {
            movement = new Vector3(0, -4, 0);
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    
}
