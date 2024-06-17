using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
            
    }
    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
