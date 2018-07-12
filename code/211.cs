namespace c211{
using System;
using System.Collections.Generic;

public class WordDictionary {
    private IList<int[]> dict = new List<int[]>();

    /** Initialize your data structure here. */
    public WordDictionary() {
        
    }
    
    /** Adds a word into the data structure. */
    public void AddWord(string word) {
        var arr = word.ToCharArray();
        for(int i=0; i<arr.Length; i++)
        {
            if (dict.Count <= i) dict.Add(new int[26]);

            dict[i][arr[i]-'a'] = (i==arr.Length-1? 2 : 1);
        }
    }
    
    /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
    public bool Search(string word) {
        var arr = word.ToCharArray();
        if (arr.Length> dict.Count) return false;

        int i=0;
        for(; i<arr.Length; i++)
        {
            if (arr[i]=='.')
                continue;
            
            if (dict[i][arr[i]-'a'] == 0) return false;
        }

        return dict[i-1][arr[i-1]-'a'] == 2;
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */
}