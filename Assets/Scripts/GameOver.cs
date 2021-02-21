using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject overpanel;
    public GameObject dialoguepanel;
    // Start is called before the first frame update
    void gameover()
    {
        overpanel.gameObject.SetActive(true);
        dialoguepanel.gameObject.SetActive(false);
    }
    public void overbutton()
    {
        Invoke("gameover", 3f);
    }
}
