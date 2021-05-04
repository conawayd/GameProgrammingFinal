using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FirstScene()
    {
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
