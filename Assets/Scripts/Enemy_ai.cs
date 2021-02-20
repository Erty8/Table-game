using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ai : MonoBehaviour
{
    public float speed = 0.5f;
    public float turnspeed = 100F;
    bool ontrigger = false;
    bool turnbool = false;
    Collider2D col;
    Vector2 position;
    GameObject closestEnemy = null;
    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;
    }
    
    void FindClosestEnemy()
    {
        List<GameObject> enemies = new List<GameObject>();
        enemies.AddRange(GameObject.FindGameObjectsWithTag("Interactable"));
        
        float distanceToClosestEnemy = Mathf.Infinity;

        foreach (GameObject currentEnemy in enemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, closestEnemy.transform.position, speed*Time.deltaTime);
        if (ontrigger)
        {
            speed = 0.01f;
            turn();
        }
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            ontrigger = true;
            Debug.Log(ontrigger);
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
    void turn()
    {
        if (closestEnemy.gameObject.transform.localRotation.z == 180)
        {
            turnbool = false;
        }
        else if (turnbool)
        {
            closestEnemy.gameObject.transform.rotation = Quaternion.Slerp(col.gameObject.transform.rotation, Quaternion.Euler(0, 0, 180), Time.deltaTime * turnspeed);
            Debug.Log("enemy turned table");
        }

    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(turnbool);
        FindClosestEnemy();
        
    }
}
