using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagEntity
{
    // Start is called before the first frame update
    public string name;
    public Dictionary<string, ProjectEntity> ProjectList;

    public TagEntity(string n)
    {
        name = n;
        ProjectList = new Dictionary<string, ProjectEntity>();
    }
}
