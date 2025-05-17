using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> bricks = new List<GameObject>();
    public ArcanoidBall ball;
    public bool isGameRunning = false;
    public int lives;

    void Awake()
    {
        if (instance == null)
        {
            instance = this.gameObject.GetComponent<GameManager>();
        }

        bricks.AddRange(GameObject.FindGameObjectsWithTag("Brick"));
        lives = 3;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !isGameRunning)
        {
            ball.RunBall();
            isGameRunning = true;
        }

        if (isGameRunning && bricks.Count <= 0)
        {
            EndGame(true);
        }

        if (!isGameRunning && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if (isGameRunning && lives <= 0)
        {
            EndGame(false);
        }
    }

    public void EndGame(bool isWin)
    {
        isGameRunning = false;
        string endGameText = isWin ? "Wygrana!" : "Przegrana!";
        Debug.Log(endGameText);
        ball.StopBall();
    }
}
