namespace c275{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution {
    public int HIndex(int[] citations) {
        if (citations.Length == 0) return 0;
       
        int n = citations.Length, low = 0, high = n-1;
        while (low <= high){
            int mid = (low + high)/2;
            if (citations[mid] >= n-mid)
            {
                high = mid-1;
            }
            else
            {
                low = mid +1;
            }
        }
        
        return n - high - 1;
    }

}
}