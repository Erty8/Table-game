using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    void SceneChanger()
    {
        SceneManager.LoadScene("plat");
    }

    public void Loadscene()
    {
        Invoke("SceneChanger", 2f);
    }
}
