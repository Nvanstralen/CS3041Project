using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectEntity
{
    public string name;
    public string text;
    public Dictionary<string, TagEntity> TagList;
    public FolderEntity parent;
    public ProjectEntity(string n)
    {
        TagList = new Dictionary<string, TagEntity>();
        name = n;
    }
}
