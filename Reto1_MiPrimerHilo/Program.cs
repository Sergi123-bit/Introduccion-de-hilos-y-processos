using System;
using System.Threading;

Console.WriteLine($"[Main] ID: {Environment.CurrentManagedThreadId}");

var t = new Thread(() =>
{
    for (int i = 1; i <= 5; i++)
    {
        Console.WriteLine($"[Hilo {Environment.CurrentManagedThreadId}] Número: {i}");
        Thread.Sleep(500);
    }
});

t.Start();

// Si pones t.Join() aquí, Main esperará a que t termine antes de seguir.
// t.Join();

for (int i = 1; i <= 3; i++)
{
    Console.WriteLine($"[Main {Environment.CurrentManagedThreadId}] Trabajando... {i}");
    Thread.Sleep(400);
}

// Si pones t.Join() aquí (al final), Main hace su trabajo en paralelo y espera al final.
t.Join();
Console.WriteLine("[Main] Fin del programa.");