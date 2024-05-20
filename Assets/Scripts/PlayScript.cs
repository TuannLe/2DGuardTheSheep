using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{   
    //public AudioSource audioSource;
    //public AudioClip shootingAudio;
    public float speed = 10;
    public int Score { get; set; } = 0;
    public int Kill { get; set; } = 0;
    public int Lives { get; set; } = 5;
    public GameObject[] livesImage;
    public GameObject arrowPrefab;
    public Transform arrowPos;
    public Vector2 MovementInput;
    private float timer;
    public TextMeshProUGUI scoreText, killText;
    public GameObject gameOverPanel;
    AudioSource m_shootingSound;
    public GameOverScreen GameOverScreen;

    [SerializeField]
    private InputActionReference movement, shooting;
    InputEntry entries, data;
    private bool isDead;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_shootingSound = GetComponent<AudioSource>();
        data = FileHandler.ReadFromJSON<InputEntry>("Score.json");
    }

    void Update()
    {
        Pause();
        Run();

        timer += Time.deltaTime;
        if (timer > 0.5 && shooting.action.IsPressed())
        {
            m_shootingSound.Play();
            timer = 0;
            Shoot();
        }
        checkLive();
    }

    void Run()
    {
        MovementInput = movement.action.ReadValue<Vector2>();
        rb.velocity = new Vector2(rb.velocity.x, MovementInput.y * speed);
    }

    void Shoot()
    {
        Instantiate(arrowPrefab, arrowPos.position, transform.rotation);
    }

    public void CounterScore()
    {
        scoreText.text = Score.ToString("000000");
    }

    public void CounterKill()
    {
        killText.text = Kill.ToString("000");
    }

    void checkLive()
    {
        if(Lives <= 0 && !isDead)
        {
            isDead = true;
            Time.timeScale = 0;
            GameOver();
            if(data == null)
            {
                AddJsonFile();
            }
            else if(Score > data.score)
            {
                AddJsonFile();
            }
        } 
    }

    void AddJsonFile()
    {
        entries = new InputEntry(Score, Kill);
        FileHandler.SaveToJSON<InputEntry>(entries, "Score.json");
    }

    void GameOver()
    {
        GameOverScreen.Setup(Kill);
    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.GoToMenu(MenuName.Pause);
        }
    }
}
