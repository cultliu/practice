namespace ab{
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

class Untitled {
    // 从每个点开始，找从这个点出发的所有单词组合
    public void getAllWords(char[,] board, String[] words) {
        // 构建字典树加速查找
        Trie trie = new Trie();
        foreach(String word in words) {
            trie.insert(word);
        }

        int m = board.length;
        int n = board[0].length;
        List<String> result = new ArrayList<>();
        // 每个点作为起点，可能会有不一样的结果
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                boolean[][] visited = new boolean[m][n];
                List<String> path = new ArrayList<>();
                findWords(result, board, visited, path, i, j, trie.root);
            }
        }

        System.out.println(result);
    }

    // 从i,j开始递归找到所有单词组合
    public void findWords(List<String> result, char[][] board, boolean[][] visited, List<String> words, int x, int y, TrieNode root) {

        int m = board.length;
        int n = board[0].length;
        for (int i = x; i < m; i++) {
            for (int j = y; j < n; j++) {
                List<List<Integer>> nextWordIndexes = new ArrayList<>();
                List<Integer> path = new ArrayList<>();
                // 获得从当前点开始的所有可能单词的indexes
                getNextWords(nextWordIndexes, board, visited, path, i, j, root);
                for (List<Integer> indexes : nextWordIndexes) {
                    // 设置visited为当前使用单词
                    String word = "";
                    for (int index : indexes) {
                        int row = index / n;
                        int col = index % n;
                        visited[row][col] = true;
                        word += board[row][col];
                    }

                    words.add(word);
                    // 只要更新了words，就保存一次words
                    if (words.size() > result.size()) {
                        result.clear();
                        result.addAll(words);
                    }
                    findWords(result, board, visited, words, i, j, root);

                    // 恢复visited
                    for (int index : indexes) {
                        int row = index / n;
                        int col = index % n;
                        visited[row][col] = false;
                    }
                    words.remove(words.size() - 1);
                }
            }
            // 只有第x行是从y开始，后面都从0开始
            y = 0;
        }
    }

    private void getNextWords(List<List<int>> words, char[,] board, bool[,] visited, List<int> path, int i, int j, TrieNode root) {
        if(i < 0 | i >= board.GetLength(0) || j < 0 || j >= board.GetLength(1)
            || visited[i,j] == true || root.children[board[i,j] - 'a'] == null) {
            return;
        }

        root = root.children[board[i,j] - 'a'];
        if(root.isWord) {
            List<int> newPath = new List<int>(path);
            newPath.Add(i * board.GetLength(1) + j);
            words.Add(newPath);
            return;
        }

        visited[i,j] = true;
        path.Add(i * board.GetLength(1) + j);
        getNextWords(words, board, visited, path, i + 1, j, root);
        getNextWords(words, board, visited, path, i - 1, j, root);
        getNextWords(words, board, visited, path, i, j + 1, root);
        getNextWords(words, board, visited, path, i, j - 1, root);
        path.RemoveAt(path.Count - 1);
        visited[i,j] = false;
    }

    class Trie {
        TrieNode root;

        Trie() {
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

    class TrieNode {
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
            "abc", "cfi", "beh", "defi", "gh"
        };

        Untitled s = new Untitled();
        s.getAllWords(board, words);
    }
}


}