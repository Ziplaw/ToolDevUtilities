using System;
using UnityEditor;
using UnityEngine;

public class CreateNewScriptClassFromCustomTemplate
{
    private const string pathToYourScriptTemplate = "Assets/ToolCreationUtilities/Templates/NewEditorScript.cs.txt";
 
    [MenuItem("CONTEXT/MonoBehaviour/Create Editor Script")]
    public static void CreateScriptFromTemplate(MenuCommand cmd)
    {
        if (AssetDatabase.IsValidFolder("Assets/Editor"))
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(pathToYourScriptTemplate,
                $"Assets/Editor/{cmd.context.GetType().ToString()}.cs");
        }
        else
        {
            AssetDatabase.CreateFolder("Assets", "Editor");
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(pathToYourScriptTemplate,
                $"Assets/Editor/{cmd.context.GetType().ToString()}.cs");
        }
    }
}
