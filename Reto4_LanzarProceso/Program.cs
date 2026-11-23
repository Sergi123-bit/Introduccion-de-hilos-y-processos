using System;
using System.ComponentModel;
using System.Diagnostics;

// Caso 1: Programa existente (dotnet --version)
var info = new ProcessStartInfo("dotnet", "--version")
{
    RedirectStandardOutput = true,
    RedirectStandardError = true,
    UseShellExecute = false
};

using var p = Process.Start(info)!;
string salida = p.StandardOutput.ReadToEnd();
p.WaitForExit();

Console.WriteLine($"Salida: {salida.Trim()}");
Console.WriteLine($"ExitCode: {p.ExitCode}\n");

// Caso 2: Programa que no existe
try
{
    var infoInexistente = new ProcessStartInfo("programa_que_no_existe_12345")
    {
        UseShellExecute = false
    };
    using var p2 = Process.Start(infoInexistente);
    p2?.WaitForExit();
}
catch (Win32Exception ex)
{
    Console.WriteLine($"Error al lanzar programa inexistente: {ex.Message} (ErrorCode: {ex.NativeErrorCode})");
}