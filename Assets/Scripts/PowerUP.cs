using UnityEngine;

public class PowerUP : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1;
    [SerializeField] private int typePowerUp;
    private void Update()
    {
        hold();
    }

    private void hold()
    {
        Vector3 newRotation = new Vector3(0, 0, transform.eulerAngles.z + rotationSpeed * Time.deltaTime);
        transform.eulerAngles = newRotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            player.PowerUp(typePowerUp);
            Destroy(gameObject);
        }
    }
}
