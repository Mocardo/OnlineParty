using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    public void ToChat()
    {
        Globals.OriginScene = SceneManager.GetActiveScene().buildIndex;
        Debug.LogFormat("saindo da cena {0}", Globals.OriginScene);
        SceneManager.LoadScene(5);
    }
    public void BackToOrigin()
    {
        Debug.LogFormat("voltando para a cena {0}", Globals.OriginScene);
        SceneManager.LoadScene(Globals.OriginScene);
    }
}
