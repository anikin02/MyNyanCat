using System.Collections;
using UnityEngine;

public class GeneratorVertical : MonoBehaviour
{
    public bool Playing = true;
    [SerializeField] private float delay = .0f;
    [SerializeField] private GameObject[] prefabs;

    private void Start()
    {
        StartCoroutine(spawning());
    }
    private void spawnPrefabs()
    {
        Vector2 position = new Vector2(transform.position.x, Random.Range(-4.0f, 4.0f));
        GameObject newGameObject = Instantiate(
            prefabs[Random.Range(0, prefabs.Length)],
            position,
            new Quaternion());
    } 
    private IEnumerator spawning()
    {   
        while(Playing)
        {
            yield return new WaitForSeconds(delay);
            spawnPrefabs();
        }
    }
}
