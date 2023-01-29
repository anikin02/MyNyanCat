using UnityEngine;

public class Rainbow : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        if (player.transform.position.x - transform.position.x > 30)
        {
            Destroy(gameObject);
        }
    }
}
