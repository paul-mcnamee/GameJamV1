using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

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

    public static int width = 10;
    public static int height = 30;
    public int weight = 2;
    int seed = Random.Range(0, 255);


    //# --------------------------------------------------------------------
    //# 2. Set up constants to aid with describing the passage directions
    //# --------------------------------------------------------------------

    int N = 1;
    int S = 2;
    int E = 4;
    int W = 8;
    //# --------------------------------------------------------------------
    //# 3. Data structures to assist the algorithm
    //# --------------------------------------------------------------------

    int[,] grid = new int[height, width];

    //# --------------------------------------------------------------------
    //# 4. A simple routine to emit the maze as ASCII
    //# --------------------------------------------------------------------

    private void display_maze(int[,] grid)
    { }
}
//        print("\e[H"); // move to upper-left
//        print(" " + "_" * (grid[0].length * 2 - 1));
        
//        for (int x =0; x < width; x++) {
//            print("|");
         
//            for (int y = 0; y < height; y++) {
//          if (cell == 0 && y + 1 < grid.length && grid[y + 1][x] == 0)
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
//                }
//            else if (cell & E != 0)
//            {
//                print(((cell | row[x + 1]) & S != 0) ? " " : "_")}
//            else
//            {
//                print "|"
//                }
//        } }
//    puts
//}
//    }
             //   }

//# --------------------------------------------------------------------
//# 5. Sidewinder algorithm
//# --------------------------------------------------------------------
//private void algorithm() {
//    for (int y = 0; y < height; y++){
//        int run_start = 0;
//        for (int x = 0; x < width; x++) {
//            display_maze(grid);
//            if (y > 0 && (x + 1 == width || Random.Range(0, weight) == 0)) {
//                int cell = run_start + Random.Range(0, x - run_start + 1);
//                grid[y, cell] |= N;
//                grid[y - 1, cell] |= S;
//                run_start = x + 1; 
//            }
//            else if (x + 1 < width) {
//                grid[y,x] |= E;
//                grid[y,x + 1] |= W;
//            }
//        }
//    }
//}

//# --------------------------------------------------------------------
//# 6. Show the parameters used to build this maze, for repeatability
//# --------------------------------------------------------------------

