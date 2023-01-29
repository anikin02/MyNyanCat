using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 0, -10);
    }   
}
