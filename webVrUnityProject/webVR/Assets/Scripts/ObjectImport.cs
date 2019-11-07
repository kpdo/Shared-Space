using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AsImpL;

public class ObjectImport : MonoBehaviour
{
    public static ObjectImport instance;
    public ObjectImporter importer;
    public GameObject catalogObjPrefab;
    public UnityEngine.UI.ScrollRect catalogContainer;

    [Tooltip("Default import options")]
    public ImportOptions defaultImportOptions = new ImportOptions();

    [SerializeField]
    private PathSettings pathSettings = null;

    private void Awake()
    {
        instance = this;
    }

    public string RootPath
    {
        get
        {
            return pathSettings != null ? pathSettings.RootPath : "";
        }
    }

    public void SetOptions()
    {
        ImportOptions i = new ImportOptions();
       

    }
    public void ImportModelURL(string url)
    {
        string filePath = RootPath + url;

        if (string.IsNullOrEmpty(filePath))
        {
            Debug.LogErrorFormat("File path missing for the model at position {0} in the list.");
            return;
        }
        ImportOptions options = defaultImportOptions;
        importer.ImportModelAsync("Model", filePath, transform, options);
        GameObject text = Instantiate(catalogObjPrefab, catalogContainer.content);
        int pFrom = filePath.IndexOf("/o/") +3;
        int pTo = filePath.LastIndexOf(".obj");

        string fileName = filePath.Substring(pFrom, pTo - pFrom);


        text.GetComponent<UnityEngine.UI.Text>().text = fileName;
    }
}
