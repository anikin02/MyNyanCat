using UnityEngine;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(restartGame);
    }
    private void restartGame()
    {
        //GetComponent<ChangeScene>().changeScene();
    }

    public void EnableButton()
    {
        gameObject.SetActive(true);
    }
}
