using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void ToChat()
    {
        GameObject.Find("/Chat").GetComponent<Renderer>().enabled = true;
        GameObject.Find("Missing App Id Canvas").GetComponent<Renderer>().enabled = false;
        GameObject.Find("/Scenery").GetComponent<Renderer>().enabled = false;
        GameObject.Find("/EventSystem").GetComponent<Renderer>().enabled = false;
        GameObject.Find("/Canvas").GetComponent<Renderer>().enabled = false;
        GameObject.Find("/Main Camera").GetComponent<Renderer>().enabled = false;
        GameObject.Find("/Game Manager").GetComponent<Renderer>().enabled = false;
    }
    public void BackToOrigin()
    {
        GameObject.Find("/Chat").GetComponent<Renderer>().enabled = false;
        GameObject.Find("/Scenery").GetComponent<Renderer>().enabled = true;
        GameObject.Find("/EventSystem").GetComponent<Renderer>().enabled = true;
        GameObject.Find("/Canvas").GetComponent<Renderer>().enabled = true;
        GameObject.Find("/Main Camera").GetComponent<Renderer>().enabled = true;
        GameObject.Find("/Game Manager").GetComponent<Renderer>().enabled = true;
    }
}
