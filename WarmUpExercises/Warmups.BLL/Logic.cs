using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)

        {
            bool isGreatParty = cigars >= 40;
            if (!isWeekend && isGreatParty)
            {
                isGreatParty = cigars <= 60;
            }
            return isGreatParty;
        }

        public int CanHazTable(int yourStyle, int dateStyle)
        {
            int getTable = 0;
            if ((yourStyle >= 8 && dateStyle > 3) || (dateStyle >= 8 && yourStyle > 3))
            {
                getTable = 2;
            }
            else if (yourStyle <= 2 || dateStyle <= 2)
            {
                getTable = 0;
            }
            else
            {
                getTable = 1;
            }
            return getTable;
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            bool childrenPlay = false;
            if (isSummer && (temp >= 60 && temp <= 100))
            {
                childrenPlay = true;
            }
            else if (!isSummer && (temp >= 60 && temp <= 90))
            {
                childrenPlay = true;
            }
            else
            {
                childrenPlay = false;
            }
            return childrenPlay;

        }

        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            int ticketSize = 0;
            if (isBirthday && speed <= 65)
            {
                ticketSize = 0;
            }
            else if (isBirthday && (65 < speed && speed <= 88))
            {
                ticketSize = 1;
            }
            else if (isBirthday && speed < 85)
            {
                ticketSize = 2;
            }
            else if (!isBirthday && speed <= 60)
            {
                ticketSize = 0;
            }
            else if (!isBirthday && (60 < speed && speed <= 80))
            {
                ticketSize = 1;
            }
            else if (!isBirthday && speed > 80)
            {
                ticketSize = 2;
            }
            return ticketSize;
        } 
        
        public int SkipSum(int a, int b)
        {
            int sum = 0;
            if (a+b >=10 && a+b <=20)
            {
                return 20;
            }
            else
            {
                sum = a + b;
            }
            return sum;
        }
        
        public string AlarmClock(int day, bool vacation)
        {
            throw new NotImplementedException();
        }
        
        public bool LoveSix(int a, int b)
        {
            bool yaySix = false;
            if(a == 6 || b == 6 || a + b == 6 || a - b == 6 || b - a == 6)
            {
                yaySix = true;
            }
            return yaySix;
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            bool isRangey = false;
            if (outsideMode == true && (n <= 1 || n >= 10))
            {
                isRangey = true;
            }
            else if (1 <=n && n <= 10)
            {
                isRangey = true;
            }
            else
            {
                return false;
            }
            return isRangey;
        }
        
        public bool SpecialEleven(int n)
        {
            bool isSpecial = false;
            if (n%11==0 || n%11==1)
            {
                isSpecial = true;
            }
            return isSpecial;
        }
        
        public bool Mod20(int n)
        {
            bool multipleOfTwenty = false;
            if (n%20==1 || n%20==2)
            {
                multipleOfTwenty = true;
            }
            return multipleOfTwenty;
        }
        
        public bool Mod35(int n)
        {
            bool multThreeOrFive = false;
            if (n%3==0 && n%5==0)
            {
                multThreeOrFive = false;
            }
            else if (n%3==0 || n%5==0)
            {
                multThreeOrFive = true;
            }
            return multThreeOrFive;
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            bool shouldAnswer = false;
            if (isAsleep)
            {
                shouldAnswer = false;
            }
            else if (isMorning && isMom)
            {
                shouldAnswer = true;
            }
            else if (isMorning && !isMom)
            {
                shouldAnswer = false;
            }
            else
            {
                shouldAnswer = true;
            }
            return shouldAnswer;
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            bool sumOfTwo = false;
            if (a+b==c || a+c==b || b+c==a)
            {
                sumOfTwo = true;
            }
            return true;
        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            bool inOrder = false;
            if (bOk == true && c>b)
            {
                inOrder = true;
            }
            else if (b>a && c>b)
            {
                inOrder = true;
            }
            else
            {
                inOrder = false;
            }
            return inOrder;
        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            bool isInOrder = false;
            if (a<b && b<c)
            {
                isInOrder = true;
            }
            else if (equalOk == true && a<=b && b<=c)
            {
                isInOrder = true;
            }
            else
            {
                isInOrder = false;
            }
            return isInOrder;
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            bool sameDigit = false;
            if ((a-b)%10==0 || (a-c)%10==0 || (b-c)%10==0)
            {
                sameDigit = true;
            }
            else
            {
                sameDigit = false;
            }
            return sameDigit;
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            throw new NotImplementedException();
        }

    }
}
