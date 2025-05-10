using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BricksGenerator : MonoBehaviour
{
    GameManager gameManager;

    public int[,] bricksArray = new int[,] {
    {0,0,0,0,2,0,0,0,0},
    {0,0,0,1,2,1,0,0,0},
    {0,0,2,2,2,2,2,0,0},
    {0,1,1,1,2,1,1,1,0},
    {0,0,0,0,2,0,0,0,0},

    };

    public int[,] bricksArray2 = new int[,] {
    {0,0,0,0,2,0,0,0,0},
    {0,0,0,1,2,1,0,0,0},
    {0,0,2,2,2,2,2,0,0},
    {0,1,1,1,2,1,1,1,0},
    {0,0,0,0,2,0,0,0,0}
    };

    public int[,] bricksArray3 = new int[,] {
    {0,0,3,0,0},
    {0,0,3,0,0},
    {0,2,3,2,2},
    {1,1,3,1,1},
    {0,2,3,2,0}
    };

    List<int[,]> levels = new List<int[,]>();
    public GameObject brick;

    void Start()
    {
        levels.Add(bricksArray);
        levels.Add(bricksArray2);
        levels.Add(bricksArray3);
        GameManager.instance.maxLevel = levels.Count;
        StartLevel(1);

        GenerateBricks(bricksArray2);
    }

    public void GenerateBricks(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] == 0) continue;
                Vector3 pos = new Vector3((-(array.GetLength(1) / 2) + (j * 1)), (4 - i * 0.3f), 0);
                GameObject b = Instantiate(brick, pos, Quaternion.identity);
                b.transform.parent = gameObject.transform;
                b.GetComponent<BricksScript>().SetBrick(array[i, j]);
            }
        }
        GameManager.instance.bricks.AddRange(GameObject.FindGameObjectsWithTag("Brick"));
    }

    public void StartLevel(int number)
    {
        GameManager.instance.bricks.Clear();
        GenerateBricks(levels[number - 1]);
        GameManager.instance.UpdateUI();

    }
}