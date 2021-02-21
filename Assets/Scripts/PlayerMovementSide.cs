using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementSide : MonoBehaviour
{
    public float moveSpeed = 5f;
    Vector2 movement;
    public Rigidbody2D rb;
    public float jumpHeight = 10f;
    private bool isJumping = false;
    public GameObject winpanel;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Vector2.up is: " + Vector2.up.magnitude);
        movement.x = Input.GetAxisRaw("Horizontal");
        Debug.Log("Input.GetAxisRaw('Horizontal'): " + Input.GetAxisRaw("Horizontal"));
        if (Input.GetKeyDown("space") && !isJumping)
        {
            Debug.Log("Space pressed");
            // movement.y += jumpHeight;
            rb.AddForce(Vector2.up * jumpHeight);
            isJumping = true;
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if(isJumping)
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Ground"))
        {
            isJumping = false;
            Debug.Log("Now touchingg!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cowboy")
        {
            winpanel.gameObject.SetActive(true);
        }
    }

}
