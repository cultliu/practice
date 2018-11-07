namespace c79{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution {
    public char[,] testdata = {{'A','B','C','E'},{'S','F','C','S'},{'A','D','E','E'}};
    public string testdata1 = "ABCCD";

    public bool Exist(char[,] board, string word) {
        int n = board.GetLength(0);
        int m = board.GetLength(1);
        var track = new bool[n,m];
        
        for(int i =0; i < n; i++)
        {
            for(int j = 0; j < m; j++)
            {
                if(visit(board, i, j, word, 0, track))
                {
                    return true;
                }
            }
        }
        
        return false;
    }
    
    public bool visit(char[,] board, int i, int j, string word, int index, bool[,] track)
    {
        if (i < 0 || i >= board.GetLength(0) || j < 0 || j >= board.GetLength(1))
            return false;
        
        if (track[i,j])
            return false;
        
        track[i,j] = true;
        
        bool result = false;
        if (board[i,j] == word[index])
        {
            if (index == word.Length -1 ) 
                result = true;

            result = result || visit(board, i-1, j, word, index+1, track) || visit(board, i, j-1, word, index+1, track) 
                || visit(board, i+1, j, word, index+1, track) || visit(board, i, j+1, word, index+1, track);
        }
        
        track[i,j] = false;
            
        return result;
    }
}
}