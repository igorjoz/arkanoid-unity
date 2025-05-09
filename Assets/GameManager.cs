using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Instancja naszego Game Managera
    public static GameManager instance;
    //Lista cegie�ek
    public List<GameObject> bricks = new List<GameObject>();
    //Skrypt naszej kulki
    public ArcanoidBall ball;
    //czy gra trwa
    bool gameRun = false;

    void Awake()
    {
        //Przypisanie obiektu do instancji, stworzeie Singletona
        if (instance == null)
        {
            instance = this;
        }

        //Pobranie wszystkich mo�liwych cegie�ek, szukamy ich po tagu Brick i robimy z nich list�
        bricks.AddRange(GameObject.FindGameObjectsWithTag("Brick"));

    }

    void Update()
    {
        //Je�eli gra si� nie rozpocze�a i klikniemy spacj� to uruchamiamy pi�k�.
        if (Input.GetKeyDown(KeyCode.Space) && !gameRun)
        {
            ball.RunBall();
            gameRun = true;
        }

        //Je�eli znikn� wszystkie cegie�ki ko�czyy gr�
        if (gameRun && bricks.Count == 0)
        {
            EndGame(true);
        }

        //Je�eli gra sko�czona, to po naci�ni�ciu klawisza R zresetujemy scen�
        if (!gameRun)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    //Funkcja ko�cz�ca gr�
    public void EndGame(bool win)
    {
        gameRun = false;
        string txt = win ? "Wygrana!" : "Przegrana!";
        Debug.Log(txt);
        ball.StopBall();
    }
}