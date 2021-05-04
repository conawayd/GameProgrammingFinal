using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    float timeRemaining;
    public Text timeText;
    public GameObject menu;
    private bool isPaused = false;

    void Start()
    {
        timeRemaining = PlayerPrefs.GetFloat("time");
        PlayerPrefs.SetInt("score", 0);
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;
        timeText.text = timeRemaining.ToString();

        if (timeRemaining <= 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }
    public void AddScore()
    {
        PlayerPrefs.SetFloat("score", PlayerPrefs.GetFloat("score") + 1);
    }

    public void SubtractScore()
    {
        PlayerPrefs.SetFloat("score", PlayerPrefs.GetFloat("score") - 1);
    }

    public void AddLife()
    {
        PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives") + 1);
    }

    public void SubtractLife()
    {
        PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives") - 1);
    }


    // Pause Menu Functions
    public void Pause()
    {
        menu.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Unpause()
    {
        menu.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
        isPaused = false;
    }

    public void LoadGame()
    {
        PlayerPrefs.SetFloat("score", PlayerPrefs.GetFloat("save_score"));
        PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("save_lives"));
        PlayerPrefs.SetString("name", PlayerPrefs.GetString("save_name"));
        PlayerPrefs.SetFloat("time", PlayerPrefs.GetFloat("save_time"));
        timeRemaining = PlayerPrefs.GetFloat("save_time");
        Unpause();
    }

    public void SaveGame()
    {
        PlayerPrefs.SetFloat("save_score", PlayerPrefs.GetFloat("score"));
        PlayerPrefs.SetInt("save_lives", PlayerPrefs.GetInt("lives"));
        PlayerPrefs.SetFloat("save_time", PlayerPrefs.GetFloat("time"));
        PlayerPrefs.SetString("save_name", PlayerPrefs.GetString("name"));
    }

    public void NewGame()
    {
        SceneManager.LoadScene(0);
    }
    
    public void SaveAsJson()
    {
        PlayerData playerData = new PlayerData();
        playerData.score = PlayerPrefs.GetFloat("score");
        playerData.lives = PlayerPrefs.GetInt("lives");
        playerData.time = PlayerPrefs.GetFloat("time");
        playerData.name = PlayerPrefs.GetString("name");

        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);
    }
    class PlayerData
    {
        public float score;
        public int lives;
        public float time;
        public string name;
    }
}