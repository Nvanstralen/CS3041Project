using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectPage : MonoBehaviour
{
    public GameObject TagPrefab;

    public GameObject ProjectName;
    public GameObject TagLayout;
    public GameObject FolderLayout;
    public GameObject textfield;

    public static ProjectEntity project;
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
        ProjectName.GetComponent<Text>().text = project.name;

        int NewSize = 0;
        foreach (KeyValuePair<string, TagEntity> tag in project.TagList)
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
        textfield.GetComponent<InputField>().text = project.text;
        addTag.BoolRedraw = true;
    }

    void redraw()
    {
        foreach (Transform child in TagLayout.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        draw();
        BoolRedraw = false;
    }

    public void savetext()
    {
        project.text = textfield.GetComponent<InputField>().text;
        BoolRedraw = true;
    }


}
