using System;
using UnityEditor;
using UnityEngine;

public class CreateNewScriptClassFromCustomTemplate
{
    [MenuItem("CONTEXT/MonoBehaviour/Create Editor Script")]
    public static void CreateScriptFromTemplate(MenuCommand cmd)
    {
        var o = Resources.Load("Templates/NewEditorScript.cs");
        // Debug.Log(o);
        var path = AssetDatabase.GetAssetPath(o);
        // Debug.Log(path);

        
        if (AssetDatabase.IsValidFolder("Assets/Editor"))
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path,
                $"Assets/Editor/{cmd.context.GetType().ToString()}.cs");
        }
        else
        {
            AssetDatabase.CreateFolder("Assets", "Editor");
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path,
                $"Assets/Editor/{cmd.context.GetType().ToString()}.cs");
        }
    }
}
