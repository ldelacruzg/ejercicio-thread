using System;

namespace EjercicioThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CapturardorTeclas[] capturardorTeclas = new CapturardorTeclas[4];
            Thread[] hilos= new Thread[4];

            for (int i = 0; i < 4; i++)
            {
                capturardorTeclas[i] = new CapturardorTeclas();
                hilos[i] = new Thread(capturardorTeclas[i].Capturar);
                hilos[i].Start();
            }

            for (int i = 0; i < 4; i++)
            {
                hilos[i].Join();
            }

            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Hilo {0}: {1}", i+1, capturardorTeclas[i].TeclasCapturadas);
            }

            Console.ReadKey();
        }
    }

    public class CapturardorTeclas
    {
        private string teclasCapturadas;

        public CapturardorTeclas()
        {
            teclasCapturadas = "";
        }

        public void Capturar()
        {
            ConsoleKeyInfo teclaCapturada;

            do
            {
                teclaCapturada = Console.ReadKey();
                teclasCapturadas += teclaCapturada.KeyChar;
            } while (teclaCapturada.Key != ConsoleKey.Enter);
        }

        public string TeclasCapturadas { get => teclasCapturadas; }
    }
}

/*namespace EjercicioThread
{
    internal class Programa
    {
        static string teclasCapturadas1 = "", teclasCapturadas2 = "", teclasCapturadas3 = "", teclasCapturadas4 = "";

        static void Main(string[] args)
        {
            Thread hilo1 = new Thread(() => Capturar(ref teclasCapturadas1));
            Thread hilo2 = new Thread(() => Capturar(ref teclasCapturadas2));
            Thread hilo3 = new Thread(() => Capturar(ref teclasCapturadas3));
            Thread hilo4 = new Thread(() => Capturar(ref teclasCapturadas4));

            // Indica que el hilo tiene una prioridad ligeramente menor a la normal
            hilo1.Priority = ThreadPriority.BelowNormal;

            // Indica que el hilo tiene la prioridad más alta y se ejecutará con preferencia sobre otros hilos
            hilo2.Priority = ThreadPriority.Highest;
            
            // Indica que el hilo tiene la prioridad más baja y solo se ejecuta cuando no haya ningun otro hilo ejecutándose
            hilo3.Priority = ThreadPriority.Lowest;

            // Indica que el hilo tiene una prioridad ligeramente superior a la normal
            hilo4.Priority = ThreadPriority.AboveNormal;

            hilo1.Start();
            hilo2.Start();
            hilo3.Start();
            hilo4.Start();

            hilo1.Join();
            hilo2.Join();
            hilo3.Join();
            hilo4.Join();

            Console.WriteLine();
            Console.WriteLine("Hilo 1: {0}", teclasCapturadas1);
            Console.WriteLine("Hilo 2: {0}", teclasCapturadas2);
            Console.WriteLine("Hilo 3: {0}", teclasCapturadas3);
            Console.WriteLine("Hilo 4: {0}", teclasCapturadas4);

            Console.ReadKey();
        }

        static void Capturar(ref string teclasCapturadas)
        {
            ConsoleKeyInfo teclaCapturada;

            do
            {
                teclaCapturada = Console.ReadKey();
                teclasCapturadas += teclaCapturada.KeyChar;
            } while (teclaCapturada.Key != ConsoleKey.Enter);
        }
    }
}*/