using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage = 1; 
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            print("AHAHAHAHAHAHAH");
            collision.gameObject.GetComponent<Player>().SubtractScore(damage);
        }
    }
}
