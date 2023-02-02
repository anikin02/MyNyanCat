using UnityEngine;

public class GeneratorSimpleStars : MonoBehaviour
{
    public bool Playing = true;
    [SerializeField] private float tempPositionX = -6.5f;
    [SerializeField] private float offset = 33.5f;
    [SerializeField] private GameObject prefab;

    private void Update()
    {
        spawnPrefabs();
    }
    private void spawnPrefabs()
    {
        if ((tempPositionX + offset) <= transform.position.x)
        {
            Vector2 position = new Vector2(transform.position.x, 3.5f);
            GameObject newGameObject = Instantiate(
                prefab,
                transform.position,
                new Quaternion());
            tempPositionX = transform.position.x;
        }
    } 
}
