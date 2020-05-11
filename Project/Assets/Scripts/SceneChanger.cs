using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public void home()
    {
        SceneManager.LoadScene("HomePage");
    }
    public void folder()
    {
        string name = gameObject.GetComponentInChildren<Text>().text;
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name.Equals("HomePage"))
        {
            SceneManager.LoadScene("FolderPage");
            FolderPage.folder = Homepage.FolderList[name];
        }
        if(currentScene.name.Equals("FolderPage"))
        {
            SceneManager.LoadScene("FolderPage");
            FolderEntity newFolder = FolderPage.folder.FolderList[name];
            FolderPage.folder = newFolder;
        }
    }
    public void tagpage()
    {
        string name = gameObject.GetComponentInChildren<Text>().text;
        TagPage.CurrTag = Homepage.TagList[name];
        SceneManager.LoadScene("TagPage");
    }
    public void project()
    {
        string name = gameObject.GetComponentInChildren<Text>().text;
        name = name.Substring(9, name.Length-9);
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name.Equals("HomePage"))
        {
            ProjectPage.project = Homepage.ProjectList[name];
        }
        if (currentScene.name.Equals("FolderPage"))
        {
            ProjectPage.project = FolderPage.folder.ProjectList[name]; ;
        }
        if (currentScene.name.Equals("TagPage"))
        {
            ProjectPage.project = TagPage.CurrTag.ProjectList[name]; ;
        }

        SceneManager.LoadScene("ProjectPage");
    }
    public void back()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name.Equals("HomePage"))
        {
        }
        if (currentScene.name.Equals("FolderPage"))
        {
            if (FolderPage.folder.parent != null)
            {
                SceneManager.LoadScene("FolderPage");
                FolderEntity newFolder = FolderPage.folder.parent;
                FolderPage.folder = newFolder;
            }
            else
            {
                SceneManager.LoadScene("HomePage");
            }
        }
        if (currentScene.name.Equals("TagPage"))
        {
            SceneManager.LoadScene("HomePage");
        }
        if (currentScene.name.Equals("ProjectPage"))
        {
            if(ProjectPage.project.parent != null)
            {
                FolderPage.folder = ProjectPage.project.parent;
                SceneManager.LoadScene("FolderPage");
            }
            else
            {
                SceneManager.LoadScene("HomePage");
            }
        }
    }
}
