using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    /* public void ToChat()
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
        Debug.LogFormat("voltando para a cena {0}", Globals.OriginScene);
        foreach (GameObject g in SceneManager.GetSceneByName("DemoChat-Scene").GetRootGameObjects())
        {
            g.SetActive(false);
        }
    } */

    public void ToChat()
    {
        // get root objects in scene
        List<GameObject> rootObjects = new List<GameObject>();
        Scene scene = SceneManager.GetActiveScene();
        scene.GetRootGameObjects(rootObjects);

        // iterate root objects and do something
        for (int i = 0; i < rootObjects.Count; ++i)
        {
            GameObject gameObject = rootObjects[i];
            if (gameObject.name == "Main Camera") gameObject.SetActive(false);
            if (gameObject.name == "Canvas") gameObject.SetActive(false);
            if (gameObject.name == "DemoChat-Scene") gameObject.SetActive(true);
        }
    }

    public void BackToOrigin()
    {
        // get root objects in scene
        List<GameObject> rootObjects = new List<GameObject>();
        Scene scene = SceneManager.GetActiveScene();
        scene.GetRootGameObjects(rootObjects);

        // iterate root objects and do something
        for (int i = 0; i < rootObjects.Count; ++i)
        {
            GameObject gameObject = rootObjects[i];
            if (gameObject.name == "Main Camera") gameObject.SetActive(true);
            if (gameObject.name == "Canvas") gameObject.SetActive(true);
            if (gameObject.name == "DemoChat-Scene") gameObject.SetActive(false);
        }
    }
}
