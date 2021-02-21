using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunForestRun : MonoBehaviour
{
    private bool isTriggered = false;
    private bool startPhae1 = false;
    private bool isOverPhase1 = false;
    private bool isOverPhase2 = false;
    public float verticalDirection = 1f;
    public float horizontalDirection = 1f;
    public float verticalDistance = 5f;
    public float horizontalDistance= 5f;
    public float movingSpeed = 5f;
    Vector2 movement;
    Vector3 positionStore;
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("turned table check: " + (gameObject.transform.parent.GetComponent<HowMuchTablesHasTurned>().turnedTableCount == gameObject.transform.parent.GetComponent<HowMuchTablesHasTurned>().triggerCount));
        if (!isTriggered)
        {
            if (gameObject.transform.parent.GetComponent<HowMuchTablesHasTurned>().turnedTableCount == gameObject.transform.parent.GetComponent<HowMuchTablesHasTurned>().triggerCount)
            {
                isTriggered = true;
                startPhae1 = true;
                positionStore = this.transform.position;
            }
        }

        if(startPhae1)
        {
            if((this.transform.position.y - positionStore.y  < verticalDistance) && !isOverPhase1)
            {
                movement.y = verticalDirection;
                rb.MovePosition(rb.position + movement * movingSpeed * Time.fixedDeltaTime);
            }
            else
            {
                movement.y = 0;
                isOverPhase1 = true;
            }

            if(isOverPhase1)
            {
                if ((this.transform.position.x - positionStore.x < horizontalDistance) && !isOverPhase2)
                {
                    movement.x = horizontalDirection;
                    rb.MovePosition(rb.position + movement * movingSpeed * Time.fixedDeltaTime);
                }
                else
                {
                    movement.x = 0;
                    
                    isOverPhase2 = true;
                    startPhae1 = false;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 

                }
            }

        }
    }

}
