        public static bool StrCheck(string line, string pattern)
        {
            int sLen = line.Length;
            int tLen = pattern.Length;
            int len = sLen < tLen ? sLen : tLen;
            int t = 0;
            for (int i = 0; i < len; i++)
            {
                char c = pattern[0];

                if (c == '*')
                {
                    bool onlyStars = true;
                    for(int z = 0; z<pattern.Length;z++)
                    {
                        if (pattern[z] != '*') onlyStars = false;
                    }
                    if (onlyStars) return true;
                    int newPatternIndex = 0;
                    int qCount = QuestionsCount(pattern, out newPatternIndex);
                    pattern = pattern.Substring(newPatternIndex);
                    int remainder = sLen - i;
                    if (remainder < qCount) return false;
                    if (pattern[0] == '\0') return true;
                    if (remainder == qCount) return false;
                    for (int j = i + qCount; j < sLen; j++)
                    {
                        if (StrCheck(line.Substring(j), pattern)) return true;

                    }
                    return false;
                }
                //i++;
                pattern = pattern.Substring(1);
                if (c == '?') continue;
                if (c != line[i]) return false;

            }
            if (sLen == tLen) return true;
            if (sLen > tLen) return false;
            return AreStars(pattern);
        }


        public static int QuestionsCount(string pattern, out int newIndex)
        {
            int qCount = 0;
            newIndex = 0;
            for (int i = 0; i < pattern.Length; i++)
            {
                newIndex = i;
                switch (pattern[i])
                {
                    case '?':
                        qCount++;
                        break;
                    case '*': continue;
                    default: return qCount;
                }
            }
            return qCount;
        }

        public static bool AreStars(string pattern)
        {
            int i = 0;
            do
            {
                if (pattern[i] != '*')
                {
                    return false;
                }
                i++;
            } while (i < pattern.Length);
            return true;
        }
    