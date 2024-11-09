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
    public TextMeshProUGUI score;
    public TextMeshProUGUI gameEndScore;
    public TextMeshProUGUI timer;
    public int currentScore;
    public int currentTime = 30;
    public GameObject gameOver;
    public bool _gameOver;
    public bool gameStarted;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        if (!_gameOver)
        {
            StartCoroutine("spawnManager");
        }
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
            while (true)
            {
                yield return new WaitForSeconds(1);
                int index = Random.Range(0, objects.Count);
                Instantiate(objects[index]);
            }
    }

    public void GameOver()
    {
        _gameOver = true;
        gameOver.SetActive(true);
        gameEndScore.text = $"Score: {currentScore:D3}";
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
