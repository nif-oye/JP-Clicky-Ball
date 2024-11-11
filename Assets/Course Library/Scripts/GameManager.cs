using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    float spawnRate = 1;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI titleText;
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;
    public Button restartButton;
    int score;
    public bool gameOver = false;
    void Start()
    {
        
    }

    void Update()
    {

    }

    IEnumerator SpawnTarget()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        if (score >= 0)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            GameIsOver();
        }
    }

    public void StartGame(int difficulty){
        StartCoroutine(SpawnTarget());
        spawnRate /= difficulty;
        UpdateScore(0);
        score = 0;
        gameOver = false;
        titleText.gameObject.SetActive(false);
        easyButton.gameObject.SetActive(false);
        mediumButton.gameObject.SetActive(false);
        hardButton.gameObject.SetActive(false);
    }

    public void GameIsOver()
    {
        gameOver = true;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
