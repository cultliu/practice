namespace c172{
    public class Solution
    {
        int Do(int n)
        {
            int result =0;
            while(n/5 > 0)
            {
                result += n/5;
                n = n/5;
            }

            return result;
        }
    }
}