using UnityEngine;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour
{
    public Text name_text;
    public Text score_text;
    public Text lives_text;

    void Start()
    {
        name_text.text = PlayerPrefs.GetString("name");
        PlayerPrefs.SetFloat("score", 0);
    }

    void Update()
    {
        score_text.text = PlayerPrefs.GetFloat("score").ToString();
        lives_text.text = PlayerPrefs.GetInt("lives").ToString();
    }
}
