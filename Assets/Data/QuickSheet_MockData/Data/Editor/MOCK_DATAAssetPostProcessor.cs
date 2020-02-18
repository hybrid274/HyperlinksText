using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
public class MOCK_DATAAssetPostprocessor : AssetPostprocessor 
{
    private static readonly string filePath = "Assets/Data/QuickSheet_MockData/Excel/MOCK_DATA.xlsx";
    private static readonly string assetFilePath = "Assets/Data/QuickSheet_MockData/Excel/MOCK_DATA.asset";
    private static readonly string sheetName = "MOCK_DATA";
    
    static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (string asset in importedAssets) 
        {
            if (!filePath.Equals (asset))
                continue;
                
            MOCK_DATA data = (MOCK_DATA)AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(MOCK_DATA));
            if (data == null) {
                data = ScriptableObject.CreateInstance<MOCK_DATA> ();
                data.SheetName = filePath;
                data.WorksheetName = sheetName;
                AssetDatabase.CreateAsset ((ScriptableObject)data, assetFilePath);
                //data.hideFlags = HideFlags.NotEditable;
            }
            
            //data.dataArray = new ExcelQuery(filePath, sheetName).Deserialize<MOCK_DATAData>().ToArray();		

            //ScriptableObject obj = AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(ScriptableObject)) as ScriptableObject;
            //EditorUtility.SetDirty (obj);

            ExcelQuery query = new ExcelQuery(filePath, sheetName);
            if (query != null && query.IsValid())
            {
                data.dataArray = query.Deserialize<MOCK_DATAData>().ToArray();
                ScriptableObject obj = AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(ScriptableObject)) as ScriptableObject;
                EditorUtility.SetDirty (obj);
            }
        }
    }
}
