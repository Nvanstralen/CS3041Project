using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class addTag : MonoBehaviour
{
    public GameObject addwindow;
    public GameObject RemoveTabWindow;
    public GameObject TagPrefab;
    public GameObject TagLayout;
    public static bool BoolRedraw = true;
    int count = 3;
    void Update()
    {
        if (BoolRedraw)
        {
            foreach (Transform child in TagLayout.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            Scene currentScene = SceneManager.GetActiveScene();
            
            ProjectEntity project;
            if (currentScene.name.Equals("HomePage"))
            {
                string name = gameObject.GetComponentInChildren<Text>().text;
                name = name.Substring(9, name.Length - 9);
                project = Homepage.ProjectList[name];
            }
            else if (currentScene.name.Equals("FolderPage"))
            {
                string name = gameObject.GetComponentInChildren<Text>().text;
                name = name.Substring(9, name.Length - 9);
                project = FolderPage.folder.ProjectList[name];
            }
            else if (currentScene.name.Equals("TagPage"))
            {
                string name = gameObject.GetComponentInChildren<Text>().text;
                name = name.Substring(9, name.Length - 9);
                project = TagPage.CurrTag.ProjectList[name];
            }
            else
            {
                project = ProjectPage.project;
            }

            foreach (KeyValuePair<string, TagEntity> tag in project.TagList)
            {
                Vector2 CurrSize = TagLayout.GetComponent<RectTransform>().sizeDelta;


                GameObject tagobj = GameObject.Instantiate(TagPrefab) as GameObject;
                tagobj.GetComponentInChildren<Text>().text = tag.Key;
                Vector2 ButtonSize = tagobj.GetComponent<RectTransform>().sizeDelta;
                int ButtonWidth = 20 + (8 * tag.Key.Length);

                tagobj.GetComponent<RectTransform>().sizeDelta = new Vector2(ButtonWidth, ButtonSize.y);

                tagobj.transform.SetParent(TagLayout.transform);
                
            }
            count--;
            
        }

        if(count == 0)
        {
            count = 3;
            BoolRedraw = false;
        }

    }

    public void add()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name.Equals("HomePage"))
        {
            GameObject addwin = GameObject.Instantiate(addwindow) as GameObject;
            addwin.transform.SetParent(transform.parent.parent.parent.parent);
            string name = gameObject.GetComponentInChildren<Text>().text;
            name = name.Substring(9, name.Length - 9);
            TagSelection.proj = Homepage.ProjectList[name];
        }
        if (currentScene.name.Equals("FolderPage"))
        {
            GameObject addwin = GameObject.Instantiate(addwindow) as GameObject;
            addwin.transform.SetParent(transform.parent.parent.parent.parent);
            string name = gameObject.GetComponentInChildren<Text>().text;
            name = name.Substring(9, name.Length - 9);
            TagSelection.proj = FolderPage.folder.ProjectList[name];
        }
        if (currentScene.name.Equals("TagPage"))
        {
            GameObject addwin = GameObject.Instantiate(addwindow) as GameObject;
            addwin.transform.SetParent(transform.parent.parent.parent.parent);
            string name = gameObject.GetComponentInChildren<Text>().text;
            name = name.Substring(9, name.Length - 9);
            TagSelection.proj = TagPage.CurrTag.ProjectList[name];
        }
        if (currentScene.name.Equals("ProjectPage"))
        {
            GameObject addwin = GameObject.Instantiate(addwindow) as GameObject;
            addwin.transform.SetParent(transform);
            TagSelection.proj = ProjectPage.project;
        }
    }

    public void RemoveWindow()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name.Equals("HomePage"))
        {
            GameObject addwin = GameObject.Instantiate(RemoveTabWindow) as GameObject;
            addwin.transform.SetParent(transform.parent.parent.parent.parent);
            string name = gameObject.GetComponentInChildren<Text>().text;
            name = name.Substring(9, name.Length - 9);
            TagSelection.proj = Homepage.ProjectList[name];
        }
        if (currentScene.name.Equals("FolderPage"))
        {
            GameObject addwin = GameObject.Instantiate(RemoveTabWindow) as GameObject;
            addwin.transform.SetParent(transform.parent.parent.parent.parent);
            string name = gameObject.GetComponentInChildren<Text>().text;
            name = name.Substring(9, name.Length - 9);
            TagSelection.proj = FolderPage.folder.ProjectList[name];
        }
        if (currentScene.name.Equals("TagPage"))
        {
            GameObject addwin = GameObject.Instantiate(RemoveTabWindow) as GameObject;
            addwin.transform.SetParent(transform.parent.parent.parent.parent);
            string name = gameObject.GetComponentInChildren<Text>().text;
            name = name.Substring(9, name.Length - 9);
            TagSelection.proj = TagPage.CurrTag.ProjectList[name];
        }
        if (currentScene.name.Equals("ProjectPage"))
        {
            GameObject addwin = GameObject.Instantiate(RemoveTabWindow) as GameObject;
            addwin.transform.SetParent(transform);
            TagSelection.proj = ProjectPage.project;
        }
    }
}
