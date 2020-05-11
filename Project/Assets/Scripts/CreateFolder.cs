using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateFolder : MonoBehaviour
{
    public string text;
    public GameObject inputfield;
    
    public void NewFolder()
    {
        text = inputfield.GetComponentInChildren<Text>().text;
        UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name.Equals("HomePage"))
        {
            if (text == "")
            {
                gameObject.GetComponentInChildren<Text>().text = "You must enter a name";
            }
            else if (Homepage.FolderList.ContainsKey(text))
            {
                gameObject.GetComponentInChildren<Text>().text = "name cannot be a duplicate";
            }
            else
            {
                FolderEntity newFolder = new FolderEntity(text);
                Homepage.FolderList.Add(text, newFolder);
                Homepage.BoolRedraw = true;
                Destroy(gameObject);
            }
        }
        if (currentScene.name.Equals("FolderPage"))
        {
            if (text == "")
            {
                gameObject.GetComponentInChildren<Text>().text = "You must enter a name";
            }
            else if (FolderPage.folder.FolderList.ContainsKey(text))
            {
                gameObject.GetComponentInChildren<Text>().text = "name cannot be a duplicate";
            }
            else
            {
                FolderEntity newFolder = new FolderEntity(text);
                newFolder.parent = FolderPage.folder;
                FolderPage.folder.FolderList.Add(text, newFolder);
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
