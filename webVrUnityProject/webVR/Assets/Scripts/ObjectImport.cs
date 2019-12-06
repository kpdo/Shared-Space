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
    private void Start()
    {
        importer.ImportedModel += ImportedModel;

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
        

    }

    private void ImportedModel(GameObject model, string filePath)
    {

        GameObject catalogButton = Instantiate(catalogObjPrefab);
        catalogButton.transform.SetParent(catalogContainer.content, false);
        int pTo = filePath.LastIndexOf(".obj");
        string fileName = filePath.Substring(0, pTo);
        print(fileName);
        int pFrom = filePath.LastIndexOf("/")+1;
        print(pFrom);
        fileName = fileName.Substring(pFrom);
        model.name = fileName;
        catalogButton.GetComponent<CatalogObject>().SetObject(fileName, model);
    }
}
