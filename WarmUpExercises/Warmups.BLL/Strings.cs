using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }

        public string Abba(string a, string b)
        {
            string ComboOfAB = a + b + b + a;
            return ComboOfAB;
        }

        public string MakeTags(string tag, string content)
        {
            return "<" + tag + ">" + content + "</" + tag + ">";
        }

        public string InsertWord(string container, string word) {
            string putItInside = container;
            putItInside = container.Substring(0, 2) + word + container.Substring(2, 2);
            return putItInside;
        }

        public string MultipleEndings(string str)
        {
            string newStr;
            string finalStr;
            newStr = str.Substring(str.Length - 2, 2);
            finalStr = newStr + newStr + newStr;
            return finalStr;
        }

        public string FirstHalf(string str)
        {
            string newStr;
            newStr = str.Substring(0, str.Length / 2);
            return newStr;
        }

        public string TrimOne(string str)
        {
            string newStr;
            newStr = str.Substring(1, str.Length - 2);
            return newStr;
        }

        public string LongInMiddle(string a, string b)
        {
            string strComb;
            if (a.Length < b.Length)
            {
                strComb = a + b + a;
            }
            else
            {
                strComb = b + a + b;
            }
            return strComb;
        }

        public string RotateLeft2(string str)
        {
            string newStr;
            newStr = str.Substring(2) + str.Substring(0, 2);
            return newStr;
        }

        public string RotateRight2(string str)
        {
            string newStr;
            newStr = str.Substring(str.Length - 2,2) + str.Substring(0, str.Length-2);
            return newStr;
        }

        public string TakeOne(string str, bool fromFront)
        {
            string newStr;
            if (fromFront == false)
            {
                newStr = str.Substring(str.Length - 1, 1);
            }
            else
            {
                newStr = str.Substring(0, 1);
            }
            return newStr;
        }

        public string MiddleTwo(string str)
        {
            string isMiddle;
            isMiddle = str.Substring(str.Length / 2-1, 2);
            return isMiddle;
        }

        public bool EndsWithLy(string str)
        {
            bool yesItDoes = false;
            if (str.Length < 2)
            {
                yesItDoes = false;
            }
            else if (str.Substring(str.Length-2,2)=="ly")
            {
                yesItDoes = true;
            }
            else
            {
                yesItDoes = false;
            }
            return yesItDoes;
        }

        public string FrontAndBack(string str, int n)
        {
            throw new NotImplementedException();
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            //string tookTwo;
            //if (str.Length <= n)
            //{
            //    tookTwo = str;
            //}
            //else
            // {
            //     tookTwo = str.Substring(n, 2);
            // }
            // return tookTwo;
            throw new NotImplementedException();
        }

        public bool HasBad(string str)
        {
            bool badFirstOrSecond;
            if (str.Length < 3)
            {
                badFirstOrSecond = false;
            }
            else if (str.Length < 4 && str.Substring(0, 3) != "bad")
            {
                badFirstOrSecond = false;
            }
            else if (str.Substring(0, 3) == "bad" || str.Substring(1, 3) == "bad")
                badFirstOrSecond = true;
            else
            {
                badFirstOrSecond = false;
            }
            return badFirstOrSecond;
        }

        public string AtFirst(string str)
        {
            string firstIs;
            if ( str.Length == 0)
            {
                firstIs = "@@";
            }
            else if (str.Length == 1)
            {
                firstIs = str + "@";
            }
            else
            {
                firstIs = str.Substring(0, 2);
            }
            return firstIs;
        }

        public string LastChars(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string ConCat(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string SwapLast(string str)
        {
            throw new NotImplementedException();
        }

        public bool FrontAgain(string str)
        {
            throw new NotImplementedException();
        }

        public string MinCat(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string TweakFront(string str)
        {
            throw new NotImplementedException();
        }

        public string StripX(string str)
        {
            throw new NotImplementedException();
        }
    }
}
