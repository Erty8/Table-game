using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballin : MonoBehaviour
{
    Vector3 movement;
    public float ballinSpeed = 1f;
    public Rigidbody2D rb;
    public float direction;

    // Start is called before the first frame update
    void Start()
    {
        movement = new Vector3(ballinSpeed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += movement * direction * Time.deltaTime;
    }
}
