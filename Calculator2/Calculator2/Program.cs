/*
 * Pokud se budes chtit na neco zeptat a zrovna budu pomahat jinde, zkus se zeptat ChatGPT ;) - https://chat.openai.com/
 * 
 * ZADANI
 * Vytvor program ktery bude fungovat jako kalkulacka. Kroky programu budou nasledujici:
 * 1) Nacte vstup pro prvni cislo od uzivatele (vyuzijte metodu Console.ReadLine() - https://learn.microsoft.com/en-us/dotnet/api/system.console.readline?view=netframework-4.8
 * 2) Zkonvertuje vstup od uzivatele ze stringu do integeru - https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number.
 * 3) Nacte vstup pro druhe cislo od uzivatele a zkonvertuje ho do integeru. (zopakovani kroku 1 a 2 pro druhe cislo)
 * 4) Nacte vstup pro ciselnou operaci. Rozmysli si, jak operace nazves. Muze to byt "soucet", "rozdil" atd. nebo napr "+", "-", nebo jakkoliv jinak.
 * 5) Nadefinuj integerovou promennou result a prirad ji prozatimne hodnotu 0.
 * 6) Vytvor podminky (if statement), podle kterych urcis, co se bude s cisly dit podle zadane operace
 *    a proved danou operaci - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements.
 * 7) Vypis promennou result do konzole
 * 
 * Mozna rozsireni programu pro rychliky / na doma (na poradi nezalezi):
 * 1) Vypis do konzole pred nactenim kazdeho uzivatelova vstupu co po nem chces
 * 2) a) Kontroluj, ze uzivatel do vstupu zadal, co mel (cisla, popr. ciselnou operaci). Pokud zadal neco jineho, napis mu, co ma priste zadat a program ukoncete.
 * 2) b) To same, co a) ale misto ukonceni programu opakovane cti vstup, dokud uzivatel nezada to, co ma
 *       - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-while-statement
 * 3) Umozni uzivateli zadavat i desetinna cisla, tedy prekopej kalkulacku tak, aby umela pracovat s floaty
 */

internal class Program
{
    private static void Main(string[] args)
    {
        bool restart = true;

        //definovani funkci na zakladni operace
        static double Add(double a, double b)
        {
            return a + b;
        }

        static double Subtract(double a, double b)
        {
            return a - b;
        }

        static double Divide(double a, double b)
        {
            return a / b;
        }

        static double Multiply(double a, double b)
        {
            return a * b;
        }

        //pokud je restart True, tak to jde dokola
        while (restart)
        {
            string result = "";
            double a;
            double b;
            //try catch statement - pokud je invalid input, tak se pta jestli chce uzivatel zadat neco jineho a podle toho se dal ridi
            try
            {
                Console.WriteLine("operation(+, -, *, /, ^, √, log, exp, baseConvert)");
                string op = Console.ReadLine();
                //pokud je operator exp tak zada jen jedno cislo a, ktere pak jde do funkce Math.Exp() - e^a 
                if (op =="exp")
                {
                    Console.WriteLine("number");
                    a = Convert.ToDouble(Console.ReadLine());
                    result = Convert.ToString(Math.Exp(a));
                    Console.WriteLine(result);
                    Console.ReadKey();
                    restart = false;
                }
                else if(op == "baseConvert"){
                    Console.WriteLine("number(cannot be decimal)");
                    //definice int c, protoze dalsi funkce nepodporuje double
                    int c = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("choose base to convert to: 2, 8, 10, 16");
                    int cBase = Convert.ToInt32(Console.ReadLine());
                    //prevod do soustavy funkci Convert.ToString(Int32, Int32), ktera vezme cislo a prevede ho do dane soustavy
                    result = Convert.ToString(c, cBase);
                    Console.WriteLine(result);
                    Console.ReadKey();
                    restart = false;

                }
                else
                {
                    Console.WriteLine("first number");
                    a = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("second number");
                    b = Convert.ToDouble(Console.ReadLine());
                    switch (op)
                    {
                        case "+":
                            result = Convert.ToString(Add(a, b));
                            break;
                        case "-":
                            result = Convert.ToString(Subtract(a, b));
                            break;
                        case "/":
                            result = Convert.ToString(Divide(a, b));
                            break;
                        case "*":
                            result = Convert.ToString(Multiply(a, b));
                            break;
                        case "^":
                            //vyuziti built in funkce Math.Pow() k mocneni
                            result = Convert.ToString(Math.Pow(a, b));
                            break;
                        case "√":
                            //vyuziti te same funkce jen s 1/b, aby to byla odmocnina
                            result = Convert.ToString(Math.Pow(a, 1 / b));
                            break;
                        case "log":
                            //vyuziti Math.Log()
                            // pokud je b "eulerovo cislo" vrati prirozeny log
                            if (b == 2.8)
                            {
                                result = Convert.ToString(Math.Log(a));
                            }
                            //pokud je b cokoliv jineho tak vrati log a o zakladu b
                            else
                            {
                                result = Convert.ToString(Math.Log(a, b));
                            }

                            break;
                        default:
                            //pokud operator neexistuje, tak hodi error coz ho rovnou dostane do catch casti 
                            throw new Exception("invalid operator");
                    }
                    Console.WriteLine(result);
                    Console.ReadKey();
                    //ukonci cyklus
                    restart = false;
                }
                
                
                

                
            }
            //pokud se nasktne error, tak to jde sem
            catch (Exception ex)
            {
                Console.WriteLine("invalid input");
                Console.WriteLine("do you want to try again? y/n");
                string tryAgain = Console.ReadLine();
                //ukonci cyklus pokud neni odpoved y
                if (tryAgain.ToLower() != "y")
                {
                    restart = false;
                }
                Console.ReadKey();

            }
        }
    }
}



