namespace c773{
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    const int n = 2;
    const int m = 3;
    const int mask = 1<<18-1;
    Dictionary<int,int> hash = new Dictionary<int,int>();

    int expect;
    public int SlidingPuzzle(int[,] board) {
        expect = BoardHash(new int[,]{{1,2,3},{4,5,0}});
        hash[expect] = 0;
        return SlidingPuzzle(BoardHash(board));
    }
    
    
    public int SlidingPuzzle(int boardHash) {
        int result = int.MaxValue;
        if (boardHash == expect)
        {
            return 0;
        }

        foreach(var board in GetNextBoards(boardHash))
        {
            if (!hash.ContainsKey(board)) 
            {
                hash.Add(board, int.MaxValue);
                var steps = SlidingPuzzle(board);
                if (steps != int.MaxValue)
                {
                    result = Math.Min(SlidingPuzzle(board)+1, result);
                }
            }
            else
            {
                if (hash[board] != int.MaxValue)
                {
                    result = Math.Min(hash[board]+1, result);
                }
            }
        }
        
        hash[boardHash] = Math.Min(result, hash[boardHash]);
        Console.WriteLine(result);
        return result;
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