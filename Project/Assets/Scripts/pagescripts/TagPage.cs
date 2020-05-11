using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagPage : MonoBehaviour
{
    public GameObject TagPrefab;
    public GameObject ProjectPrefab;
    public GameObject NewTagWindow;

    public GameObject TagName;
    public GameObject TagLayout;
    public GameObject FolderLayout;

    public static TagEntity CurrTag;
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
        TagName.GetComponent<Text>().text = CurrTag.name;
        
        foreach (KeyValuePair<string, ProjectEntity> proj in CurrTag.ProjectList)
        {
            Vector2 CurrSize = FolderLayout.GetComponent<RectTransform>().sizeDelta;
            int buttonnum = CurrTag.ProjectList.Count;
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

    public void NewTag()
    {
        GameObject folderwin = GameObject.Instantiate(NewTagWindow) as GameObject;
        folderwin.transform.SetParent(transform);
    }
}