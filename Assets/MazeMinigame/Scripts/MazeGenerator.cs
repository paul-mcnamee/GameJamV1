using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    private GameObject[,] maze;
    public GameObject[] powerups;

    public static int width = 20;
    public static int height = 20;
    public int weight = 2;

    public GameObject wall;

    //# --------------------------------------------------------------------
    //# 2. Set up constants to aid with describing the passage directions
    //# --------------------------------------------------------------------

    const int N = 1;
    const int S = 2;
    const int E = 4;
    const int W = 8;
    //# --------------------------------------------------------------------
    //# 3. Data structures to assist the algorithm
    //# --------------------------------------------------------------------

    int[,] grid = new int[height, width];

    // Start is called before the first frame update
    void Start()
    {
        //generate mase
        algorithm();
        //instantiate maze walls
        maze = new GameObject[height*3,width*3];
        for(int i = 0; i < height*3; i++)
        {
            for (int j = 0; j < width*3; j++)
            {
                
                var obj = Instantiate(wall,
                    new Vector2(i * wall.GetComponent<Renderer>().bounds.size.x, j * wall.GetComponent<Renderer>().bounds.size.y),
                    Quaternion.identity);
                obj.transform.parent = transform;
                maze[i,j] = obj;
                
            }
        }
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                bool powerupPlaced = false;
                Destroy(maze[i * 3 + 1, j * 3 + 1]);
                //maze[i*3,j*3].GetComponent<Renderer>().material.color = Color.red;
                foreach (var pu in powerups)
                {
                    if (!powerupPlaced)
                    {
                        if (Random.Range(0, 100) < pu.GetComponent<Powerup>().getSpawnRate())
                        {
                            var obj = Instantiate(pu,
                        new Vector2((i *3+1)* wall.GetComponent<Renderer>().bounds.size.x, (j *3+1)* wall.GetComponent<Renderer>().bounds.size.y),
                        Quaternion.identity);
                            obj.transform.parent = transform;
                            powerupPlaced = true;
                        }
                    }
                }
                
                if ((grid[i, j] & N) == N)
                    Destroy(maze[i * 3 , j * 3 + 1]);
                if ((grid[i, j] & S) == S)
                    Destroy(maze[i * 3 + 2, j * 3 + 1]);
                if ((grid[i, j] & E) == E)
                    Destroy(maze[i * 3 + 1, j * 3 + 2]);
                if ((grid[i, j] & W) == W)
                    Destroy(maze[i * 3 + 1, j * 3]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //# --------------------------------------------------------------------
    //# An implementation of the Sidewinder algorithm for maze generation.
    //# This algorithm is kind of a cross between the trivial Binary Tree
    //# algorithm, and Eller's algorithm. Like the Binary Tree algorithm,
    //# the result is biased (but not as heavily).
    //#
    //# Because the Sidewinder algorithm only needs to consider the current
    //# row, it can be used (like the Binary Tree and Eller's algorithms)
    //# to generate infinitely large mazes.
    //# --------------------------------------------------------------------

    //# --------------------------------------------------------------------
    //# 1. Allow the maze to be customized via command-line parameters
    //# --------------------------------------------------------------------

   

    //# --------------------------------------------------------------------
    //# 4. A simple routine to emit the maze as ASCII
    //# --------------------------------------------------------------------

    //private void display_maze(int[,] grid)
    //{

    //    Debug.Log("\e[H"); // move to upper-left
    //    Debug.Log(" " + "_" * (height * 2 - 1));

    //    for (int x = 0; x < width; x++)
    //    {
    //        print("|");

    //        for (int y = 0; y < height; y++)
    //        {
    //            if (cell == 0 && y + 1 < grid.length && grid[y + 1][x] == 0)
    //            {
    //                print(" ");
    //            }
    //            else
    //            {
    //                print((cell & S != 0) ? " " : "_");
    //            }


    //            if (cell == 0 && x + 1 < row.length && row[x + 1] == 0)
    //            {
    //                print((y + 1 < grid.length && (grid[y + 1][x] == 0 || grid[y + 1][x + 1] == 0)) ? " " : "_")
    //                                }
    //            else if (cell & E != 0)
    //            {
    //                print(((cell | row[x + 1]) & S != 0) ? " " : "_")}
    //            else
    //            {
    //                print "|"
    //                                }
    //        }
    //    }
    //    puts
    //}



//# --------------------------------------------------------------------
//# 5. Sidewinder algorithm
//# --------------------------------------------------------------------
private void algorithm()
    {
        for (int y = 0; y < height; y++)
        {
            int run_start = 0;
            for (int x = 0; x < width; x++)
            {
                
                if (y > 0 && (x + 1 == width || Random.Range(0, weight) == 0))
                {
                    int cell = run_start + Random.Range(0, x - run_start + 1);
                    grid[y, cell] |= N;
                    grid[y - 1, cell] |= S;
                    run_start = x + 1;
                }
                else if (x + 1 < width)
                {
                    grid[y, x] |= E;
                    grid[y, x + 1] |= W;
                }
            }
        }
    }
}
//# --------------------------------------------------------------------
//# 6. Show the parameters used to build this maze, for repeatability
//# --------------------------------------------------------------------

