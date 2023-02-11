using System.IO;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    private string path;
    private Save save;

    private void Start()
    {
        path = Path.Combine(Application.persistentDataPath, "Save.json");
    }

    private void saveRecord()
    {
        save.Record = RecordData.Record;
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        { 
            saveRecord();
            File.WriteAllText(path, JsonUtility.ToJson(save));
        }   
    }
}