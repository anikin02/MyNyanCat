using UnityEngine.UI;
using UnityEngine;

public class RecordUI : MonoBehaviour
{
    [SerializeField] private Text record;

    private void Update()
    {
        record.text = ("Record: " + RecordData.Record.ToString());
    }
}
