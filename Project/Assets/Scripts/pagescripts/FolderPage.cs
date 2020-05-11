using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FolderPage : MonoBehaviour
{
    public GameObject TagPrefab;
    public GameObject FolderPrefab;
    public GameObject ProjectPrefab;
    public GameObject NewFolderWindow;
    public GameObject NewTagWindow;
    public GameObject NewProjectWindow;

    public GameObject FolderName;
    public GameObject TagLayout;
    public GameObject FolderLayout;

    public static FolderEntity folder;
    public static bool BoolRedraw = false;
    // Start is called before the first frame update
    void Start()
    {
        draw();
    }

    // Update is called once per frame
    void Update()
    {
        if (BoolRedraw)
        {

            redraw();
        }

    }

    void draw()
    {
        string source;
        if(folder.parent != null)
        {
            source = getParentName(folder.parent);
            source = source + "/" + folder.name;
        }
        else
        {
            source = folder.name;
        }
        
        FolderName.GetComponent<Text>().text = source;
        foreach (KeyValuePair<string, FolderEntity> Folder in folder.FolderList)
        {

            Vector2 CurrSize = FolderLayout.GetComponent<RectTransform>().sizeDelta;
            int buttonnum = folder.FolderList.Count;
            FolderLayout.GetComponent<RectTransform>().sizeDelta = new Vector2(CurrSize.x, 32 * buttonnum);

            GameObject folderobj = GameObject.Instantiate(FolderPrefab) as GameObject;
            folderobj.GetComponentInChildren<Text>().text = Folder.Key;
            folderobj.transform.SetParent(FolderLayout.transform);
        }
        foreach (KeyValuePair<string, ProjectEntity> proj in folder.ProjectList)
        {
            Vector2 CurrSize = FolderLayout.GetComponent<RectTransform>().sizeDelta;
            int buttonnum = folder.ProjectList.Count;
            FolderLayout.GetComponent<RectTransform>().sizeDelta = new Vector2(CurrSize.x, CurrSize.y + (32 * buttonnum));

            GameObject projobj = GameObject.Instantiate(ProjectPrefab) as GameObject;
            projobj.GetComponentInChildren<Text>().text = "Project: " + proj.Key;
            projobj.transform.SetParent(FolderLayout.transform);
        }

        int NewSize = 0;
        foreach (KeyValuePair<string, TagEntity> tag in Homepage.TagList)
        {
            Vector2 CurrSize = TagLayout.GetComponent<RectTransform>().sizeDelta;


            GameObject tagobj = GameObject.Instantiate(TagPrefab) as GameObject;
            tagobj.GetComponentInChildren<Text>().text = tag.Key;
            Vector2 ButtonSize = tagobj.GetComponent<RectTransform>().sizeDelta;
            int ButtonWidth = 20 + (8 * tag.Key.Length);

            tagobj.GetComponent<RectTransform>().sizeDelta = new Vector2(ButtonWidth, ButtonSize.y);
            NewSize += ButtonWidth;

            tagobj.transform.SetParent(TagLayout.transform);
            TagLayout.GetComponent<RectTransform>().sizeDelta = new Vector2(NewSize, CurrSize.y);
        }
        addTag.BoolRedraw = true;

    }

    void redraw()
    {
        foreach (Transform child in TagLayout.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        foreach (Transform child in FolderLayout.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        draw();
        BoolRedraw = false;
    }

    public void NewFolder()
    {
        GameObject folderwin = GameObject.Instantiate(NewFolderWindow) as GameObject;
        folderwin.transform.SetParent(transform);
    }
    public void NewTag()
    {
        GameObject folderwin = GameObject.Instantiate(NewTagWindow) as GameObject;
        folderwin.transform.SetParent(transform);
    }
    public void NewProject()
    {
        GameObject folderwin = GameObject.Instantiate(NewProjectWindow) as GameObject;
        folderwin.transform.SetParent(transform);
    }

    string getParentName(FolderEntity parent)
    {
        string source;
        if (parent.parent != null)
        {
            source = getParentName(parent.parent);
            source = source + "/" + parent.name;
        }
        else
        {
            source = parent.name;
        }
        return source;
    }
}
