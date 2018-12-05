namespace c913{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    static public void Main1()
    {
        var so = new Solution();
        // Console.WriteLine(so.CatMouseGame(new int[][]{
        //     new int[] {2,3},
        //     new int[] {3,4},
        //     new int[] {0,4},
        //     new int[] {0,1},
        //     new int[] {1,2}
        //     }));

        //0
        // Console.WriteLine(so.CatMouseGame(new int[][]{
        // new int[] {2,5},
        // new int[] {3},
        // new int[] {0,4,5},
        // new int[] {1,4,5},
        // new int[] {2,3},
        // new int[] {0,2,3}
        // }));

        // // 1
        Console.WriteLine(so.CatMouseGame(new int[][]{
        new int[] {6},
        new int[] {4},
        new int[] {9},
        new int[] {5},
        new int[] {1,5},
        new int[] {3, 4, 6},
        new int[] {0, 5, 10},
        new int[] {8, 9, 10},
        new int[] {7},
        new int[] {2, 7},
        new int[] {6, 7}
        }));
    }

    public int CatMouseGame(int[][] graph) {
        var past = new HashSet<int>();
        var visited = new Dictionary<int, int>();
        return Helper(graph, past, visited, 1, 2, 1, 0);
    }
    
    // turn 1: mouse, 2 cat. the same with winning result
    public int Helper(int[][] graph, HashSet<int> past, Dictionary<int, int> visited, int mouse, int cat, int turn, int deep)
    {
        string padding = "";
        for(int i = 0; i < deep; i++)
        {
            padding += " ";
        }
        Console.WriteLine(padding + mouse + "," + cat + "," +turn);

        int moveHash = Hash(mouse, cat, turn);
        //visited.Add(moveHash);
        if (!visited.ContainsKey(moveHash))
        {
            visited[moveHash] = -1;
        }
        // else if (visited[moveHash] != -1)
        // {
        //     return visited[moveHash];
        // }

        int nextTurn = NextTurn(turn);

        int result;
        if (cat == mouse)
        {
            result = 2;
        }
        else if (mouse == 0)
        {
            result = 1;
        }
        // else if (past.Contains(moveHash))
        // {
        //     result = 0;
        // }
        else 
        {
            past.Add(moveHash);

            result = -1;
            int pos = (turn == 1)? mouse: cat;
            int moveCount = 0;
            int[] nextResults = new int[3];
            foreach(int next in graph[pos])
            {
                if (next == 0 && turn == 2)
                {
                    continue;
                }
                int mouseNext = mouse, catNext = cat;
                if (turn == 1)
                {
                    mouseNext = next;
                }
                else
                {
                    catNext = next;
                }
                var nextHash = Hash(mouseNext, catNext, nextTurn);

                moveCount ++;
                if (visited.ContainsKey(nextHash) && visited[nextHash] == -1)
                {
                    continue;
                }

                int res = -1;
                
                if (visited.ContainsKey(nextHash))
                {
                    res = visited[nextHash];
                }
                else
                {
                    res = Helper(graph, past, visited, mouseNext, catNext, nextTurn, deep+1);
                }

                if (res == turn)
                {
                    result = turn;
                    break;
                }
                nextResults[res]++;
            }

            if (result != turn)
            {
                if(nextResults[nextTurn]>0 && nextResults[nextTurn] == moveCount)
                {
                    result = nextTurn;
                }
                else
                {
                    result = 0;
                }
            }

            past.Remove(moveHash);
        }



        Console.WriteLine(padding + mouse + "," + cat + "," +turn+ ":"+ result );
        visited[moveHash] = result;
        return result;
    }
    
    public int Hash(int mouse, int cat, int turn)
    {
        int val =  mouse * 100 + cat;
        return turn==1? val : (-1 * val);
    }

    public int NextTurn(int turn)
    {
        return turn==2 ? 1: 2;
    }
}
}