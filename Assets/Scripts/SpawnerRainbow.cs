using UnityEngine;

public class SpawnerRainbow : MonoBehaviour
{
    [SerializeField] private GameObject rainbowPrefab;

    public void CreateRainbow()
    {
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        GameObject newObject = Instantiate(rainbowPrefab, position, new Quaternion());
    }
}
