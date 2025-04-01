using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayBtn : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }
    public void Click()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void MainMenuOpen()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
