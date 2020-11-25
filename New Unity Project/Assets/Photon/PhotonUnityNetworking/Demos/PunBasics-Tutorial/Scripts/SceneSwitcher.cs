using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    /* public void ToChat()
    {
        Globals.OriginScene = SceneManager.GetActiveScene().buildIndex;
        Debug.LogFormat("saindo da cena {0}", Globals.OriginScene);
        int scene = SceneManager.GetSceneByName("DemoChat-Scene").buildIndex;
        Debug.LogFormat("cena do chat a ser habilitada: {0}", scene);
        if (Globals.Inicio)
        {
            SceneManager.LoadScene(5, LoadSceneMode.Additive);
            Globals.Inicio = false;
        }
        else
        {
            foreach (GameObject g in SceneManager.GetSceneByName("DemoChat-Scene").GetRootGameObjects())
            {
                if(g.name != "Missing App Id Canvas")
                {
                    g.SetActive(true);
                }
            }
        }
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
