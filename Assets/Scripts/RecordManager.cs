using UnityEngine.UI;
using UnityEngine;

public class RecordManager : MonoBehaviour
{
    [SerializeField] private Player player;

    private void Update()
    {
        updateRecord();
    }

    private void updateRecord()
    {
        if (RecordData.Record < player.Score)
        {
            RecordData.Record = player.Score;
        }

        GetComponent<Text>().text = RecordData.Record.ToString();
    }
}
