namespace c212{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    class Tire
    {
        public Tire[] children = new Tire[26];
        public bool isLeaf = false;
        public int index = -1;
    }

    // public char[,] testdata = new char[,] {{'o','a','a','n'},{'e','t','a','e'},{'i','h','k','r'},{'i','f','l','v'}};
    // public string[] testdata1 = new string[]{"oath","pea","eat","rain"};

    public char[,] testdata = new char[,] {{'a','b'},{'c','d'}};
    public string[] testdata1 = new string[]{"ab","cb","ad","bd","ac","ca","da","bc","db","adcb","dabc","abb","acb"};

    private void BuildTire(Tire root, string[] words, int wordIdx)
    {
        Tire cur = root;
        var word = words[wordIdx];
        for(int i=0; i<word.Length; i++)
        {
            int idx = word[i] - 'a';
            if(cur.children[idx] == null)
            {
                cur.children[idx] = new Tire();
            }

            cur = cur.children[idx];
            if (i == word.Length-1)
            {
                cur.isLeaf = true;
                cur.index = wordIdx;
            }
        }
    }
    

    public IList<string> FindWords(char[,] board, string[] words) {

        var results = new List<string>();
        Tire root = new Tire();

        for(int i = 0; i < words.Length; i++)
        {
            BuildTire(root, words, i);
        }

        int n = board.GetLength(0); 
        int m = board.GetLength(1);

        var track = new bool[n,m];

        for(int i=0; i < n; i++)
        {
            for(int j = 0; j < m; j++)
            {
                Find(board, i, j, root, track, words, results);
            }
        }

        return results;
    }

    void Find(char[,] board, int x, int y, Tire node, bool[,] track, string[] words, IList<string> results) 
    {
        if (x<0 || x >= board.GetLength(0) || y < 0 || y >= board.GetLength(1))
            return;

        if (track[x,y])
            return ;

        track[x,y] = true;

        int idx = board[x,y] - 'a';
        if (node.children[idx] != null)
        {
            if (node.children[idx].isLeaf)
            {
                results.Add(words[node.children[idx].index]);
            }

            Find(board, x-1, y, node.children[idx], track, words, results);
            Find(board, x, y-1, node.children[idx], track, words, results);
            Find(board, x+1, y, node.children[idx], track, words, results);
            Find(board, x, y+1, node.children[idx], track, words, results);
        }

        track[x,y] = false;

        return;
    }
}
}