using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float offset = 0; 

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + offset, 0, -10);
    }   
}
