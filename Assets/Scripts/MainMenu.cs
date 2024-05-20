using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource soundButton;
    InputEntry entries;
    public TextMeshProUGUI scoreText, killText;


    private void Start()
    {
        entries = FileHandler.ReadFromJSON<InputEntry>("Score.json");
        if(entries != null)
        {
            scoreText.text = entries.score.ToString("0");
            killText.text = entries.kill.ToString("0");
        }
    }
    public void HandlePlayButtonOnClickEvent()
    {
        SceneManager.LoadScene("PlayScene");
        soundButton.Play();
    }

    public void HandleQuitButtonOnClickEvent()
    {
        Application.Quit();
        soundButton.Play();
    }
}
