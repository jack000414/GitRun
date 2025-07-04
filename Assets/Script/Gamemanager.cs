using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public bool isGameOver = false;
    public TextMeshProUGUI scoreText;
    public GameObject gameoverUI;
    private int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다.");
            Destroy(gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void AddScore(int newScore)
    {
        if (!isGameOver)
        {
            score += newScore;
            scoreText.text = "Score: " + score;
        }
    }

    public void OnPlayerDead()
    {
        isGameOver = true;
        gameoverUI.SetActive(true);
        
    }
}
