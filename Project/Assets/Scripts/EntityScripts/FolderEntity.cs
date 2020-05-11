using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderEntity
{
    public string name;
    public Dictionary<string, ProjectEntity> ProjectList;
    public Dictionary<string, FolderEntity> FolderList;
    public FolderEntity parent;
    public FolderEntity(string n)
    {
        name = n;
        ProjectList = new Dictionary<string, ProjectEntity>();
        FolderList = new Dictionary<string, FolderEntity>();
    }
}
