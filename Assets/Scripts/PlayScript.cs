using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{   
    public AudioSource audioSource;
    public AudioClip shootingAudio;
    public float speed = 10;
    public float maxY = 5f;
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

    [SerializeField]
    private InputActionReference movement, shooting;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_shootingSound = GetComponent<AudioSource>();
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
        if(Lives <= 0)
        {
            GameOver();
        } 
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        Destroy(gameObject);


    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.GoToMenu(MenuName.Pause);
        }
    }

    public void ReStart()
    {
        Debug.Log("Hello");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
