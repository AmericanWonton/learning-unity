using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public GameObject titleScreen;
    public Button restartButton;
    public bool isGameActive;
    public TextMeshPro gameOverText;
    public TextMeshProUGUI scoreText;
    private int score = 0;
    private float spawnRate = 1.0f;
    public List<GameObject> targets;
    // Start is called before the first frame update
    void Start()
    {

        //isGameActive = true;
        /* Display the Score */
        //score = 0;
        //UpdateScore(0);
        //StartCoroutine(SpawnTarget());
        //gameOverText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* This actually starts the game when the buttons are clicked */
    public void StartGame(int theDifficulty)
    {
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        /* Set spawn rate based on difficulty */
        spawnRate /= theDifficulty;
    }

    /* Creates condition for losing the game */
    public void GameOver() 
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        /* Make button visible */
        restartButton.gameObject.SetActive(true);
    }

    /* Restarts game when button is clicked */
    public void RestartGame() 
    {
        /* This can reload the scene in Unity to play again */
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /* Used to randomly spawn a target every few seconds */
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            /* Update the score(DEGUG) */
            //UpdateScore(5);
        }
    }

    /* Used to update and keep track of the score */
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
