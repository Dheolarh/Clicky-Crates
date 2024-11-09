using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> objects;
    public GameObject bombExplosion;
    public GameObject coinExplosion;
    public GameObject startScreen;
    public TextMeshProUGUI score;
    public TextMeshProUGUI gameEndScore;
    public TextMeshProUGUI timer;
    private float spawnRate = 2;
    public int currentScore;
    public int currentTime = 30;
    public GameObject gameOver;
    public bool _gameOver;
    public bool gameStarted;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartGame(float difficulty)
    {
        spawnRate /= difficulty;
        currentScore = 0;
        startScreen.SetActive(false);
        StartCoroutine("spawnManager");
        InvokeRepeating("CountDownTimer", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        score.text = $"Score: {currentScore}".ToString();
    }

    void CountDownTimer()
    {
        if (currentTime > 0)
        {
            currentTime--;
            timer.text = $"00:{currentTime:D2}";
        }
        else
        {
            GameOver();
            CancelInvoke("CountDownTimer");
        }
    }

    IEnumerator spawnManager()
    {
            while (!_gameOver)
            {
                yield return new WaitForSeconds(spawnRate);
                int index = Random.Range(0, objects.Count);
                Instantiate(objects[index]);
            }
    }

    public void GameOver()
    {
        _gameOver = true;
        gameOver.SetActive(true);
        if (currentScore <= 0)
        {
            currentScore = 0;
        }
        gameEndScore.text = $"Score: {currentScore:D3}";
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
