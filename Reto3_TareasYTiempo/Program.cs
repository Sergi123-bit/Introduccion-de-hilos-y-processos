using System;
using System.Diagnostics;
using System.Threading.Tasks;

async Task SimularDescargaAsync(int numero, int segundos)
{
    Console.WriteLine($"Descarga {numero} ({segundos}s) iniciada...");
    await Task.Delay(TimeSpan.FromSeconds(segundos));
    Console.WriteLine($"Descarga {numero} completada.");
}

// 1. Una detrás de otra
var sw1 = Stopwatch.StartNew();
await SimularDescargaAsync(1, 1);
await SimularDescargaAsync(2, 2);
await SimularDescargaAsync(3, 3);
sw1.Stop();
Console.WriteLine($"Secuencial: {sw1.Elapsed.TotalSeconds:F2} s\n");

// 2. A la vez con Task.WhenAll
var sw2 = Stopwatch.StartNew();
await Task.WhenAll(
    SimularDescargaAsync(1, 1),
    SimularDescargaAsync(2, 2),
    SimularDescargaAsync(3, 3)
);
sw2.Stop();
Console.WriteLine($"En paralelo (WhenAll): {sw2.Elapsed.TotalSeconds:F2} s");