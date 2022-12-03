// See https://aka.ms/new-console-template for more information

using System.Reflection;

namespace Advent2022;

internal static class Program
{
    public static void Main(string[] args)
    {
        foreach (var type in Assembly.GetExecutingAssembly().ExportedTypes.Where(x => x.BaseType == typeof(BaseDay)))
        {
            var instance = Activator.CreateInstance(type);
            (instance as BaseDay)?.Execute();
        }
    }
}