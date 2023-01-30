using UnityEngine;

public class DifferentGameObjects : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        deleteNeedless();
    }

    private void deleteNeedless()
    {
        if (player.transform.position.x - transform.position.x > 30)
        {
            Destroy(gameObject);
        }
    }
}
