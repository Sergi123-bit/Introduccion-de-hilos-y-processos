using System;
using System.Threading;

const int iteraciones = 100_000; // Sube a 1_000_000 si en tu equipo no falla con 100_000

// 1. Sin protección
for (int run = 1; run <= 5; run++)
{
    int contador = 0;
    var a = new Thread(() => { for (int i = 0; i < iteraciones; i++) contador++; });
    var b = new Thread(() => { for (int i = 0; i < iteraciones; i++) contador++; });
    a.Start();
    b.Start();
    a.Join();
    b.Join();
    Console.WriteLine($"Sin lock - Ejecución {run}: {contador}");
}

Console.WriteLine();

// 2. Con lock
object cerrojo = new object();
for (int run = 1; run <= 5; run++)
{
    int contador = 0;
    var a = new Thread(() => { for (int i = 0; i < iteraciones; i++) lock (cerrojo) contador++; });
    var b = new Thread(() => { for (int i = 0; i < iteraciones; i++) lock (cerrojo) contador++; });
    a.Start();
    b.Start();
    a.Join();
    b.Join();
    Console.WriteLine($"Con lock - Ejecución {run}: {contador}");
}

Console.WriteLine();

// 3. Con Interlocked.Increment
for (int run = 1; run <= 5; run++)
{
    int contador = 0;
    var a = new Thread(() => { for (int i = 0; i < iteraciones; i++) Interlocked.Increment(ref contador); });
    var b = new Thread(() => { for (int i = 0; i < iteraciones; i++) Interlocked.Increment(ref contador); });
    a.Start();
    b.Start();
    a.Join();
    b.Join();
    Console.WriteLine($"Con Interlocked - Ejecución {run}: {contador}");
}