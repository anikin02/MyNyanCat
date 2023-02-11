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
            Vector3 position = new Vector3(transform.position.x, 3.5f, 0);
            GameObject newGameObject = Instantiate(
                prefab,
                position,
                new Quaternion());
            tempPositionX = transform.position.x;
        }
    } 
}
