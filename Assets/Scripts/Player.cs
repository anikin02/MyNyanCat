using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public int Score = 0;
    public bool Playing = true;
    private bool isIncredible = false;
    [SerializeField] private float moveSpeedStandart = 1f;
    [SerializeField] private float moveSpeedIncredible = 10f;
    [SerializeField] private SpawnerRainbow spawnerRainbow;

    private float moveSpeed;

    private void Start()
    {
        moveSpeed = moveSpeedStandart;
        StartCoroutine(upScore());
    }
    private void Update()
    {
        move();
    }

    private void move()
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
        if(isIncredible)
        {
            Score -= points;
        }
    }

    // function that gives the player incredible strength for 10 seconds
    private void incredible()
    {
        isIncredible = true;
        moveSpeed = moveSpeedIncredible;   
    }
}
