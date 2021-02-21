using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAllBalls : MonoBehaviour
{
    public bool isTriggered = false;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag.Equals("Player"))
        {
            isTriggered = true;
            Debug.Log("isTriggered parent: " + isTriggered);
        }
    }
}
