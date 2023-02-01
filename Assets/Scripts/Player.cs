using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public int Score = 0;
    public bool Playing = true;
    private bool isPowerUp = false;
    [SerializeField] private float moveSpeedStandart = 1f;
    [SerializeField] private float moveSpeedCape = 10f;
    [SerializeField] private float moveSpeedRoсket = 10f;
    [SerializeField] private SpawnerRainbow spawnerRainbow;

    private float moveSpeed;

    private IEnumerator upScore;
    private IEnumerator durationPowerUp;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        moveSpeed = moveSpeedStandart;
        upScore = upScoreCoroutine();
        durationPowerUp = PowerUpCoroutine();

        StartCoroutine(upScore);
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

    private IEnumerator upScoreCoroutine()
    {   
        while(Playing)
        {
            yield return new WaitForSeconds(1.0f);
            AddScore(1);
        }
    }
    private IEnumerator PowerUpCoroutine()
    {   
        while(Playing)
        {
            yield return new WaitForSeconds(10.0f);
            moveSpeed = moveSpeedStandart;
            PowerUp(999);
        }
    }

    public void AddScore(int points)
    {
        Score += points;
    }

    public void SubtractScore(int points)
    {
        if(!isPowerUp)
        {
            Score -= points;
        }
    }

    // Function that gives the player powerUp.
    // 0 - cape
    // 1 - rocket
    public void PowerUp(int type)
    {
        switch(type)
        {
            case 0:
                moveSpeed = moveSpeedCape;
                StartCoroutine(durationPowerUp);
                AddScore(10);
                animator.SetBool("isNormal", false);
                animator.SetBool("isCape", true);
                break;
            case 1:
                moveSpeed = moveSpeedRoсket;
                StartCoroutine(durationPowerUp);
                AddScore(25);
                animator.SetBool("isNormal", false);
                animator.SetBool("isRocket", true);
                break;
            default:
                StopCoroutine(durationPowerUp);
                durationPowerUp = PowerUpCoroutine();
                animator.SetBool("isCape", false);
                animator.SetBool("isRocket", false);
                animator.SetBool("isNormal", true);
                break;
        }
    }
}
