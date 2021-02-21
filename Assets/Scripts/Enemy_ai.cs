using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ai : MonoBehaviour
{
    public float speed = 0.5f;
    public float turnspeed = 100F;
    bool ontrigger = false;
    bool turnbool = false;
    public bool stun = false;
    Collider2D col;
    Vector2 position;
    GameObject closestEnemy = null;
    private int closestEnemyIndex;
    public GameObject playermodel;
    public Animending endingscript;
    public List<GameObject> enemies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;
        FindallEnemies();
        playermodel.GetComponent<Animator>().Play("Walk");
    }
    void FindallEnemies()
    {
        
        enemies.AddRange(GameObject.FindGameObjectsWithTag("Interactable"));
    }
    
    void FindClosestEnemy()
    {
       
        float distanceToClosestEnemy = Mathf.Infinity;

        for (int i = 0; i<enemies.Count;i++) 
        {
            GameObject currentEnemy = enemies[i];
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
                closestEnemyIndex = i;
                Debug.Log("index="+closestEnemyIndex);
                Debug.Log(enemies);
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, closestEnemy.transform.position, speed*Time.deltaTime);
        if (ontrigger)
        {
            //speed = 0.01f;
            turn();
        }
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            ontrigger = true;
            Debug.Log("ontrigger:"+ontrigger);
            col = other;
            turnbool = true;
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
        if (closestEnemy.gameObject.transform.localRotation.eulerAngles.z == 180)
        {
            turnbool = false;
            enemies.RemoveAt(closestEnemyIndex);
            Debug.Log("index="+closestEnemyIndex);

        }
        else if (turnbool&&!stun)
        {
            
            playermodel.GetComponent<Animator>().Play("Turntable");
           
            //if (endingscript.turnfinish)
            //{
                closestEnemy.gameObject.transform.rotation = Quaternion.Slerp(col.gameObject.transform.rotation, 
                    Quaternion.Euler(0, 0, 180), Time.deltaTime * turnspeed);
                Debug.Log("enemy turned table");
                Invoke("stunned", 2f);
                closestEnemy.gameObject.tag = "Untagged";
                speed = 0;

            //}
        }

    }
    // Update is called once per frame
    void Update()
    {

        Debug.Log("turnbool:"+turnbool);
        Debug.Log("endingscript.turnfinish:" + endingscript.turnfinish);
        FindClosestEnemy();
        
    }
    void stunned()
    {
        if (!stun) {
            Debug.Log("stunned");
            playermodel.GetComponent<Animator>().Play("Idle");
            speed = 0;
            stun = true;
            Invoke("nostun",4f);
        } 
        
    }
    void nostun()
    {
        Debug.Log("stunned");
        playermodel.GetComponent<Animator>().Play("Walk");
        speed = 1.25f;
        stun = false;
    }
}
