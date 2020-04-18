using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.IO;
namespace Project
{
    class Program
    {
        public const double g = 9.81, plotnost = 1.2041, C = 0.4, dt = 0.01;
        public static double h0, v0, v, a, h, t,  r, fs, m ;
        public static string data;



        static void Main(string[] args)
        {
            Console.WriteLine("Введите начальную высоту (м). При введении некорректных данных, то h0 = 5");
            try
            {
                h0 = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                h0 = 5;
            }
            if (h0 < 0)
            {
                h0 = 5;
            }
            Console.WriteLine("Ведите начальную скорость тела (м/с). Положительное значение - бросок вверх, отрицательное - бросок вниз.  При введении некорректных данных, то v0 = 5");
            try
            {
                v0 = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                v0 = 5;
            }
            Console.WriteLine("Введите радиус ШАРА (м). При введении некорректных данных, то r = 5");
            try
            {
                r = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                r = 5;
            }
            if (r <= 0)
            {
                r = 5;
            }
            Console.WriteLine("Введите массу тела (кг). При введении некорректных данных, то m = 5 ");
            try
            {
                m = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                m = 5;
            }
            if (m <= 0)
            {
                m = 5;
            }

            Console.WriteLine("Начальная высота h0 = " + h0);
            Console.WriteLine("Начальная скорость v0 = " + v0);
            Console.WriteLine("радиус r = " + r);
            Console.WriteLine("масса тела m = " + m);


            Console.Write("Исходные данные и параметры вывода записаны, консоль будет очищена через 5..");
            Thread.Sleep(1000);
            Console.Write("4..");
            Thread.Sleep(1000);
            Console.Write("3..");
            Thread.Sleep(1000);
            Console.Write("2..");
            Thread.Sleep(1000);
            Console.Write("1..");
            Thread.Sleep(1000);
            Console.Clear();
           
            {
                v = v0;
                h = h0;
                t = 0;

                StreamWriter writerfile = new StreamWriter("/data.dat", false, System.Text.Encoding.Default);


                while (h > 0)
                {
                    fs = C * plotnost * Math.PI * (r * r) * (v * v) / 2 ;
                    double sgn = Math.Sign(v);
                    a =  fs/(m) + g;
                    v = v0 - a *dt;
                    h = h0 + v * dt - (a * dt * dt) / 2;

                    string streamt, streama;
                    streamt = t.ToString("0.000");
                    streama = a.ToString("0.000");
                    data = streamt + " " + streama;

                    Console.WriteLine(data);
                    writerfile.WriteLine(data);
                    
                    t = t + dt;
                    v0 = v;
                    h0 = h;
                   
                }
                writerfile.Close(); 

                Console.ReadKey();

                
            

            }
            Console.ReadKey(); 
        }

    }
}
