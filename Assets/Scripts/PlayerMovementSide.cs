using UnityEngine;

public class PlayerMovementSide : MonoBehaviour
{
    public float moveSpeed = 5f;
    Vector2 movement;
    public Rigidbody2D rb;
    public float jumpHeight = 10f;
    private bool isJumping = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown("space") && !isJumping)
        {
            Debug.Log("Space pressed");
            movement.y += jumpHeight;
            isJumping = true;
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Ground"))
        {
            isJumping = false;
        }
    }

}
