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
                if(str[i]== "x" && str[i+1] =="x")
                {
                    doubleX += 1;
                }
            return doubleX;
        }

        public bool DoubleX(string str)
        {
            bool hasDoubleX = false;
            int firstX = 0;
            firstX = str.IndexOf("x");
            for (int i = 0; i < str.Length-2; i++)
            {
                
                if (str.Contains("x")==false)
                {
                    hasDoubleX = false;
                }
                else if (str[firstX]==str[firstX+1])
                {
                    hasDoubleX = true;
                }
                else
                {
                    hasDoubleX = false;
                }
            }
            return hasDoubleX;
        }

        public string EveryOther(string str)
        {
            string isEveryOther = "";
            for (int i = 0; i < str.Length; i += 2)
            {
                isEveryOther += str[i];
            }
            return isEveryOther;
        }

        public string StringSplosion(string str)
        {
            string oneMoreLetter = "";
            for (int i = 0; i < str.Length; i++)
            {
                oneMoreLetter += str.Substring(0, i+1);
            }
            return oneMoreLetter;

           
        }

        public int CountLast2(string str)
        {
            
            int strCounter = 0;
            for (int i=0;i<str.Length-2;i++)
            {
                if (str.Substring(i,2)== str.Substring(str.Length - 2, 2))
                {
                    strCounter += 1;
                }
            }
            return strCounter;
        }

        public int Count9(int[] numbers)
        {
            int nineCounter = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 9)
                {
                    nineCounter++;
                }
            }
            return nineCounter;
        }

        public bool ArrayFront9(int[] numbers)
        {
            bool firstFour = false;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers.Length<4 && numbers[i]==9)
                {
                    firstFour = true;
                }
                if (numbers.Length>=4 && numbers[0]==9 || numbers[1] == 9 || numbers[2] == 9 || numbers[3] == 9)
                {
                    firstFour = true;
                }
            }
            return firstFour;
        }

        public bool Array123(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i] == 1 && numbers[i + 1] == 2 && numbers[i + 2] == 3)
                {
                    return true;
                }
            }
            return false;
        }

        public int SubStringMatch(string a, string b)
        {
            int matchTimes = 0;
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = 0; j < b.Length - 1; j++)
                {
                    if (a.Substring(i, 2) == b.Substring(j, 2)) 
                    {
                        matchTimes++;
                    }
                }
            }
            return matchTimes;
        }

        public string StringX(string str)
        {
            string newStr = str;
            for (int i = 1; i < str.Length-1; i++)
            {
                if (str.Substring(0, 1) == "x" && str.Substring(str.Length - 1, 1) == "x")
                {
                    newStr = "x" + str.Replace("x", "") + "x";
                }
                else if (str.Substring(0, 1) == "x" && str.Substring(str.Length - 1, 1) != "x")
                {
                    newStr = "x" + str.Replace("x", "");
                }
                else if (str.Substring(0, 1) != "x" && str.Substring(str.Length - 1, 1) == "x")
                {
                    newStr = str.Replace("x", "") + "x";
                }
                else 
                {
                    newStr = str.Replace("x", "");
                }
            }
            return newStr;
        }

        public string AltPairs(string str)
        {
            string everyOtherPair = "";
            for (int i = 0; i < str.Length-1; i+=4)
            {
                everyOtherPair += str.Substring(i, 2);
            }
            if ((str.Length - 1) % 4 == 0)
            {
                everyOtherPair = everyOtherPair + str.Substring(str.Length - 1, 1);
            }
                return everyOtherPair;
        }

        public string DoNotYak(string str)
        {
            string newString = str;
            for (int i = 0; i < str.Length-2; i ++)
                if (str.Substring(i,3)=="yak")
                {
                    newString = str.Remove(i, 3);
                }
            return newString;
        }

        public int Array667(int[] numbers)
        {
            int sixSixCount = 0;
            for (int i = 0; i < numbers.Length - 1; i ++)
                if ((numbers[i]==6 && (numbers[i+1]==6) || numbers[i + 1] == 7)))
                {
                    sixSixCount++;    
                }
            return sixSixCount;
        }

        public bool NoTriples(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i] == numbers[i + 1] && numbers[i + 1] == numbers[i + 2])
                {
                    return false;
                }
            }
            return true;
        }

        public bool Pattern51(int[] numbers)
        {
             for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i] == numbers[i + 1]-5 && numbers[i] == numbers[i + 2]+1)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
