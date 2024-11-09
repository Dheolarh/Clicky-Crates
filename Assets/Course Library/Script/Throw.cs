using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Throw : MonoBehaviour
{
    private Rigidbody _objects;
    private GameManager _gameManager;
    private float xRange = 4.5f;
    private float yRange = 0.5f;
    private int jumpForce;
    private int torque;
    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        transform.position = new Vector3(Random.Range(-xRange, xRange), -yRange);
        jumpForce = Random.Range(10, 15);
        torque = Random.Range(-10, 10);
        _objects = GetComponent<Rigidbody>();
        if (!_gameManager._gameOver)
        {
            _objects.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _objects.AddTorque(torque, torque, torque, ForceMode.Impulse);
        }
    }
    
    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            if (_gameManager.bombExplosion == null)
            {
                Debug.Log("No bomb particle");
            }
            else
            {
                _gameManager.gameStarted = true;
                Instantiate(_gameManager.bombExplosion, gameObject.transform.position, _gameManager.bombExplosion.transform.rotation);
                _gameManager.currentScore -= 10;
                if (_gameManager.gameStarted && _gameManager.currentScore <= 0)
                {
                    _gameManager.GameOver();
                }
            }
        }

        if (gameObject.CompareTag("Cookie") || gameObject.CompareTag("Ball") || gameObject.CompareTag("Toast"))
        {
            if (_gameManager.coinExplosion == null)
            {
                Debug.Log("No coin particle");
            }
            else
            {
                _gameManager.gameStarted = true;
                Instantiate(_gameManager.coinExplosion, gameObject.transform.position, _gameManager.coinExplosion.transform.rotation);
                if (gameObject.CompareTag("Cookie"))
                {
                    _gameManager.currentScore += 5;
                }
                else if (gameObject.CompareTag("Toast"))
                {
                    _gameManager.currentScore += 2;
                }
                else if (gameObject.CompareTag("Ball"))
                {
                    _gameManager.currentScore++;
                }
            }
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

    }
}
