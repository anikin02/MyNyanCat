using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Player player;

    // Update is called once per frame
    private void Update()
    {
        updateScore();
    }

    private void updateScore()
    {
        GetComponent<Text>().text = player.Score.ToString();
    }
}
