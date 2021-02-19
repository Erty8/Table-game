using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("touch");
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collider.gameObject.tag == "Interactable")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("touch");
            if (Input.GetKeyDown(KeyCode.E))
            {
                collider.gameObject.transform.Rotate(180, 0, 0);
                Debug.Log("turned");
                //interactable.GetInteracted(this);
            }
            //collision.gameObject.transform.Rotate(180,0,0);
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collider.gameObject.tag == "MyGameObjectTag")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
        }
    }
}
