using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    bool ontrigger = false;
    Collider2D col;
    [Header("interaction")]
    public float maxInteractionDistance;

    [NonSerialized]
    public PlayerInventory inventory;

    private void Start()
    {
        Debug.Log("adsada");
        CreateInventory();

    }

    private void CreateInventory()
    {
        inventory = new PlayerInventory();
        inventory.hasBottle = false;
        inventory.barrelcolor = Color.black;
    }

    private void Update()
    {
        Debug.Log(ontrigger);
        CheckInteractables();
        if (ontrigger && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("turned");
            col.gameObject.transform.Rotate(180, 0, 0);
          
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            ontrigger = true;
            col = other;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            ontrigger = false;
        }
    }

    /*void OnTriggerStay(Collider col)
    {
        
        Debug.Log("touch");
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (col.gameObject.tag.Equals ("Interactable") )
        {
            Debug.Log("found");
            //If the GameObject's name matches the one you suggest, output this message in the console

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("turned");
                col.gameObject.transform.Rotate(180, 0, 0);
                
                //interactable.GetInteracted(this);
            }
            //collision.gameObject.transform.Rotate(180,0,0);
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (col.gameObject.tag == "MyGameObjectTag")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
        }
    }*/

    private void CheckInteractables()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(ray, out hit, maxInteractionDistance, LayerMask.GetMask("Interactable")))
        {
            Interactable interactable = hit.collider.gameObject.GetComponentInParent<Interactable>();
            if (interactable.IsInteractable(this))
            {
                //UIManager.instance.ShowInteractionText(interactable.GetInteractionText());

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.GetInteracted(this);
                }
            }
            else
            {
                //UIManager.instance.HideInteractionText();
            }
        }
        else
        {
            //UIManager.instance.HideInteractionText();
        }
    }
}


public struct PlayerInventory
{
    public bool hasBottle;
    public Color barrelcolor;

}