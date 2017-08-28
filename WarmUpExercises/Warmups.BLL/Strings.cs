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
            string newStr = str.Substring(0,n) + str.Substring(str.Length-n,n);
            return newStr;
        }

        public string TakeTwoFromPosition(string str, int n)
        {

            string justTwo = str;
            if (str.Length - n < 2)
            {
                justTwo = str.Substring(0, 2);
            }
            else
            {
                justTwo = str.Substring(n, 2);
            }
            return justTwo;
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
            string comboAB;
            if (a.Length==0 && b.Length==0)
            {
                comboAB = "@@";
            }
            else if (a.Length>0 && b.Length==0)
            {
                comboAB = a.Substring(0, 1) + "@";
            }
            else if (a.Length == 0 && b.Length>0)
            {
                comboAB = "@" + b.Substring(b.Length-1, 1);
            }
            else
            {
                comboAB = a.Substring(0, 1) + b.Substring(b.Length-1, 1);
            }
            return comboAB;
        }

        public string ConCat(string a, string b)
        {
            string thisIsTheConCat;
            if (a.Length<1 && b.Length<1)
            {
                thisIsTheConCat = "";
            }
            else if (a.Length < 1 && b.Length >= 1)
            {
                thisIsTheConCat = b;
            }
            else if (a.Length >= 1 && b.Length < 1)
            {
                thisIsTheConCat = a;
            }
            else if (a.Substring(a.Length-1,1)==b.Substring(0,1))
            {
                thisIsTheConCat = string.Concat(a, b.Substring(1));
            }
            else
            {
                thisIsTheConCat = string.Concat(a, b);
            }
            return thisIsTheConCat;
        }

        public string SwapLast(string str)
        {
            string swapIt = str;
            if (str.Length < 2)
            {
                swapIt = str;
            }
            else if (str.Length == 2)
            {
                swapIt = str.Substring(str.Length - 1, 1) + str.Substring(str.Length - 2, 1);
            }
            else if (str.Length > 2)
            {
                swapIt = str.Substring(0, str.Length - 2) + str.Substring(str.Length - 1, 1) + str.Substring(str.Length - 2, 1);
            }
            return swapIt;
        }

        public bool FrontAgain(string str)
        {
            bool atFrontAndBack = false;
            if (str.Substring(0,2) == str.Substring(str.Length-2,2))
            {
                atFrontAndBack = true;
            }
            else
            {
                atFrontAndBack = false;
            }
            return atFrontAndBack;
        }

        public string MinCat(string a, string b)
        {
            string ammendMinCat;
            if (a.Length == b.Length)
            {
                ammendMinCat = string.Concat(a, b);
            }
            else if (a.Length>b.Length)
            {
                ammendMinCat = string.Concat(a.Substring(a.Length - b.Length, b.Length), b);
            }
            else
            {
                ammendMinCat = string.Concat(a, b.Substring(b.Length - a.Length, a.Length));
            }
            return ammendMinCat;
        }

        public string TweakFront(string str)
        {
            string alterFront;
            if (str.Length < 1) 
            {
                alterFront = "";
            }
            else if (str.Length<3)
            {
                alterFront = str;
            }
            else if (str.Substring(0,1)=="a" && str.Substring(1,1)=="b")
            {
                alterFront = str;
            }
            else if (str.Substring(0, 1) == "a" && str.Substring(1,1)!="b")
            {
                alterFront = str.Substring(0, 1) + str.Substring(2);
            }
            else if (str.Substring(0, 1) != "a" && str.Substring(1, 1) == "b")
            {
                alterFront = str.Substring(1);
            }
            else
            {
                alterFront = str.Substring(2);
            }
            return alterFront;
        }
        

        public string StripX(string str)
        {
            string noFirstOrLastX = str;
            if (str.Length < 1)
            {
                noFirstOrLastX = "";
            }
            else if (str.Length == 1 && str=="x")
            {
                noFirstOrLastX = "";
            }
            else if (str.Substring(0,1)=="x" && str.Substring(str.Length-1,1)=="x")
            {
                noFirstOrLastX = str.Substring(1, str.Length - 2);
            }
            else if (str.Substring(0, 1) == "x" && str.Substring(str.Length - 1, 1) != "x")
            {
                noFirstOrLastX = str.Substring(1);
            }
            else if (str.Substring(0, 1) != "x" && str.Substring(str.Length - 1, 1) == "x")
            {
                noFirstOrLastX = str.Substring(0, str.Length - 1);
            }
            else
            {
                noFirstOrLastX = str;
            }
            return noFirstOrLastX;
        }
    }
}
