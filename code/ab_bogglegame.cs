namespace ab_boggle{
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

class Untitled {
    // 从每个点开始，找从这个点出发的所有单词组合
    public List<String> getAllWords(char[,] board, String[] words) {
        // 构建字典树加速查找
        Trie trie = new Trie();
        foreach(String word in words) {
            trie.insert(word);
        }

        int m = board.GetLength(0);
        int n = board.GetLength(1);
        List<String> result = new List<String>();
        // 每个点作为起点，可能会有不一样的结果
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                var res = findAllWords(board, i, j, trie.root);
                if (res.Count > result.Count)
                {
                    result = res;
                }
            }
        }

        return result;
    }

    // find all words chain start from board[x,y]
     public List<String> findAllWords(char[,] board, int x, int y, TrieNode root)
     {
         // 1. find all words start with board[x,y]
        List<List<int[]>> stringPaths = FindWordsStartAt(board, x, y, root);
        
        foreach(var stringPath in stringPaths)
        {
            char[,] newBoard = board.Clone() as char[,];
            foreach(int[] pos in stringPath)
            {
                newBoard[pos[0],pos[1]] = '*';
            }

            
        }
     }


//     private void getNextWords(List<List<int>> words, char[,] board, bool[,] visited, List<int> path, int i, int j, TrieNode root) {
//         if(i < 0 | i >= board.GetLength(0) || j < 0 || j >= board.GetLength(1)
//             || visited[i,j] == true || root.children[board[i,j] - 'a'] == null) {
//             return;
//         }

//         root = root.children[board[i,j] - 'a'];
//         if(root.isWord) {
//             List<int> newPath = new List<int>(path);
//             newPath.Add(i * board.GetLength(1) + j);
//             words.Add(newPath);
//             return;
//         }

//         visited[i,j] = true;
//         path.Add(i * board.GetLength(1) + j);
//         getNextWords(words, board, visited, path, i + 1, j, root);
//         getNextWords(words, board, visited, path, i - 1, j, root);
//         getNextWords(words, board, visited, path, i, j + 1, root);
//         getNextWords(words, board, visited, path, i, j - 1, root);
//         path.RemoveAt(path.Count - 1);
//         visited[i,j] = false;
//     }

    public class Trie {
        public TrieNode root;

        public Trie() {
            root = new TrieNode('0');
        }

        public void insert(String word) {
            if(word == null || word.Length == 0) {
                return;
            }
            TrieNode node = root;
            for(int i = 0; i < word.Length; i++) {
                char ch = word[i];
                if(node.children[ch - 'a'] == null) {
                    node.children[ch - 'a'] = new TrieNode(ch);
                }
                node = node.children[ch - 'a'];
            }
            node.isWord = true;
        }
    }

    public class TrieNode {
        public char value;
        public bool isWord;
        public TrieNode[] children;

        public TrieNode(char v) {
            value = v;
            isWord = false;
            children = new TrieNode[26];
        }
    }

    public static void main(String[] args) {
        char[,] board = new char[,]{
            {'a', 'b', 'c'},
            {'d', 'e', 'f'},
            {'g', 'h', 'i'}
        };
        String[] words = new String[] {
            "abc", "cfi", "beh", "defi", "gh", "fed"
        };

        Untitled s = new Untitled();
        s.getAllWords(board, words);
    }
}
}

