using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    class MyBigInteger
    {
        public void AddSame(string s1, string s2) //A class that takes two strings, parses its indexes into integers and adds them to output a perfect added result
        {
            int n = s1.Length;
            int[] container = new int[n];
            bool check = false;
            int save=0;
            for (int i = s1.Length - 1; i >= 0; i--)
            {
                int first = (int)char.GetNumericValue(s1[i]); //int first = Convert.ToInt32(s1[i].ToString);
                int second = (int)char.GetNumericValue(s2[i]); //int second = Convert.ToInt32(s2[i].ToString);
                if (check == true)
                {
                    save = first+second+1;
                    check = false;
                }
                else if (check == false)
                {
                    save = first+second;
                }
                if (save < 10)
                {
                    container[i] = save;
                }
                else
                {
                    int tertiary = save % 10;
                    container[i] = tertiary;
                    check = true;
                }
            }
            foreach (int val in container)
            {
                Console.Write(val);
            }
            Console.WriteLine();
        }
        public void AddDifferent(string s1,string s2) { //a class that takes two strings of different lengths and adds them
            int lengthStringOne = s1.Length;
            int lengthStringTwo = s2.Length;
            int length = 0;
            int difference = 0;
            bool check = false;
            int save = 0;
            if (lengthStringOne > lengthStringTwo)
            {
                length = lengthStringOne;
                difference = lengthStringOne - lengthStringTwo;
            }
            else if (lengthStringTwo > lengthStringOne)
            {
                length = lengthStringTwo;
                difference = lengthStringTwo - lengthStringOne;
            }
            else if (lengthStringOne == lengthStringTwo)
            {
                length = lengthStringOne;
            }
            int[] container = new int[length];
            for (int i = length - 1; i >= 0; i--)
            {
                int first=0, second=0;
                if (lengthStringOne > lengthStringTwo)
                {
                    first = Convert.ToInt32(s1[i].ToString());
                    if (difference <= i)
                    {
                        int temp = i - difference;
                        second = Convert.ToInt32(s2[temp].ToString());
                    }
                    else if (difference > i)
                    {
                        second = 0;
                    }
                }
                else if (lengthStringTwo > lengthStringOne)
                {
                    second = Convert.ToInt32(s2[i].ToString());
                    if (difference <= i)
                    {
                        int temp = i - difference;
                        first = Convert.ToInt32(s1[temp].ToString());
                    }
                    else if (difference > i)
                    {
                        first = 0;
                    }
                }
                else if (lengthStringOne == lengthStringTwo)
                {
                    first = Convert.ToInt32(s1[i].ToString());
                    second = Convert.ToInt32(s2[i].ToString());
                }
                if (check == true)
                {
                    save = first + second + 1;
                    check = false;
                }
                else if (check == false)
                {
                    save = first + second;
                }
                if (save < 10)
                {
                    container[i] = save;
                }
                else
                {
                    int tertiary = save % 10;
                    container[i] = tertiary;
                    check = true;
                }
            }
            foreach (int val in container)
            {
                Console.Write(val);
            }
            Console.WriteLine();

        }
        public void Subtraction(string s1, string s2) // a class that subtracts any two big integers passed as string arguments
        {
            int length = 0;
            int lengthStringOne = s1.Length;
            int lengthStringTwo = s2.Length;
            int difference = 0;
            if (lengthStringOne > lengthStringTwo)
            {
                length = lengthStringOne;
                difference = lengthStringOne - lengthStringTwo;
            }
            else if (lengthStringTwo > lengthStringOne)
            {
                length = lengthStringTwo;
                difference = lengthStringTwo - lengthStringOne;
            }
            else if (lengthStringOne == lengthStringTwo)
            {
                length = lengthStringOne;
            }
            int[] container = new int[length];
            bool check = false;
            bool lend = false;
            bool flag0 = false;
            int burrow = 10;
            int save = 0;
            if (lengthStringOne == lengthStringTwo) //For same size
            {
                for (int i = s1.Length - 1; i >= 0; i--)
                {
                    int burrowed = 0;
                    int first = Convert.ToInt32(s1[i].ToString());
                    int second = Convert.ToInt32(s2[i].ToString());
                    int firstNext = 1;
                    int secondNext = 1;
                    //int firstPrevious = Convert.ToInt32(s1[++i].ToString());
                    if (i != 0)
                    {
                        firstNext = Convert.ToInt32(s1[i - 1].ToString());
                        secondNext = Convert.ToInt32(s2[i - 1].ToString());
                    }
                    if (lend == true)
                    {
                        if (first == 0 /* && second != 0*/)
                        {
                            int firsttemp = first + burrow;
                            burrowed = firsttemp - 1;
                            if (firstNext != 0)
                            {
                                flag0 = true;
                            }
                        }
                        
                    }

                    if (check == true)
                    {
                        burrowed = first - 1;
                    }
                    else if (first != 0)
                    {
                        if (flag0 == true)
                        {
                            burrowed = first - 1;
                        }
                        else
                        {
                            burrowed = first;
                        }
                    }
                    if (burrowed < second)
                    {
                        int help = burrowed + burrow;
                        int temp = help - second;
                        container[i] = temp;
                        if (firstNext == 0)
                        {
                            lend = true;
                        }
                        else
                        {
                            check = true;
                        }
                    }
                    else
                    {
                        save = burrowed - second;
                        container[i] = save;
                        if (firstNext == 0 && secondNext != 0)
                        {
                            lend = true;
                        }
                        check = false;
                    }
                }
                foreach (int val in container)
                {
                    Console.Write(val);
                }
                Console.WriteLine();
            }
            else if (lengthStringOne > lengthStringTwo) //for different size first number 2nd number small
            {
                for (int i = s1.Length - 1; i >= 0; i--)
                {
                    int burrowed = 0;
                    int first = Convert.ToInt32(s1[i].ToString());
                    int second = 0;
                    if (difference <= i)
                    {
                        int temp = i - difference;
                        second = Convert.ToInt32(s2[temp].ToString());
                    }
                    else if (difference > i)
                    {
                        second = 0;
                    }
                    //int second = Convert.ToInt32(s2[i].ToString());
                    int firstNext = 1;
                    //int firstPrevious = Convert.ToInt32(s1[++i].ToString());
                    if (i != 0)
                    {
                        firstNext = Convert.ToInt32(s1[i - 1].ToString());
                    }
                    if (lend == true)
                    {
                        if (first == 0)
                        {
                            int firsttemp = first + burrow;
                            burrowed = firsttemp - 1;
                        }
                        if (firstNext != 0)
                        {
                            flag0 = true;
                        }
                    }

                    if (check == true)
                    {
                        burrowed = first - 1;
                    }
                    else if (first != 0)
                    {
                        if (flag0 == true)
                        {
                            burrowed = first - 1;
                        }
                        else
                        {
                            burrowed = first;
                        }
                    }
                    if (burrowed < second)
                    {
                        int help = burrowed + burrow;
                        int temp = help - second;
                        container[i] = temp;
                        if (firstNext == 0)
                        {
                            lend = true;
                        }
                        else
                        {
                            check = true;
                        }
                    }
                    else
                    {
                        save = burrowed - second;
                        container[i] = save;
                        if (firstNext == 0)
                        {
                            lend = true;
                        }
                        check = false;
                    }
                }
                foreach (int val in container)
                {
                    Console.Write(val);
                }
                Console.WriteLine();
            }
            else if (lengthStringTwo > lengthStringOne) //for different size second number large first number small
            {
                for (int i = s2.Length - 1; i >= 0; i--)
                {
                    int burrowed = 0;
                    int second = Convert.ToInt32(s2[i].ToString());
                    int first = 0;
                    if (difference <= i)
                    {
                        int temp = i - difference;
                        first = Convert.ToInt32(s1[temp].ToString());
                    }
                    else if (difference > i)
                    {
                        first = 0;
                    }
                    //int second = Convert.ToInt32(s2[i].ToString());
                    int secondNext = 1;
                    //int firstPrevious = Convert.ToInt32(s1[++i].ToString());
                    if (i != 0)
                    {
                        secondNext = Convert.ToInt32(s2[i - 1].ToString());
                    }
                    if (lend == true)
                    {
                        if (second == 0)
                        {
                            int secondtemp = second + burrow;
                            burrowed = secondtemp - 1;
                        }
                        if (secondNext != 0)
                        {
                            flag0 = true;
                        }
                    }

                    if (check == true)
                    {
                        burrowed = second - 1;
                    }
                    else if (second != 0)
                    {
                        if (flag0 == true)
                        {
                            burrowed = second - 1;
                        }
                        else
                        {
                            burrowed = second;
                        }
                    }
                    if (burrowed < first)
                    {
                        int help = burrowed + burrow;
                        int temp = help - first;
                        container[i] = temp;
                        if (secondNext == 0)
                        {
                            lend = true;
                        }
                        else
                        {
                            check = true;
                        }
                    }
                    else
                    {
                        save = burrowed - first;
                        container[i] = save;
                        if (secondNext == 0)
                        {
                            lend = true;
                        }
                        check = false;
                    }
                }
                Console.Write("-");
                foreach (int val in container)
                {
                        Console.Write(val);     
                }
                Console.WriteLine();
            }
        }
    }
}
