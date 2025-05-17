using UnityEngine;
using static UnityEditor.PlayerSettings;

public class BricsGenerator : MonoBehaviour
{
    public int[,] bricksArray = new int[,] {
        { 2,2,3,3,3,3,3,3, },
        { 2,2,3,3,3,3,3,2, },
        { 1,2,2,2,2,3,2,1, },
        { 0,2,2,2,2,3,1,0, },
        { 0,0,3,3,3,1,0,0, },
        { 0,0,0,1,1,0,0,0, },
    };

    public GameObject brick;

    public void GenerateBricks(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i,j] == 0)
                {
                    continue;
                }

                Vector3 position = new Vector3(-array.GetLength(1) / 2 + j, 4 - i * 0.4f, 0);
                GameObject b = Instantiate(brick, position, Quaternion.identity);
                b.transform.parent = gameObject.transform;
                b.GetComponent<BricksScript>().SetBrick(array[i, j]);
            }
        }

        GameManager.instance.bricks.AddRange(GameObject.FindGameObjectsWithTag("Brick"));
    }

    void Start()
    {
        GenerateBricks(bricksArray);
    }
}
