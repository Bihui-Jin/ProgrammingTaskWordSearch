using System;
using System.Linq;
namespace ProgrammingTask
{
    class WordSearch
    {
        static void Main(string[] args)
        {
            string[,] inputArr = new string[3, 4] { { "A", "B", "C", "E" }, 
                                                    { "S", "F", "C", "S" }, 
                                                    { "A", "D", "E", "E" } };
            FindWord(inputArr, "ABCCED");
            FindWord(inputArr, "SEE");
            FindWord(inputArr, "ABCB");

            FindWord(inputArr,"CCEDFB"); //extra test
            FindWord(inputArr, "ESEE"); //extra test
            FindWord(inputArr, "ECCESE"); //extra test
            FindWord(inputArr, "ECCBFC"); //extra test
        }

        public static void FindWord(string[,] arr, string word)
        {
            var chartArr = word.ToArray();
            var column = arr.GetLength(0); //column length 
            var row = arr.GetLength(1); //row length 
            var isFound = false;

            for (var i = 0; i < row && !isFound; i++)
            {
                for (var j = 0; j < column && !isFound; j++)
                {

                    if (arr[j, i].Equals(chartArr[0].ToString()))
                    {
                        isFound = FindPath(i, j, row, column, arr, chartArr, i, j);
                        if (isFound) Console.WriteLine("{0} => TRUE", word);
                    }
                }
            }
            if(!isFound) Console.WriteLine("{0} => FALSE", word);

        }

        public static bool FindPath(int i, int j, int r, int c, string[,] arr, char[] word, int parentI, int parentJ)
        {
            if (i >= r || j >= c || i < 0 || j < 0) return false; //if exceeds the limit
            string[,] tempArr = new string[arr.GetLength(0), arr.GetLength(1)];
            Array.Copy(arr, tempArr,arr.Length);
            if (word.GetLength(0)==1)
            {
                if (arr[j, i].Equals(word[0].ToString())) return true; else return false; //judge if the last element matches
            }


            //recursion --avoided the parent node
            if (arr[j, i].Equals(word[0].ToString()))
            {
                word = word.Skip(1).ToArray();
                tempArr[parentJ, parentI] = "0"; //set the parent node to be 0
                return FindPath(i - 1, j, r, c, tempArr, word, i,j) ||
                FindPath(i + 1, j, r, c, tempArr, word, i,j) ||
                FindPath(i, j - 1, r, c, tempArr, word, i, j) ||
                FindPath(i, j + 1, r, c, tempArr, word, i, j);
            }
            else return false;

        }
    }

}


