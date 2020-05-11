using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteTag : MonoBehaviour
{
    public GameObject Dropdown;
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

    // Update is called once per frame
    public void deleteTag()
    {
        Dropdown drop = Dropdown.GetComponent<Dropdown>();
        int index = drop.value;
        string selectedtag = tagnames[index];
        TagEntity seltag = Homepage.TagList[selectedtag];
        DeleteTagHelper(seltag);
        Destroy(gameObject);
        Homepage.BoolRedraw = true;
        TagPage.BoolRedraw = true;
        ProjectPage.BoolRedraw = true;
        FolderPage.BoolRedraw = true;
    }

    public void DeleteTagHelper(TagEntity t)
    {
        foreach (KeyValuePair<string, ProjectEntity> proj in t.ProjectList)
        {
            ProjectEntity project = proj.Value;
            project.TagList.Remove(t.name);
        }
        Homepage.TagList.Remove(t.name);
    }

    public void cancel()
    {
        Destroy(gameObject);
    }
}
