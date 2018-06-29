namespace c168{
    public class Solution
    {
        public string ConvertToTitle(int n)
        {
            if (n == 0) return "";
            string result = string.Empty;

            while(n > 0)
            {
                result = (char)((n-1)%26 + 'A') + result;
                n=(n-1)/26;
            }
            return result;

        }
    }
}