using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage = 1; 
    [SerializeField] private float moveSpeed = 0;
    private bool isActive = true;

    private void Update()
    {
        move();
    }
    private void move()
    {
        transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if(!isActive)
        {
            return;
        }

        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            isActive = false;
            player.TakingDamage(damage);
        }
    }
}
