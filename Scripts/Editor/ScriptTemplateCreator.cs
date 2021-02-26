using System;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public class CreateNewScriptClassFromCustomTemplate
{
    [MenuItem("Assets/Create Editor Script")]
    public static void CreateEditorScript()
    {
        var o = Resources.Load("Templates/NewEditorScript.cs");
        var path = AssetDatabase.GetAssetPath(o);
        var assetPath = AssetDatabase.GetAssetPath (Selection.activeObject);
        int indexToTrim = new string(assetPath.Reverse().ToArray()).IndexOf('/', 0, assetPath.Length);
        var trimmedAssetPath = assetPath.Remove(assetPath.Length - indexToTrim -1);
        var className = new string(new string(assetPath.Reverse().ToArray()).Remove(indexToTrim).Reverse().ToArray());
        
        
        if (AssetDatabase.IsValidFolder($"{trimmedAssetPath}/Editor"))
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path,
                $"{trimmedAssetPath}/Editor/{className}");
        }
        else
        {
            AssetDatabase.CreateFolder(trimmedAssetPath, "Editor");
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path,
                $"{trimmedAssetPath}/Editor/{className}");
        }
    }
    
    [MenuItem("Assets/Create/Scripts/Create ScriptableObject Script",false,50)]
    public static void CreateScriptableObject()
    {
        var o = Resources.Load("Templates/NewScriptableObjectScript.cs");
        var path = AssetDatabase.GetAssetPath(o);
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path,$"NewScriptableObjectScript.cs"); }
}
