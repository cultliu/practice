namespace c913{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    static public void Main()
    {
        var so = new Solution();
        Console.WriteLine(so.CatMouseGame(new int[][]{
            new int[] {2,3},
            new int[] {3,4},
            new int[] {0,4},
            new int[] {0,1},
            new int[] {1,2}
            }));

        Console.WriteLine(so.CatMouseGame(new int[][]{
        new int[] {2,5},
        new int[] {3},
        new int[] {0,4,5},
        new int[] {1,4,5},
        new int[] {2,3},
        new int[] {0,2,3}
        }));

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
        var set = new HashSet<int>();
        var memory = new Dictionary<int, int>();
        return Helper(graph, set, memory, 1, 2, 1);
    }
    
    // turn 1: mouse, 2 cat. the same with winning result
    public int Helper(int[][] graph, HashSet<int> past, Dictionary<int, int> memory, int mouse, int cat, int turn)
    {
        int moveHash = Hash(cat, mouse, turn);
        if (memory.ContainsKey(moveHash))
        {
            return memory[moveHash];
        } 

        int result;
        if (cat == mouse)
        {
            result = 2;
        }
        else if (mouse == 0)
        {
            result = 1;
        }
        else if (past.Contains(moveHash))
        {
            result = 0;
        }
        else 
        {
            past.Add(moveHash);

            result = nextTurn(turn);
            int pos = (turn == 1)? mouse: cat;
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

                int res = Helper(graph, past, memory, mouseNext, catNext, nextTurn(turn));
                if (res == turn)
                {
                    result = turn;
                    break;
                }
                else if (res == 0)
                {
                    result = 0;
                }
            }

            past.Remove(moveHash);
        }

        memory[moveHash]= result;
        return result;
    }
    
    public int Hash(int cat, int mouse, int turn)
    {
        int val =  cat * 100 + mouse;
        return turn==1? val : (-1 * val);
    }

    public int nextTurn(int turn)
    {
        return turn==2 ? 1: 2;
    }
}
}