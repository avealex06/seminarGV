using System;
namespace classes
{
	public class Rectangle
	{
		public static int width,height;

        static int CalculateArea(int width, int height)
		{
			int area = width * height;
			return area;
		}
		static string CalculateAspectRatio(int width, int height)
		{
            static int CommonDivider(int a, int b)
            {
                int Remainder;

                while (b != 0)
                {
                    Remainder = a % b;
                    a = b;
                    b = Remainder;
                }

                return a;
            }
            int widthAsp = width / CommonDivider(width, height);
            int heightAsp = height / CommonDivider(width, height);
            if (widthAsp>heightAsp)
            {
                return $"{widthAsp}:{heightAsp} - obedelnik je siroky";
            }
            else if (heightAsp>widthAsp)
            {
                return $"{widthAsp}:{heightAsp} - obedelnik je vysoky";
            }
            else if (widthAsp==heightAsp)
            {
                return $"{widthAsp}:{heightAsp} - je to ctverec";
            }
            else
            {
                return null;
            }
                
        }
        static string ContainsPoint(int x, int y)
        {
            if (x<=width && y<=height )
            {
            return "obsahuje bod";
            }
            else
            {
            return "neobsahuje bod";
            }
        }

        public Rectangle()
        {
            width = Convert.ToInt32(Console.ReadLine());
            height = Convert.ToInt32(Console.ReadLine());
        }
	}
}

