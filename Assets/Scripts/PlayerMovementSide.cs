using UnityEngine;

public class PlayerMovementSide : MonoBehaviour
{
    public float moveSpeed = 5f;
    Vector2 movement;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
