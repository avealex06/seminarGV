using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace maticeUkol
{
    internal class Program
    {

        
        static void Main(string[] args)
        {
            static void List(int[,] array) //vypise zadanou matici
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write($"{array[i, j]} ");
                    }
                    Console.Write("\n");

                }
                Console.WriteLine();
            }

            static int[,] RandomArr(int a, int b) //vytvori matici o velikostech a x b naplnenou nahodnymi cisly
            {
                Random random = new Random();
                int[,] randNums = new int[a, b];
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        randNums[i, j] = random.Next(1, 11);
                    }
                }
                return randNums;
            }
            static int[,] Reset(int[,] array, int[,] resetArr) //funkce na reset nums do puvodniho stavu
            {
                Console.WriteLine("resetovat? y/n");
                char reset = Convert.ToChar(Console.ReadLine());
                if (reset == 'y')
                {
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            array[i, j] = resetArr[i, j];
                        }
                    }
                }
                return array;
            }
            static void Swap(int what, int[,] array, int[,] resetArr) //prohazovani
            {
                if (what == 0) // radky
                {
                    Console.WriteLine("prohozeni radku");
                    Console.WriteLine("ktery s kterym?");
                    int nRowSwap = Convert.ToInt32(Console.ReadLine()) - 1;
                    int mRowSwap = Convert.ToInt32(Console.ReadLine()) - 1;
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        int temp = array[nRowSwap, j];
                        array[nRowSwap, j] = array[mRowSwap, j];
                        array[mRowSwap, j] = temp;
                    }
                }
                else if (what == 1) // sloupce
                {
                    Console.WriteLine("prohozeni sloupcu");
                    Console.WriteLine("ktery s kterym?");
                    int nColSwap = Convert.ToInt32(Console.ReadLine()) - 1;
                    int mColSwap = Convert.ToInt32(Console.ReadLine()) - 1;
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        int temp = array[i, nColSwap];
                        array[i, nColSwap] = array[i, mColSwap];
                        array[i, mColSwap] = temp;
                    }
                }
                else //souradnice
                {
                    int xFirst, yFirst, xSecond, ySecond;
                    Console.WriteLine("x prvni");
                    xFirst = Convert.ToInt32(Console.ReadLine())-1;
                    Console.WriteLine("y prvni");
                    yFirst = Convert.ToInt32(Console.ReadLine())-1;
                    Console.WriteLine("x druhe");
                    xSecond = Convert.ToInt32(Console.ReadLine())-1;
                    Console.WriteLine("y druhe");
                    ySecond = Convert.ToInt32(Console.ReadLine())-1;
                    int first = array[xFirst, yFirst];
                    array[xFirst, yFirst] = array[xSecond, ySecond];
                    array[xSecond, ySecond] = first;
                }
                List(array);
                Reset(array, resetArr);
                List(array);
            }

            static void Flip(int what, int[,] array, int[,] resetArr)
            {
                if (what==0) //prevraceni po hlavni diagonale
                {
                    Console.WriteLine("po hlavni diagonale");
                    for(int i = 0; i < array.GetLength(0)/2; i++)
                    {
                        int temp = array[i, i];
                        int coordToSwap = array.GetLength(0) - 1 - i;
                        array[i, i] = array[coordToSwap, coordToSwap];
                        array[coordToSwap, coordToSwap] = temp;

                    }
                }
                else if (what ==1) //prevraceni po vedlejsi diagonale
                {
                    Console.WriteLine("po vedlejsi diagonale");
                    for (int i = array.GetLength(0) - 1; i > array.GetLength(0) / 2; i--) 
                    {
                        int j = array.GetLength(0) - 1 - i;
                        int temp = array[i, j];
                        array[i, j] = array[j, i];
                        array[j, i] = temp;
                    }
                }

                List(array);
                Reset(array, resetArr);
                List(array);
            }

            static void MultiplyByNum(int what, int[,] array, int[,] resetArr)
            {
                Console.WriteLine("nasobeni matice cislem?");
                int x = Convert.ToInt32(Console.ReadLine());
                if (what == 0) //vynasobi jen vybranou radu
                {
                    Console.WriteLine("ktera rada");
                    int row = Convert.ToInt32(Console.ReadLine())-1;
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        array[row, j] = array[row, j] * x;
                    }
                }
                else if (what==1) //vynasobi jen vybrany sloupec
                {
                    Console.WriteLine("ktery sloupec");
                    int col = Convert.ToInt32(Console.ReadLine())-1;
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        array[i, col] = array[i, col] * x;
                    }
                }
                else //vynasobi celou matici
                {
                    Console.WriteLine("cela matice");
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            array[i, j] = array[i, j]*x;
                        }
                    }
                }
                List(array);
                Reset(array, resetArr);
                List(array);
            }

            static void AddMatrix(int[,] array, int[,] resetArr)
            {
                Console.WriteLine("scitani matic");
                Console.WriteLine("nahodna matice, ktera bude prictena");
                int[,] bArray = RandomArr(array.GetLength(0), array.GetLength(1));
                List(bArray);
                //vezme kazdy prvek v jedne matici a pricte k nemu prvek na stejne pozici ve druhe matici
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        array[i, j] += bArray[i, j];
                    }
                }
                List(array);
                Reset(array, resetArr);
                List(array);
            }
            static void SubtractMatrix(int[,] array, int[,] resetArr)
            {
                Console.WriteLine("odcitani matic");
                Console.WriteLine("nahodna matice, ktera bude odectena");
                int[,] bArray = RandomArr(array.GetLength(0), array.GetLength(1));
                List(bArray);
                //vezme kazdy prvek v jedne matici a odecte od nej prvek na stejne pozici ve druhe matici
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        array[i, j] -= bArray[i, j];
                    }
                }
                List(array);
                Reset(array, resetArr);
                List(array);
            }

            static void Transpose(int[,] array)
            {
                Console.WriteLine("transpozice");
                //vytvori matici result o velikosti b,a
                int[,] result = new int[array.GetLength(1), array.GetLength(0)];
                //nasklada do matice result prvky v jejich transponovanych pozicich 
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        
                        result[j, i] = array[i, j];
                    }
                }
                List(result);

            }

            static void MultiplyByMatrix(int[,] array)
            {
                Console.WriteLine("nasobeni matic");
                Console.WriteLine("velikosti matice kterou se bude nasobit?");
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());
                int[,] bArray = RandomArr(a, b);
                List(bArray);

                //zkontroluje jestli jde nasobit prvni matici druhou
                if (array.GetLength(1)!=bArray.GetLength(0))
                {
                    Console.WriteLine("matice se nedaji nasobit");
                    
                }
                else
                {
                    //vytvori matici result o velikostech [rady prvni matice, sloupce druhe matice]
                    int[,] result = new int[array.GetLength(0), bArray.GetLength(1)];
                    //provede maticove nasobeni
                    //kazdy radek array
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        //kazdy sloupec bArray
                        for (int j = 0; j < bArray.GetLength(1); j++)
                        {
                            //kazdy sloupec array
                            for (int k = 0; k < array.GetLength(1); k++)
                            {
                                //soucet soucinu vsech prvku v radku i matice array a sloupce j matice bArray
                                result[i, j] += array[i, k] * bArray[k, j];
                            }
                        }
                    }

                    List(result);
                }
                
            }


            //vyber rozmeru uzivatelem
            Console.WriteLine("prvni rozmer");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("druhy rozmer");
            int b = Convert.ToInt32(Console.ReadLine());
            //vytvoreni matice o rozmerech a x b
            int[,] nums = new int[a, b];
            int numberToAdd = 1;
            //vyplneni a vypsani matice
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

            
            int[,] numsReseter = (int[,])nums.Clone(); //cast klonu nums do numsReseter jako 2D pole - zdroj ChatGPT

            Console.WriteLine("zacit swap? y/n");
            char doOrNot = Convert.ToChar(Console.ReadLine());

            if (doOrNot == 'y')
            {
                //PROHOZENI RADKU
                Swap(0, nums, numsReseter);

                //PROHOZENI SLOUPCU
                Swap(1, nums, numsReseter);

                //PROHOZENI PODLE SOURADNIC
                Swap(-1, nums, numsReseter);

            }
            Console.WriteLine("zacit obraceni diagonal? y/n");
            doOrNot = Convert.ToChar(Console.ReadLine());

            if (doOrNot=='y')
            {
                //PO HLAVNI DIAGONALE
                Flip(0, nums, numsReseter);
                //PO VEDLEJSI DIAGONALE
                Flip(1, nums, numsReseter);
            }
            Console.WriteLine("zacit nasobit matici cislem? y/n");
            doOrNot = Convert.ToChar(Console.ReadLine());

            if (doOrNot == 'y')
            {
                //VYBRANA RADA
                MultiplyByNum(0, nums, numsReseter);
                //VYBRANY SLOUPEC
                MultiplyByNum(1, nums, numsReseter);
                //CELA MATICE
                MultiplyByNum(-1, nums, numsReseter);
            }

            Console.WriteLine("zacit scitani a odcitani matic? y/n");
            doOrNot = Convert.ToChar(Console.ReadLine());

            if (doOrNot == 'y')
            {
                //SCITANI
                AddMatrix(nums,numsReseter);
                //ODCITANI
                SubtractMatrix(nums,numsReseter);
            }


            Console.WriteLine("transpozice matice? y/n");
            doOrNot = Convert.ToChar(Console.ReadLine());

            if (doOrNot == 'y')
            {
                //TRANSPOZICE
                Transpose(nums);
            }

            Console.WriteLine("nasobeni matici? y/n");
            doOrNot = Convert.ToChar(Console.ReadLine());

            if (doOrNot == 'y')
            {
                //NASOBENI MATICI
                MultiplyByMatrix(nums);
            }



            Console.ReadKey();
        }
    }
}

