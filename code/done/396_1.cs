namespace c396_1{
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public IList<IList<int>> PalindromePairs(string[] words) {
        Dictionary<string, int> map = new Dictionary<string, int>();
        IList<IList<int>> result = new List<IList<int>>();
        for (int i = 0; i < words.Length; i++) {
            map[words[i]] = i;
        }
        for (int i = 0; i < words.Length; i++) {
            for (int j = 0; j < words[i].Length; j++) {
                CanMakePalindrome(words[i], j - 1, j, map, result, i);
                CanMakePalindrome(words[i], j - 1, j + 1, map, result, i);
            }
        }
        return result;
    }
    private void CanMakePalindrome(string word, int left, int right, Dictionary<string, int> map, IList<IList<int>> result, int index) {
        while (left >= 0 && right < word.Length){
            if (word[left] != word[right]){
                return;
            }
            left--;
            right++;
        }
        int lookup = -1;
        if (left < 0 && right >= word.Length && ReverseStringPresent(string.Empty, map, out lookup) && lookup != index){
            result.Add(new List<int>(){index, lookup});
            result.Add(new List<int>(){lookup, index});
        }
        else if (left >= 0 && ReverseStringPresent(word.Substring(0, left + 1), map, out lookup) && lookup != index){
            result.Add(new List<int>(){index, lookup});
        }
        else if (right < word.Length && ReverseStringPresent(word.Substring(right), map, out lookup) && lookup != index){
            result.Add(new List<int>(){lookup, index});
        }
    }
    private bool ReverseStringPresent(string substring, Dictionary<string, int> map, out int index){
        index = -1;
        char[] reversed = substring.ToCharArray();
        Array.Reverse(reversed);
        substring = new string(reversed);
        return map.TryGetValue(substring, out index);
    }
}
}