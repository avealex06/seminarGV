using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace _2D_Array_Playground
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //TODO 1: Vytvoř integerové 2D pole velikosti 5 x 5, naplň ho čísly od 1 do 25 a vypiš ho do konzole (5 řádků po 5 číslech).
            int[,] nums = new int[5, 5];
            int numberToAdd = 1;
            for (int i = 0; i < nums.GetLength(0); i++)
            {
                for (int j = 0; j < nums.GetLength(1); j++)
                {
                    nums[i, j] = numberToAdd;
                    numberToAdd++;
                    Console.Write(nums[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");

            //TODO 2: Vypiš do konzole n-tý řádek pole, kde n určuje proměnná nRow.
            int nRow = 0;
            for (int j = 0; j < nums.GetLength(1); j++)
            {
                Console.Write(nums[nRow,j] + " ");
            }
            Console.WriteLine("\n");

            //TODO 3: Vypiš do konzole n-tý sloupec pole, kde n určuje proměnná nColumn.
            int nColumn = 0;
            for (int i = 0; i < nums.GetLength(0); i++)
            {
                Console.Write(nums[i, nColumn] + " ");
            }
            Console.WriteLine("\n");

            //BONUS TODO 1: Hlavni diagonala
            for (int i = 0; i < nums.GetLength(0); i++)
            {
                Console.Write(nums[i, i] + " ");
                
            }
            Console.WriteLine("\n");

            //BONUS TODO 2: Vedlejsi diagonala

            
            for (int i = 4; i >=0; i--)
            {
                Console.Write(nums[i, nums.GetLength(1)-i-1] + " ");
                
            }
            Console.WriteLine("\n");

            //TODO 4: Prohoď prvek na souřadnicích [xFirst, yFirst] s prvkem na souřadnicích [xSecond, ySecond] a vypiš celé pole do konzole po prohození.
            //Nápověda: Budeš potřebovat proměnnou navíc, do které si uložíš první z prvků před tím, než ho přepíšeš druhým, abys hodnotou prvního prvku potom mohl přepsat druhý
            int xFirst, yFirst, xSecond, ySecond;
            xFirst = yFirst = 0; //souradnice 1 [0,0]
            xSecond = ySecond = 4; //souradnice 25 [4,4]
            int first = nums[xFirst, yFirst];
            //int second = nums[xSecond, ySecond];
            nums[xFirst, yFirst] = nums[xSecond, ySecond];
            nums[xSecond, ySecond] = first;

            //TODO 5: Prohoď n-tý řádek v poli s m-tým řádkem (n je dáno proměnnou nRowSwap, m mRowSwap) a vypiš celé pole do konzole po prohození.
            int nRowSwap = 0;
            int mRowSwap = 1;
            for (int j = 0; j < nums.GetLength(1); j++)
            {
                int temp = nums[nRowSwap, j];
                nums[nRowSwap, j] = nums[mRowSwap, j];
                nums[mRowSwap, j] = temp;

            }
            for (int i = 0; i < nums.GetLength(0); i++)
            {
                for (int j = 0; j < nums.GetLength(1); j++)
                {
                    Console.Write($"{nums[i, j]} ");
                }
                Console.Write("\n");

            }
            Console.WriteLine();


            //TODO 6: Prohoď n-tý sloupec v poli s m-tým sloupcem (n je dáno proměnnou nColSwap, m mColSwap) a vypiš celé pole do konzole po prohození.
            int nColSwap = 0;
            int mColSwap = 1;
            for (int i = 0; i < nums.GetLength(1); i++)
            {
                int temp = nums[nColSwap, i];
                nums[nColSwap, i] = nums[mColSwap, i];
                nums[mColSwap, i] = temp;

            }
            for (int i = 0; i < nums.GetLength(0); i++)
            {
                for (int j = 0; j < nums.GetLength(1); j++)
                {
                    Console.Write($"{nums[i, j]} ");
                }
                Console.Write("\n");

            }
            Console.WriteLine();

            //TODO 7: Otoč pořadí prvků na hlavní diagonále (z levého horního rohu do pravého dolního rohu) a vypiš celé pole do konzole po otočení.
            for (int i = 0; i < nums.GetLength(0); i++)
            {
                int temp = nums[i, i];
                int coordToSwap = nums.GetLength(0) - 1 - i;
                nums[i, i] = nums[coordToSwap,coordToSwap];
                nums[coordToSwap, coordToSwap] = temp;

            }
            for (int i = 0; i < nums.GetLength(0); i++)
            {
                for (int j = 0; j < nums.GetLength(1); j++)
                {
                    Console.Write($"{nums[i, j]} ");
                }
                Console.Write("\n");

            }
            Console.WriteLine();
            //TODO 8: Otoč pořadí prvků na vedlejší diagonále (z pravého horního rohu do levého dolního rohu) a vypiš celé pole do konzole po otočení.


            Console.ReadKey();
        }
    }
}
