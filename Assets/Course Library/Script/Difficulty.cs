using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    private Button _difficultyButton;
    private GameManager _startGame;
    public float difficulty;
    // Start is called before the first frame update
    void Start()
    {
        _difficultyButton = GetComponent<Button>();
        _startGame = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _difficultyButton.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        _startGame.StartGame(difficulty);
    }
}
