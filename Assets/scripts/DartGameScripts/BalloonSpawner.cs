using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject balloon;
    public int balloonNum;
    public int spawnGridSize = 5;
    // Used to link score counter with balloon pop component
    public GameObject scoreCounter;

    private Vector2[,] _grid;
    private bool[,] _balloonLoc;
    // Start is called before the first frame update
    void Start()
    {
        // Similar easy algorithm for pumpkin panic, define a grid of coords
        _grid = new Vector2[spawnGridSize,spawnGridSize];
        // And grid of where balloons are located
        _balloonLoc = new bool[spawnGridSize,spawnGridSize];

        // Finding distance between each balloon
        Renderer r = GetComponent<Renderer>();
        Vector2 increment = (new Vector2(r.bounds.size.x, r.bounds.size.y))
                             / (spawnGridSize + 1);

        // Finding world coordinate of top left corner = _grid[0,0]
        float leftEdge = transform.position.x - r.bounds.extents.x + increment.x;
        Vector2 currentPos = new Vector2(leftEdge,
                                        transform.position.y + r.bounds.extents.y - increment.y);
        // Get offset for balloon, first child should be the model w/ renderer
        Renderer balloonRenderer = balloon.transform.GetChild(0).GetComponent<Renderer>();
        // How far to offset balloons off of board (1/2 z offset)
        float zOff = balloonRenderer.bounds.extents.z;

        // Populate coordinate grid -- ROWS ARE Y
        for (int i = 0; i < spawnGridSize; i++) // Rows
        {
            for (int j = 0; j < spawnGridSize; j++) // Columns
            {
                _grid[i, j] = new Vector2(currentPos.x, currentPos.y);
                currentPos.x += increment.x;
            }
            currentPos.y -= increment.y;
            // Make sure x pos is reset to initial state
            currentPos.x = leftEdge;
        }

        // Populate & spawn
        for (int i = 0; i < balloonNum; i++)
        {
            int spawnX = Random.Range(0, spawnGridSize), spawnY = Random.Range(0, spawnGridSize);
            // Ensure balloons are not in the same spot
            while (_balloonLoc[spawnX,spawnY])
            {
                spawnX = Random.Range(0, spawnGridSize);
                spawnY = Random.Range(0, spawnGridSize);
            }
            _balloonLoc[spawnX, spawnY] = true;
            // Spawn balloon here (BOARD != parent to avoid scaling issues)
            GameObject clone = Instantiate(balloon, 
                new Vector3(_grid[spawnX, spawnY].x, _grid[spawnX, spawnY].y,
                transform.position.z - zOff), Quaternion.identity);
            clone.GetComponent<BalloonPop>().scoreCounter = scoreCounter;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
