using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public int Score = 0;
    public bool Playing = true;
    private bool isPowerUp = false;

    [SerializeField] private float blinkTime = 0.5f;
    [SerializeField] private float moveSpeedStandart = 1f;
    [SerializeField] private float moveSpeedCape = 10f;
    [SerializeField] private float moveSpeedRoсket = 10f;
    [SerializeField] private SpawnerRainbow spawnerRainbow;
    [SerializeField] private Heart heartFirst;
    [SerializeField] private Heart heartSecond;
    [SerializeField] private Heart heartThird;
    [SerializeField] private GameObject music;
    [SerializeField] private RestartGame buttonRestart;

    [SerializeField] private FixedJoystick fixedJoystick;

    private int health = 3;
    private float moveSpeed;

    private IEnumerator upScore;
    private IEnumerator durationPowerUp;
    private Animator animator;

    private float vertical;

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
        die();
    }

    private void move()
    {
        if (Playing)
        {
            vertical = fixedJoystick.Vertical;
            var verticalPosition = vertical * moveSpeed * Time.deltaTime;
            
            if ((transform.position.y + verticalPosition > -4.7f) && (transform.position.y + verticalPosition < 4.7f))
            {
                transform.Translate(moveSpeed * Time.deltaTime, verticalPosition, 0);
            }
            else
            {
                transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            }

            spawnerRainbow.CreateRainbow();
        }
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
         Score -= points;
    }

    private IEnumerator blink()
    {   
        GetComponent<SpriteRenderer>().color = new Color32(205,120,120,255);
        yield return new WaitForSeconds(blinkTime);
        GetComponent<SpriteRenderer>().color = new Color32(255,255,255,255);
    }

    public void TakingDamage(int damage)
    {
        if (!isPowerUp)
        {
            SubtractScore(damage);
            StartCoroutine("blink");

            switch(health)
            {
                case 3:
                    heartThird.LoseHeart();
                    break;
                case 2:
                    heartSecond.LoseHeart();
                    break;
                case 1:
                    heartFirst.LoseHeart();
                    break;
                default:
                    break;
            }

            health--;
        }
    }

    // Function that gives the player powerUp.
    // 0 - cape
    // 1 - rocket
    public void PowerUp(int type)
    {
        isPowerUp = true;

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
                isPowerUp = false;
                StopCoroutine(durationPowerUp);
                durationPowerUp = PowerUpCoroutine();
                animator.SetBool("isCape", false);
                animator.SetBool("isRocket", false);
                animator.SetBool("isNormal", true);
                break;
        }
    }

    private void die()
    {
        if (health == 0)
        {
            Playing = false;
            
            music.GetComponent<AudioSource>().mute = true;
            GetComponent<Rigidbody2D>().gravityScale = 0.5f;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            buttonRestart.EnableButton();
        }
    }
}
