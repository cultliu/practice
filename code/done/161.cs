namespace c161{
    public class Solution
    {
        bool Do(string s1, string s2)
        {
            switch (s1.Length - s2.Length)
            {
                case 1:
                 return isRemove(s1,s2);
                 case -1:
                 return isRemove(s2,s1);
                 case 0:
                 return isModify(s1,s2);

                 default:
                 return false;
            }
        }

        bool isRemove(string s1, string s2)
        {
            int i=0;
            for(; i<s2.Length; i++)
            {
                if (s1[i] != s2[i]) break;
            }
            for(; i<s2.Length; i++)
            {
                if (s1[i+1] != s2[i]) return false;
            }
            return true;
        }

        bool isModify(string s1, string s2)
        {
            bool diffFound = false;
            for( int i=0; i<s2.Length; i++)
            {
                if (s1[i] != s2[i]) 
                {
                    if (diffFound) return false;
                    else { diffFound = true; i++;}
                };
            }
            return false;
        }
    }
}