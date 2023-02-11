using UnityEngine;
using System.IO;
using System;

public class LoadSave : MonoBehaviour
{
    private Save save;
    private string path;

    void Start()
    {
        path = Path.Combine(Application.persistentDataPath, "Save.json");
        
        loadSave();
    }

    private void loadSave()
    {
        if (File.Exists(path))
        {   
            save = JsonUtility.FromJson<Save>(File.ReadAllText(path));
            RecordData.Record = save.Record; 
        }
    }
}

[Serializable]
class Save
{
    public int Record;
}