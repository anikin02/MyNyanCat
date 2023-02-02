using UnityEngine;

public class StarPoints : MonoBehaviour
{
    [SerializeField] private int points = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            player.AddScore(points);
            Destroy(gameObject);
        }
    }
}
