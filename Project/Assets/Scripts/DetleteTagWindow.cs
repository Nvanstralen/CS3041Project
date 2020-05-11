using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DetleteTagWindow : MonoBehaviour
{
    public GameObject DeleteTabWindow;

    public void DeleteWindow()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name.Equals("HomePage"))
        {
            GameObject addwin = GameObject.Instantiate(DeleteTabWindow) as GameObject;
            addwin.transform.SetParent(transform.parent);
        }
        if (currentScene.name.Equals("FolderPage"))
        {
            GameObject addwin = GameObject.Instantiate(DeleteTabWindow) as GameObject;
            addwin.transform.SetParent(transform.parent);
        }
        if (currentScene.name.Equals("TagPage"))
        {
            GameObject addwin = GameObject.Instantiate(DeleteTabWindow) as GameObject;
            addwin.transform.SetParent(transform.parent);
        }
    }
}
