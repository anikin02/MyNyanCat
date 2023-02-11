using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string NextScene;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(changeScene);
    }

    private void changeScene()
    {   
        SceneManager.LoadScene(NextScene);
    }   
}
