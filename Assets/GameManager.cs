using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> bricks = new List<GameObject>();
    public ArcanoidBall ball;
    public bool gameRun = false;

    //public GameObject EndGameText;
    //public TMP_Text bricksCounter;
    //public TMP_Text livesCounter;
    //public TMP_Text levelCounter;
    //public TMP_Text winText;

    int currentLevel;
    public int maxLevel = 3;
    public BricksGenerator generator;
    public int lives;


    void Awake()
    {
        currentLevel = 1;
        lives = 3;

        //EndGameText.SetActive(false);

        if (instance == null)
        {
            instance = this;
        }

        //bricks.AddRange(GameObject.FindGameObjectsWithTag("Brick"));

    }

    void Update()
    {
        //Rozpoczêcie gry
        if (Input.GetKeyDown(KeyCode.Space) && !gameRun)
        {
            ball.RunBall();
            gameRun = true;
        }


        //Koniec gry przy stracie ca³ego ¿ycia
        if (gameRun && lives <= 0)
        {
            EndGame(false);
        }


        //Koniec gry w przypadku zbicia wszystkich bloczków na ostatnim poziomie
        if (gameRun && bricks.Count == 0 && currentLevel == maxLevel)
        {
            EndGame(true);
        }

        ////
        if ((gameRun && bricks.Count == 0 && currentLevel < maxLevel))
        {
            currentLevel++;
            ball.StopBall();
            generator.StartLevel(currentLevel);
        }



        if (!gameRun)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    }


    ////
    public void EndGame(bool win)
    {
        //EndGameText.SetActive(true);
        gameRun = false;
        //winText.text = "You: " + (win ? "Win!" : "Lose!");
        ball.StopBall();
    }

    //
    public void UpdateUI()
    {
        //bricksCounter.text = "Bricks left: " + bricks.Count;
        //livesCounter.text = "Lives: " + lives.ToString();
        //levelCounter.text = "Level: " + currentLevel.ToString();
    }

}