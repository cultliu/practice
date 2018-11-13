namespace c773{
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution1
{
    const int n = 2;
    const int m = 3;
    HashSet<string> hash = new HashSet<string>();

    public int[,] test = new int[,]{{4,1,2},{5,0,3}};

    string expect;
    public int SlidingPuzzle(int[,] board)
    {
        expect = BoardHash(new int[,]{{1,2,3},{4,5,0}});
        var boardHash = BoardHash(board);
        hash.Add(boardHash);
        return SlidingPuzzle(boardHash);
    }

    public int SlidingPuzzle(string boardHash) {
        if(boardHash == "012453")
        {
            int s = 1;
        }

        int count = 1;
        var curSteps = GetNextBoards(boardHash);

        while (curSteps.Count > 0)
        {
            var nextSteps = new List<string>();

            foreach(var step in curSteps)
            {
                if (step == expect)
                {
                    return count;
                }
                hash.Add(step);
            }

            foreach(var step in curSteps)
            {
                var next = GetNextBoards(step);
                foreach(var nextStep in next)
                {
                    if (!hash.Contains(nextStep))
                    {
                        nextSteps.Add(nextStep);
                    }
                }
            }
            curSteps = nextSteps;
            count++;
        }

        return -1;

    }
    
    
    public List<string> GetNextBoards(string boardHash)
    {
        var result = new List<string>();
        int i = 0;
        for(; i < m*n; i++)
        {
            if (boardHash[i] == '0')
            {
                break;
            }
        }
        
        result.Add(SwapPosition(boardHash, i%3, i%3+3));
        if (i%3 == 1 || i%3 == 0)
        {
            result.Add(SwapPosition(boardHash, i, i+1));
        }
        
        if (i%3 == 2 || i%3 == 1)
        {
            result.Add(SwapPosition(boardHash, i, i-1));
        }
        
        return result;
    }
    
    public string SwapPosition(string boardHash, int i, int j) 
    {
        char[] result = boardHash.ToArray();
        result[i] = boardHash[j];
        result[j] = boardHash[i];

        return new string(result);
    }
    

    public string BoardHash(int[,] board)
    {
        string hash = "";
        for (int i = 0 ; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                hash += board[i,j];
            }
        }
        return hash;
    }
}

public class Solution {
    const int n = 2;
    const int m = 3;
    HashSet<int> hash = new HashSet<int>();

    public int[,] test = new int[,]{{4,1,2},{5,0,3}};

    int expect;
    public int SlidingPuzzle(int[,] board) {
        expect = BoardHash(new int[,]{{1,2,3},{4,5,0}});
        var boardHash = BoardHash(board);
        hash.Add(boardHash);
        return SlidingPuzzle(boardHash);
    }
    
    
    public int SlidingPuzzle(int boardHash) {

        int count = 1;
        var curSteps = GetNextBoards(boardHash);

        while (curSteps.Count > 0)
        {
            var nextSteps = new List<int>();

            foreach(var step in curSteps)
            {
                if (step == expect)
                {
                    return count;
                }
                hash.Add(step);
            }

            foreach(var step in curSteps)
            {
                var next = GetNextBoards(step);
                foreach(var nextStep in next)
                {
                    if (!hash.Contains(nextStep))
                    {
                        nextSteps.Add(nextStep);
                    }
                }
            }
            curSteps = nextSteps;
            count++;
        }

        return -1;
    }
    
    
    public List<int> GetNextBoards(int boardHash)
    {
        var result = new List<int>();
        int i = 0;
        for(; i < m*n; i++)
        {
            if (((7<<((5 - i)*3)) & boardHash) == 0)
            {
                break;
            }
        }
        
        result.Add(SwapPosition(boardHash, i%3, i%3+3));
        if (i%3 == 1 || i%3 == 0)
        {
            result.Add(SwapPosition(boardHash, i, i+1));
        }
        
        if (i%3 == 2 || i%3 == 1)
        {
            result.Add(SwapPosition(boardHash, i, i-1));
        }
        
        return result;
    }
    
    public int SwapPosition(int boardHash, int i, int j) 
    {
        int v1 =  (boardHash >> (5-i)*3) & 7;
        int v2 =  (boardHash >> (5-j)*3) & 7;
        int mask = ~(7 << ((5-i)*3) | 7 <<((5-j)*3));
        
        int result = boardHash & mask;
        result |= v1 <<((5-j)*3);
        result |= v2 <<((5-i)*3);

        return result;
    }
    
    public int BoardHash(int[,] board)
    {
        int hash = 0;
        for (int i = 0 ; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                hash |= (7 & board[i,j]) << (5 - i*m - j)*3;
            }
        }
        return hash;
    }
}
}

