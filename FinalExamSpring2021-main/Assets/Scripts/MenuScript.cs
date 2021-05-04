using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public InputField inputField_name;
    public Slider slider_time;
    public Dropdown dropdown_lives;

    void Start()
    {
        PlayerPrefs.SetString("name", "");
        PlayerPrefs.SetFloat("time", 45);
        PlayerPrefs.SetInt("lives", 1);
    }

    public void SetName()
    {
        PlayerPrefs.SetString("name", inputField_name.text);
    }

    public void SetTime()
    {
        PlayerPrefs.SetFloat("time", slider_time.value);
    }

    public void SetLives()
    {
        PlayerPrefs.SetInt("lives", dropdown_lives.value + 1); ;
    }
}
