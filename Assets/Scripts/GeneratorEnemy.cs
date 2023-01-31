using System.Collections;
using UnityEngine;

public class GeneratorEnemy : MonoBehaviour
{
    public bool Playing = true;
    [SerializeField] private float delay = .0f;
    [SerializeField] private GameObject prefab;

    private void Start()
    {
        StartCoroutine(spawning());
        
    }
    private void spawnEnemy()
    {
        Vector2 position = new Vector2(transform.position.x, Random.Range(-4, 4));
        GameObject enemy = Instantiate(prefab, position, new Quaternion());
    } 
    private IEnumerator spawning()
    {   
        while(Playing)
        {
            yield return new WaitForSeconds(delay);
            spawnEnemy();
        }
    }
}
