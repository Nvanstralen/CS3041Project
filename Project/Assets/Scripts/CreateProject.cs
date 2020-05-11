using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateProject : MonoBehaviour
{
    public string text;
    public GameObject inputfield;

    public void NewProject()
    {

        text = inputfield.GetComponentInChildren<Text>().text;
        if (text == "")
        {
            gameObject.GetComponentInChildren<Text>().text = "You must enter a name";
        }
        else if (Homepage.ProjectMasterList.ContainsKey(text))
        {
            gameObject.GetComponentInChildren<Text>().text = "name cannot be a duplicate";
        }
        else
        {
            UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.name.Equals("HomePage"))
            {
                text = inputfield.GetComponentInChildren<Text>().text;
                ProjectEntity newProject = new ProjectEntity(text);
                Homepage.ProjectList.Add(text, newProject);
                Homepage.ProjectMasterList.Add(text, newProject);
                Homepage.BoolRedraw = true;
                Destroy(gameObject);
            }

            if (currentScene.name.Equals("FolderPage"))
            {
                text = inputfield.GetComponentInChildren<Text>().text;
                ProjectEntity newProject = new ProjectEntity(text);
                newProject.parent = FolderPage.folder;
                FolderPage.folder.ProjectList.Add(text, newProject);
                Homepage.ProjectMasterList.Add(text, newProject);
                FolderPage.BoolRedraw = true;
                Destroy(gameObject);

            }
        }
    }
    public void cancel()
    {
        Destroy(gameObject);
    }
}
