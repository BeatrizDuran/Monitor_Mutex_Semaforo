using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mutex_Semaphore_Monitor
{
    class Program
    {
        /// <summary>
        /// Primera sección critica...........MUTEX
        /// </summary>
        static void PrimerDelegado()
        {
            Mutex mutex = new Mutex();
            mutex.WaitOne();
            for (int i = 0; i < 5; i++)
            {
                    Console.WriteLine("Numero: "+i);
            }
            mutex.ReleaseMutex();
        }
        static void SegundoDelegado()
        {
            Semaphore semaphore = new Semaphore(3,5);
            semaphore.WaitOne();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Numeroooo: "+i);
            }
            semaphore.Release();
        }
        static void TercerDelegado()
        {
            object obj = new object();
            Monitor.Enter(obj);
            try
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.WriteLine("numerito: " + j);
                }
            }
            finally
            {
                Monitor.Exit(obj);
            }
            
            
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 2; i++)
            {
                Thread hilito1 = new Thread(new ThreadStart(PrimerDelegado));
                hilito1.Name = string.Format("Primer hilo");
                Console.WriteLine(Thread.CurrentThread.Name+ "Primer hilo");
                hilito1.Start();
            }
            for (int i = 0; i < 2; i++)
            {
                Thread hilito2 = new Thread(new ThreadStart(SegundoDelegado));
                hilito2.Name = string.Format("Segundo hilo");
                Console.WriteLine(Thread.CurrentThread.Name+"Segundo hilo");
                hilito2.Start();
            }
            for (int i = 0; i < 2; i++)
            {
                Thread hilito3 = new Thread(new ThreadStart(TercerDelegado));
                hilito3.Name = string.Format("Tercer hilo");
                Console.WriteLine(Thread.CurrentThread.Name + "Tercer hilo");
                hilito3.Start();
            }
            Console.ReadKey();
        }
    }
}
