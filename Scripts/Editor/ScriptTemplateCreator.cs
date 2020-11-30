using System;
using UnityEditor;
using UnityEngine;

public class CreateNewScriptClassFromCustomTemplate
{
    [MenuItem("CONTEXT/MonoBehaviour/Create Editor Script")]
    public static void CreateEditorScript(MenuCommand cmd)
    {
        var o = Resources.Load("Templates/NewEditorScript.cs");
        var path = AssetDatabase.GetAssetPath(o);

        
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
    
    [MenuItem("Assets/Create/Scripts/Create ScriptableObject Script",false,50)]
    public static void CreateScriptableObject()
    {
        var o = Resources.Load("Templates/NewScriptableObjectScript.cs");
        var path = AssetDatabase.GetAssetPath(o);
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path,$"NewScriptableObjectScript.cs"); }
}
