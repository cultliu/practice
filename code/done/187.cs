namespace c187{
    using System.Collections.Generic;
    public class Solution
    {
        public IList<string> Do(string str)
        {
            int code = 0, i =0;
            for(; i<10; i++)
            {
                code <<= 2;
                code += Translate(str[i]);
            }
            var record = new HashSet<int>();
            var result = new HashSet<int>();
            record.Add(code);
            for (;i<str.Length;i++)
            {
                code <<=2;
                code += Translate(str[i]);
                code &= 0xFFFFF;
                if (record.Contains(code))
                {
                    result.Add(code);
                }
                else
                {
                    record.Add(code);
                }
            }

            var strResult = new List<string>();
            foreach(var it in result)
            {
                strResult.Add(TranslateBack(it));
            }
            return strResult;
        }

        int Translate(char ch) //fixed length 10 
        {
            switch(ch)
            {
                case 'A':
                return 0;
                case 'C':
                return 1;
                case 'G':
                return 2;
                case 'T':
                return 3;
            }
            return 0;
        }

        string TranslateBack(int code)
        {
            string result = "";
            for(int i=0; i<10; i++)
            {
                var bits = code & 3;
                char ch = '\0';
                switch (bits)
                {
                    case 0:
                     ch = 'A';
                     break;
                     case 1:
                     ch = 'C';
                     break;
                     case 2:
                     ch = 'G';
                     break;
                     case 3:
                     ch = 'T';
                     break;
                }
                result = ch + result;
                code >>= 2;
            }
            return result;
        }
    }
}