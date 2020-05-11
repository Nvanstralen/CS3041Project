using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagSelection : MonoBehaviour
{
    public GameObject Dropdown;
    public static ProjectEntity proj;
    List<string> tagnames;
    // Start is called before the first frame update
    void Start()
    {
        Dropdown drop = Dropdown.GetComponent<Dropdown>();
        drop.options.Clear();
        tagnames = new List<string>();
        foreach (KeyValuePair<string, TagEntity> tag in Homepage.TagList)
        {
            drop.options.Add(new Dropdown.OptionData() { text = tag.Key });
            tagnames.Add(tag.Key);
        }
    }

    public void selectTag()
    {

        Dropdown drop = Dropdown.GetComponent<Dropdown>();
        int index = drop.value;
        string selectedtag = tagnames[index];
        TagEntity newtag = Homepage.TagList[selectedtag];
        newtag.ProjectList.Add(proj.name, proj);
        proj.TagList.Add(newtag.name, newtag);
        addTag.BoolRedraw = true;
        Destroy(gameObject);
    }

    public void RemoveTag()
    {

        Dropdown drop = Dropdown.GetComponent<Dropdown>();
        int index = drop.value;
        string selectedtag = tagnames[index];
        TagEntity newtag = Homepage.TagList[selectedtag];
        newtag.ProjectList.Remove(proj.name);
        proj.TagList.Remove(newtag.name);
        addTag.BoolRedraw = true;
        TagPage.BoolRedraw = true;
        Destroy(gameObject);
    }

    public void cancel()
    {
        Destroy(gameObject);
    }
}
