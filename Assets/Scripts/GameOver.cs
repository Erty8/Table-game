using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject overpanel;
    // Start is called before the first frame update
    void gameover()
    {
        overpanel.gameObject.SetActive(true);
    }
    public void overbutton()
    {
        Invoke("gameover", 2f);
    }
}
