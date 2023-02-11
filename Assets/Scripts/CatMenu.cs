using UnityEngine;

public class CatMenu : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0;
    [SerializeField] private float startX = -11.0f;
    [SerializeField] private float endX = 11.0f;

    private void Update()
    {
        move();
    }
    private void move()
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x >= endX)
        {
            Vector2 newPosition = new Vector2(startX, transform.position.y);
            transform.position = newPosition;
        }
    }
}
