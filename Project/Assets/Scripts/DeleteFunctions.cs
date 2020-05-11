using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeleteFunctions : MonoBehaviour
{


    public void DeleteProject()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string name = gameObject.GetComponentInChildren<Text>().text;
        name = name.Substring(9, name.Length - 9);
        ProjectEntity project;
        if (currentScene.name.Equals("HomePage"))
        {
            project = Homepage.ProjectList[name];
        }
        else if (currentScene.name.Equals("FolderPage"))
        {
            project = FolderPage.folder.ProjectList[name];
        }
        else if (currentScene.name.Equals("TagPage"))
        {
            project = TagPage.CurrTag.ProjectList[name];
        }
        else
        {
            project = ProjectPage.project;
        }

        projectDeleteHelper(project);
        Homepage.BoolRedraw = true;
        TagPage.BoolRedraw = true;
        ProjectPage.BoolRedraw = true;
        FolderPage.BoolRedraw = true;
    }

    void projectDeleteHelper(ProjectEntity project)
    {
        if (project.parent != null)
        {
            project.parent.ProjectList.Remove(project.name);
        }
        else
        {
            Homepage.ProjectList.Remove(project.name);
        }
        foreach (KeyValuePair<string, TagEntity> tag in project.TagList)
        {
            TagEntity t = tag.Value;
            t.ProjectList.Remove(project.name);
        }
        Homepage.ProjectMasterList.Remove(project.name);
    }

    public void DeleteFolder()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string name = gameObject.GetComponentInChildren<Text>().text;
        FolderEntity folder;
        if (currentScene.name.Equals("HomePage"))
        {
            folder = Homepage.FolderList[name];
        }
        else
        {
            folder = FolderPage.folder.FolderList[name];
        }
        if (folder.parent != null)
        {
            folder.parent.FolderList.Remove(folder.name);
        }
        else
        {
            Homepage.FolderList.Remove(folder.name);
        }

        deleteFolderHelper(folder);

        Homepage.BoolRedraw = true;
        TagPage.BoolRedraw = true;
        ProjectPage.BoolRedraw = true;
        FolderPage.BoolRedraw = true;
    }

    void deleteFolderHelper(FolderEntity folder)
    {
        foreach (KeyValuePair<string, FolderEntity> Folder in folder.FolderList)
        {
            FolderEntity fold = Folder.Value;
            deleteFolderHelper(fold);
        }

        foreach (KeyValuePair<string, ProjectEntity> proj in folder.ProjectList)
        {
            ProjectEntity project = proj.Value;
            projectDeleteHelperForFolder(project);
        }
    }

    void projectDeleteHelperForFolder(ProjectEntity project)
    {
        foreach (KeyValuePair<string, TagEntity> tag in project.TagList)
        {
            TagEntity t = tag.Value;
            t.ProjectList.Remove(project.name);
        }
    }

}
