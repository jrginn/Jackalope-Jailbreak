using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject balloon;
    public int balloonNum;

    private Vector2[,] grid;
    private bool[,] balloonLoc;
    private static int spawnGridSize = 5;
    // Start is called before the first frame update
    void Start()
    {
        // Similar easy algorithm for pumpkin panic, define a grid (5x5) of coords
        grid = new Vector2[spawnGridSize,spawnGridSize]; // 2m/.4m (.3m balloon) = 5
        balloonLoc = new bool[spawnGridSize,spawnGridSize];

        // Populate 2D coordinate grid
        // Local x,y coords -.45 < x < .45
        // Increments are .2
        Vector2 currentPos = new Vector2(-0.45f,0.45f);
        for (int i = 0; i < spawnGridSize; i++) // Rows
        {
            for (int j = 0; j < spawnGridSize; j++) // Columns
            {
                grid[i, j] = new Vector2(currentPos.x,currentPos.y);
                currentPos.y += .2f;
            }
            currentPos.x += .2f;
        }

        // Populate & spawn
        for (int i = 0; i < balloonNum; i++)
        {
            int spawnX = Random.Range(0, spawnGridSize), spawnY = Random.Range(0, spawnGridSize);
            // Ensure balloons are not in the same spot
            while (balloonLoc[spawnX,spawnY])
            {
                spawnX = Random.Range(0, spawnGridSize);
                spawnY = Random.Range(0, spawnGridSize);
            }
            balloonLoc[spawnX, spawnY] = true;
            // Spawn balloon here with this as the parent
            Instantiate(balloon, 
                new Vector3(grid[spawnX, spawnY].x, grid[spawnX, spawnY].y, -1.0f),
                Quaternion.identity, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
