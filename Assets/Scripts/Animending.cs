using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animending : MonoBehaviour
{
    public bool walkingfinish;
    public bool turnfinish;
    // Start is called before the first frame update
    void Start()
    {
     turnfinish = true;
     walkingfinish = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Finish()
    {
       walkingfinish = true ;
       Debug.Log("walkingfinish" + walkingfinish);
       Invoke("walkfalse", 1f);
    }
    void walkfalse()
    {
        walkingfinish = false;
    }
    void Turningfinished()
    {
        turnfinish = true;
        Invoke("Turningfinishfalse", 1f);

    }
    void Turningfinishfalse()
    {
        turnfinish = false;
    }
}
