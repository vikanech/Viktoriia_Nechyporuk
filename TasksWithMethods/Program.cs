using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks
{
    public class Program
    {
        // 1 TASK
        public static List<int> GetIntegersFromList(List<object> list)
        {
            var intList = new List<int>();

            foreach (var item in list)
            {
                if (item.GetType().ToString() == "System.Int32")
                {
                    intList.Add((int)item);
                }
            }

            return intList;
        }

        // 2 TASK
        public static char GetFirstNonRepeatingLetter(string word)
        {
            word = word.ToLower();
            var letters = new List<char>();

            for (int i = 0; i < word.Length; i++)
            {
                letters.Add(word[i]);
            }

            foreach (var letter in letters)
            {
                var counter = 0;
                foreach (var letterAgain in letters)
                {
                    if (letter == letterAgain)
                    {
                        counter++;
                    }
                }

                if (counter == 1)
                {
                    return letter;
                }
            }

            return '-';
        }

        // 3 TASK
        public static int GetSumOfAllDigitsInANumber(int number)
        {
            int sum = 0;
            var stringNumber = number.ToString();

            for (int i = 0; i < stringNumber.Length; i++)
            {
                sum += Convert.ToInt32(stringNumber[i].ToString());
            }

            if (sum > 9)
            {
                return GetSumOfAllDigitsInANumber(sum);
            }

            return sum;
            
        }

        // 4 TASK
        public static int CountNumberOfPairsInTheArrayWhichSumIsEqualToTargetValue(int[] arr, int target)
        {
            //var arr = new int[] { 1, 3, 6, 2, 2, 0, 4, 5 };
            //var target = 5;

            var counter = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == target)
                    {
                        counter++;
                    }

                }
            }

            return counter;
        }

        // 5 TASK
        public static string GetOrderedFriends()
        {
            var friends = "Fired:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
            var friendsList = friends.Split(";").ToList();

            var orderedFriends = friendsList.Select(x => new { Name = x.Split(":")[0], Surname = x.Split(":")[1] })
                .OrderBy(x => x.Name)
                .OrderBy(x => x.Surname);

            var orderedFriendsString = "";
            foreach (var friend in orderedFriends)
            {
                orderedFriendsString += $"({friend.Surname}, {friend.Name})";
            }
            return orderedFriendsString;
        }

        // 6 TASK
        public static int GetTheNextBiggerNumberByRearranging(int value)
        {
            var stringValue = value.ToString();

            var listOfDigits = new List<int>();
            for (int i = 0; i < stringValue.Length; i++)
            {
                string digit = stringValue[i].ToString();
                for (int j = 0; j < stringValue.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    digit += stringValue[j].ToString();

                }

                if (!listOfDigits.Contains(Convert.ToInt32(digit)))
                {
                    listOfDigits.Add(Convert.ToInt32(digit));
                }
            }

            if (listOfDigits.Count == 1)
            {
                return -1;
            }
            else
            {
                int minimalDif = 0;
                int minimalDifValue = 0;
                for (int i = 0; i < listOfDigits.Count; i++)
                {
                    if (minimalDif == 0)
                    {
                        if (listOfDigits[i] - value > 0)
                        {
                            minimalDif = listOfDigits[i] - value;
                            minimalDifValue = listOfDigits[i];
                        }
                    }
                    else
                    {
                        if (listOfDigits[i] - value < minimalDif)
                        {
                            minimalDif = listOfDigits[i] - value;
                            minimalDifValue = listOfDigits[i];
                        }
                    }
                }

                return minimalDifValue;
            }
        }
        public static void Main(string[] args)
        {
            // TASK 1 OUTPUT
            Console.Write($"[TASK 1] When list is [1,2,'a','b','aasf','1','123',231], RESULT: ");
            var taskOneList = GetIntegersFromList(new List<object> { 1, 2, 'a', 'b', "aasf", '1', "123", 231 });
            Console.Write("{ ");
            foreach (var item in taskOneList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("}");

            // TASK 2 OUTPUT
            Console.WriteLine($"[TASK 2] When string is 'sTreSS', RESULT: {GetFirstNonRepeatingLetter("sTreSS")}");

            // TASK 3 OUTPUT
            Console.WriteLine($"[TASK 3] When value is 16, RESULT: {GetSumOfAllDigitsInANumber(16)}");
            Console.WriteLine($"[TASK 3] When value is 942, RESULT: {GetSumOfAllDigitsInANumber(942)}");
            Console.WriteLine($"[TASK 3] When value is (132189), RESULT: {GetSumOfAllDigitsInANumber((132189))}");

            // TASK 4 OUTPUT
            Console.WriteLine($"[TASK 4] When array is [1, 3, 6, 2, 2, 0, 4, 5] and target value is 5, RESULT: {CountNumberOfPairsInTheArrayWhichSumIsEqualToTargetValue(new int[] { 1, 3, 6, 2, 2, 0, 4, 5 }, 5)}");

            // TASK 5 OUTPUT
            Console.WriteLine($"[TASK 5] When string is 'Fired: Corwill; Wilfred: Corwill; Barney: TornBull; Betty: Tornbull; Bjon: Tornbull; Raphael: Corwill; Alfred: Corwill', \n\tRESULT: {GetOrderedFriends()}");

            // TASK 6 OUTPUT
            Console.WriteLine($"[TASK 1 EXTRA] When value is 12, RESULT: {GetTheNextBiggerNumberByRearranging(12)}");
            Console.WriteLine($"[TASK 1 EXTRA] When value is 111, RESULT: {GetTheNextBiggerNumberByRearranging(111)}");
        }
    }
}
