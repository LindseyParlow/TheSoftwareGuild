using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            string multipyString = str;
            for (int i=0; i <n-1; i++)
            {
                multipyString += str;
            }
            return multipyString;
        }

        public string FrontTimes(string str, int n)
        {
            string repeatString = str.Substring(0,3);
            for (int i = 0; i < n-1; i++)
            if (str.Length < 2)
            {
                repeatString += str;
            }
            else
            {
                repeatString += str.Substring(0, 3);
            }
            return repeatString;
        }

        public int CountXX(string str)
        {
            int doubleX = 0;
            for (int i = 0; i <str.Length-1; i++)
                if(str[i]==str[i+1])
                {
                    doubleX += 1;
                }
                else
                {
                    continue;
                }
            return doubleX;
        }

        public bool DoubleX(string str)
        {
            throw new NotImplementedException();
        }

        public string EveryOther(string str)
        {
            string newHello = str;
            for (int i = 0; i < str.Length; i += 2)
                newHello = str.Replace("a","o);
            return newHello;
        }

        public string StringSplosion(string str)
        {
            throw new NotImplementedException();
        }

        public int CountLast2(string str)
        {
            throw new NotImplementedException();
        }

        public int Count9(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public bool ArrayFront9(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public bool Array123(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public int SubStringMatch(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string StringX(string str)
        {
            throw new NotImplementedException();
        }

        public string AltPairs(string str)
        {
            throw new NotImplementedException();
        }

        public string DoNotYak(string str)
        {
            throw new NotImplementedException();
        }

        public int Array667(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public bool NoTriples(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public bool Pattern51(int[] numbers)
        {
            throw new NotImplementedException();
        }

    }
}
