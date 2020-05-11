using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveSelection : MonoBehaviour
{

    public GameObject Dropdown;
    public static ProjectEntity proj;
    List<string> tagnames;
    // Start is called before the first frame update
    void Start()
    {
        if (proj.parent == null)
        {
            Dropdown drop = Dropdown.GetComponent<Dropdown>();
            drop.options.Clear();
            tagnames = new List<string>();
            foreach (KeyValuePair<string, FolderEntity> tag in Homepage.FolderList)
            {
                drop.options.Add(new Dropdown.OptionData() { text = tag.Key });
                tagnames.Add(tag.Key);
            }
        }
        else
        {
            Dropdown drop = Dropdown.GetComponent<Dropdown>();
            drop.options.Clear();
            tagnames = new List<string>();
            drop.options.Add(new Dropdown.OptionData() { text = "back" });
            tagnames.Add("back");
            foreach (KeyValuePair<string, FolderEntity> tag in proj.parent.FolderList)
            {
                drop.options.Add(new Dropdown.OptionData() { text = tag.Key });
                tagnames.Add(tag.Key);
            }
        }
    }


    public void cancel()
    {
        Destroy(gameObject);
    }

    public void selectTag()
    {
        if (proj.parent == null)
        {
            Dropdown drop = Dropdown.GetComponent<Dropdown>();
            int index = drop.value;
            string selfolder = tagnames[index];
            FolderEntity newfolder = Homepage.FolderList[selfolder];
            Homepage.ProjectList.Remove(proj.name);
            newfolder.ProjectList.Add(proj.name, proj);
            proj.parent = newfolder;
        }
        else
        {
            Dropdown drop = Dropdown.GetComponent<Dropdown>();
            int index = drop.value;
            string selfolder = tagnames[index];
            if(selfolder == "back")
            {
                if(proj.parent.parent == null)
                {
                    proj.parent.ProjectList.Remove(proj.name);
                    Homepage.ProjectList.Add(proj.name, proj);
                    proj.parent = null;
                }
                else
                {
                    FolderEntity newfolder = proj.parent.parent;
                    proj.parent.ProjectList.Remove(proj.name);
                    newfolder.ProjectList.Add(proj.name, proj);
                    proj.parent = newfolder;
                }
            }
            else
            {
                FolderEntity newfolder = proj.parent.FolderList[selfolder];
                proj.parent.ProjectList.Remove(proj.name);
                newfolder.ProjectList.Add(proj.name, proj);
                proj.parent = newfolder;
            }
            
        }
        
        addTag.BoolRedraw = true;
        Homepage.BoolRedraw = true;
        TagPage.BoolRedraw = true;
        FolderPage.BoolRedraw = true;
        Destroy(gameObject);
    }
}
