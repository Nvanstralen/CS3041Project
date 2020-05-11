using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateTag : MonoBehaviour
{
    public string text;
    public GameObject inputfield;

    public void NewTag()
    {
        text = inputfield.GetComponentInChildren<Text>().text;
        Debug.Log(text.Length);
        if (text.Length == 0)
        {
            gameObject.GetComponentInChildren<Text>().text = "You must enter a name";
        }
        else if (Homepage.TagList.ContainsKey(text))
        {
            gameObject.GetComponentInChildren<Text>().text = "name cannot be a duplicate";
        }
        else
        {
            text = inputfield.GetComponentInChildren<Text>().text;
            TagEntity newTag = new TagEntity(text);
            Homepage.TagList.Add(text, newTag);
            Homepage.BoolRedraw = true;
            Destroy(gameObject);
        }
        UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name.Equals("FolderPage"))
        {
            FolderPage.BoolRedraw = true;
        }
        if (currentScene.name.Equals("TagPage"))
        {
            TagPage.BoolRedraw = true;
        }

    }
    public void cancel()
    {
        Destroy(gameObject);
    }
}
