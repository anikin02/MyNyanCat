using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public int Score = 0;
    public bool Playing = true;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private SpawnerRainbow spawnerRainbow;

    private void Start()
    {
        StartCoroutine(upScore());
    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(moveSpeed * Time.deltaTime, vertical, 0);

        spawnerRainbow.CreateRainbow();
    }

    private IEnumerator upScore()
    {   
        while(Playing)
        {
            yield return new WaitForSeconds(1.0f);
            AddScore(1);
        }
    }

    public void AddScore(int points)
    {
        Score += points;
    }

    public void SubtractScore(int points)
    {
        Score -= points;
    }
}
