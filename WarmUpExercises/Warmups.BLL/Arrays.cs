using System;
using System.Collections.Generic;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            bool firstOrLast = false;

            if(numbers[0] == 6 || numbers[numbers.Length - 1] == 6)
            {
                firstOrLast = true;
            }
            return firstOrLast;
        }

        public bool SameFirstLast(int[] numbers)
        {
            bool sameFirstLast = false;

            if(numbers.Length > 0 && numbers[0] == numbers[numbers.Length - 1])
            {
                sameFirstLast = true;
            }
            return sameFirstLast;
        }

        public int[] MakePi(int n)
        {
            int[] piNumbers = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3 };
            int[] newPiNumbers = new int[n];

            for(int i = 0; i < n; i++)
            {
                newPiNumbers[i] = piNumbers[i]; 
            }
            return newPiNumbers;
        }

        public bool CommonEnd(int[] a, int[] b)
        {
            bool hasSameEnd = false;

            if(a[0] == b[0] || a[a.Length-1] == b[b.Length - 1])
            {
                hasSameEnd = true;
            }
            return hasSameEnd;
        }

        public int Sum(int[] numbers)
        {
            var totalSum = 0;

            for(var i = 0; i < numbers.Length; i++)
            {
                totalSum += numbers[i];
            }
            return totalSum;
        }
        
        public int[] RotateLeft(int[] numbers)
        {
            throw new NotImplementedException();

            //look into how i want to do this. 
            //can either take the first number off and keep rest of array then put that one on the end.
            //or can do a for loop and change position to position - 1
        }

        public int[] Reverse(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] HigherWins(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] GetMiddle(int[] a, int[] b)
        {
            throw new NotImplementedException();
        }
        
        public bool HasEven(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] KeepLast(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public bool Double23(int[] numbers)
        {
            throw new NotImplementedException();
        }


        public int[] Fix23(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public bool Unlucky1(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] Make2(int[] a, int[] b)
        {
            throw new NotImplementedException();
        }
    }
}
