using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public GameObject Movewindow;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void add()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name.Equals("HomePage"))
        {
            GameObject addwin = GameObject.Instantiate(Movewindow) as GameObject;
            addwin.transform.SetParent(transform.parent.parent.parent.parent);
            string name = gameObject.GetComponentInChildren<Text>().text;
            name = name.Substring(9, name.Length - 9);
            MoveSelection.proj = Homepage.ProjectList[name];
        }
        if (currentScene.name.Equals("FolderPage"))
        {
            GameObject addwin = GameObject.Instantiate(Movewindow) as GameObject;
            addwin.transform.SetParent(transform.parent.parent.parent.parent);
            string name = gameObject.GetComponentInChildren<Text>().text;
            name = name.Substring(9, name.Length - 9);
            MoveSelection.proj = FolderPage.folder.ProjectList[name];
        }
        if (currentScene.name.Equals("TagPage"))
        {
            GameObject addwin = GameObject.Instantiate(Movewindow) as GameObject;
            addwin.transform.SetParent(transform.parent.parent.parent.parent);
            string name = gameObject.GetComponentInChildren<Text>().text;
            name = name.Substring(9, name.Length - 9);
            MoveSelection.proj = TagPage.CurrTag.ProjectList[name];
        }
    }
}
