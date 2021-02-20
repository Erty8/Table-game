using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballin : MonoBehaviour
{
    Vector2 movement;
    public float ballinSpeed = 5f;
    public Rigidbody2D rb;
    public float direction = -1f;

    // Start is called before the first frame update
    void Start()
    {
        movement.x = ballinSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (direction == 1)
        {

            rb.MovePosition(rb.position + movement * ballinSpeed * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition(rb.position - movement * ballinSpeed * Time.fixedDeltaTime);
        }
    }
}
