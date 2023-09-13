// See https://aka.ms/new-console-template for more information
using BaseCLI;
using FlatHunter.Console;

Console.WriteLine("Hello, World!");

CLI.Execute(args, new[] { typeof(TestArgs).Assembly }, services => { });