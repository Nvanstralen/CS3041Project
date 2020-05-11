using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Homepage: MonoBehaviour
{
    public GameObject TagPrefab;
    public GameObject FolderPrefab;
    public GameObject ProjectPrefab;
    public GameObject NewFolderWindow;
    public GameObject NewTagWindow;
    public GameObject NewProjectWindow;

    public GameObject TagLayout;
    public GameObject FolderLayout;
    public static Dictionary<string, FolderEntity> FolderList = new Dictionary<string, FolderEntity>();
    public static Dictionary<string, TagEntity> TagList = new Dictionary<string, TagEntity>();
    public static Dictionary<string, ProjectEntity> ProjectList = new Dictionary<string, ProjectEntity>();
    public static Dictionary<string, ProjectEntity> ProjectMasterList = new Dictionary<string, ProjectEntity>();
    public static bool BoolRedraw = false;
    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = false;
        draw();
    }

    // Update is called once per frame
    void Update()
    {
        if(BoolRedraw)
        {
            
            redraw();
        }
        
    }

    void draw()
    {
        foreach (KeyValuePair < string,FolderEntity> Folder in FolderList)
        {

            Vector2 CurrSize = FolderLayout.GetComponent<RectTransform>().sizeDelta;
            int buttonnum = FolderList.Count;
            FolderLayout.GetComponent<RectTransform>().sizeDelta = new Vector2(CurrSize.x, 32 * buttonnum);

            GameObject folderobj = GameObject.Instantiate(FolderPrefab) as GameObject;
            folderobj.GetComponentInChildren<Text>().text = Folder.Key;
            folderobj.transform.SetParent(FolderLayout.transform);
        }
        foreach (KeyValuePair < string,ProjectEntity> proj in ProjectList)
        {
            Vector2 CurrSize = FolderLayout.GetComponent<RectTransform>().sizeDelta;
            int buttonnum = ProjectList.Count;
            FolderLayout.GetComponent<RectTransform>().sizeDelta = new Vector2(CurrSize.x, CurrSize.y + (32 * buttonnum));

            GameObject projobj = GameObject.Instantiate(ProjectPrefab) as GameObject;
            projobj.GetComponentInChildren<Text>().text = "Project: " + proj.Key;
            projobj.transform.SetParent(FolderLayout.transform);
        }
        
        int NewSize = 0;
        foreach (KeyValuePair < string,TagEntity> tag in TagList)
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
}
