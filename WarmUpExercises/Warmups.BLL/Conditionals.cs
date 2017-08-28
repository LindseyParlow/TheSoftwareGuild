using System;

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            bool inTrouble = false;
            if (aSmile && bSmile || !aSmile && !bSmile)
            {
                inTrouble = true;
            }
            return inTrouble;
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            bool sleepIn = false;
            if (!isWeekday || isVacation)
            {
                sleepIn = true;
            }
            return sleepIn;
        }

        public int SumDouble(int a, int b)
        {
            int sum = (a + b);
            if (a == b)
            {
                return sum * 2;
            }
            else
            {
                return sum;
            }
        }

        public int Diff21(int n)
        {
            int absolute = Math.Abs(n - 21);
            if (n > 21)
            {
                return (absolute * 2);
            }
            return absolute;
        }

        public bool ParrotTrouble(bool isTalking, int hour)
        {
            bool inTrouble = false;
            if (isTalking && (hour < 7 || hour > 20))
            {
                inTrouble = true;
            }
            return inTrouble;
        }

        public bool Makes10(int a, int b)
        {
            bool takeTen = false;
            if ((a == 10 || b == 10) || (a + b == 10))
            {
                takeTen = true;
            }
            return takeTen;
        }

        public bool NearHundred(int n)
        {
            bool withinTen = false;
            if ((90 <= n && n <= 110) || (190 <= n && n <= 210))
            {
                withinTen = true;
            }
            return withinTen;
        }

        public bool PosNeg(int a, int b, bool negative)
        {
            bool oneNeg = false;
            if (negative == true && a < 0 && b < 0)
            {
                oneNeg = true;
            }
            else if ((a > 0 && b < 0) || (a < 0 && b > 0))
            {
                oneNeg = true;
            }
            return oneNeg;
        }



        public string NotString(string s)
        {
            if (s.Length < 3 || s.Substring(0, 2) != "not")
            {
                return "not " + s;
            }
            else
            {
                return s;
            }
        }
        
        
        public string MissingChar(string str, int n)
        {
            string newString = str.Remove(n, 1);
            return newString;
        }

        public string FrontBack(string str)
        {
            string switchThem = str;
            var a = str[0];
            var b = str[str.Length - 1];

            if (str.Length < 2)
            {
                return str;
            }
            else
            {
                switchThem = b + str.Substring(1, str.Length - 2) + a;
            }
            return switchThem;
        }
        
        public string Front3(string str)
        {
            string newStr = str;
            if ( str.Length < 3)
            {
                newStr = str + str + str;
            }
            else
            {
                newStr = str.Substring(0, 3) + str.Substring(0, 3) + str.Substring(0, 3);
            }
            return newStr;
        }
        
        public string BackAround(string str)
        {
            string newStr = str;
            var b = str[str.Length - 1];
            if (str.Length <1)
            {
                return str;
            }
            else
            {
                newStr = b + str + b;
            }
            return newStr;
        }
        
        public bool Multiple3or5(int number)
        {
            bool isMultiple = false;
            if (number % 3 ==0 || number % 5 == 0)
            {
                isMultiple = true;
            }
            return isMultiple;
        }
        
        public bool StartHi(string str)
        {
            bool hiStart = false;
            
            if (str.Length < 2)
            {
                hiStart = false;
            }
            else if (str.Length == 2 && str.Substring(0, 2) == "hi")
            {
                hiStart = true;
            }
            else if (str.Substring(0, 3) == "hi " || str.Substring(0, 3) == "hi" + ",")
            {
                hiStart = true;
            }
            else
            {
                hiStart = false;
            }
            return hiStart;
        }
        
        public bool IcyHot(int temp1, int temp2)
        {
            bool coldHot = false;
            if((temp1 < 0 && temp2 >100) || (temp2 < 0 && temp1 > 100))
            {
                coldHot = true;
            }
            return coldHot;
        }
        
        public bool Between10and20(int a, int b)
        {
            bool isBetween = false;
            if((a >= 10 && a <= 20) || (b >= 10 && b <= 20))
            {
                isBetween = true;
            }
            return isBetween;
        }
        
        public bool HasTeen(int a, int b, int c)
        {
            bool isTeen = false;
            if ((13<=a && a<=19) || (13 <= b && b <= 19) || (13 <= c && c <= 19))
            {
                isTeen = true;
            }
            return isTeen;
        }
        
        public bool SoAlone(int a, int b)
        {
            bool oneTeen = false;
            if (((13<= a && a<=19) && (b<13 || b>19)) || ((13 <= b && b <= 19) && (a < 13 || a > 19)))
            {
                oneTeen = true;
            }
            return oneTeen;
        }
        
        public string RemoveDel(string str)
        {
            string newStr = str;
            if (str.Length < 3)
            {
                newStr = str;
            }
            else if (str.Substring(1,3)==("del"))
            {
                newStr = str.Remove(1, 3);
            }
            else if (str.Substring(1,3)!=("del"))
            {
                newStr = str;
            }
            return newStr;
        }
        
        public bool IxStart(string str)
        {
            bool startsWithIx = false;
            if (str.Length < 2)
            {
                startsWithIx = false;
            }
            if (str.Substring(1,2) == "ix")
            {
                startsWithIx = true;
            }
            else
            {
                startsWithIx = false;
            }
            return startsWithIx;
        }
        
        public string StartOz(string str)
        {
            string newStr = str;
            if (str.Length ==1 && (str.Substring(0, 1) == "o"))
            {
                newStr = str.Substring(0, 1);
            }
            else if (str.Length ==1 )
            {
                newStr = "";
            } 
            else if (str.Substring(0,2)=="oz")
            {
                newStr = str.Substring(0, 2);
            }
            else if (str.Substring(0,1)=="o")
            {
                newStr = str.Substring(0,1);
            }
            else if (str.Substring(1,1)=="z")
            {
                newStr = str.Substring(1,1);
            }
            else
            {
                newStr = "";
            }
            return newStr;
        }
        
        public int Max(int a, int b, int c)
        {
            int isLargest = 0;
            if (a > b && a > c)
            {
                isLargest = a;
            }
            else if (b > a && b > c)
            {
                isLargest = b;
            }
            else if (c > a && c > b) 
            {
                isLargest = c;
            }
            return isLargest;
        }
        
        public int Closer(int a, int b)
        {
            int isCloser = 0;
            if (Math.Abs(10 - a) < Math.Abs(10 - b))
            {
                isCloser = a;
            }
            else if (Math.Abs(10 - b) < Math.Abs(10 - a))
            {
                isCloser = b;
            }
            else if (Math.Abs(10 - a) == Math.Abs(10 - b))
            {
                isCloser = 0;
            }
            return isCloser;
        }
        
        public bool GotE(string str)
        {
            bool hasE = false;
            int eCount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str.Substring(i,1)=="e")
                {
                    eCount++;
                }
            }
            if (eCount == 0)
            {
                hasE = false;
            }
            if (eCount >=1 && eCount <=3)
            {
                hasE = true;
            }
            else
            {
                hasE = false;
            }
            return hasE;
        }
        
        public string EndUp(string str)
        {
            string newStr = str;
            string endThree = str;
            string startString = str;
            if (str.Length < 3)
            {
                newStr = str.ToUpper();
            }
            else
            {
                endThree = str.Substring(str.Length - 3, 3);
                startString = str.Substring(0, str.Length - 3);
                newStr = startString + endThree.ToUpper();
            }
            return newStr;
        }
        
        public string EveryNth(string str, int n)
        {
            string newString="";
            for (int i = 0; i < str.Length; i += n)
            {
                newString += str[i];
            }
            return newString;
        }
    }
}
