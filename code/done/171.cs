namespace c171{
public class Solution
{
    public int TitleToNumber(string s) {
        int n = s.Length, result = 0;
        for(int i=n-1; i>=0; i--)
        {
            result += (s[i]-'A'+1)*26*(n-i);
        }
        return result;
    }
}
}