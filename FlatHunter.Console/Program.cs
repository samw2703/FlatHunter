// See https://aka.ms/new-console-template for more information
using BaseCLI;
using FlatHunter.Console;

await CLI.Execute(args, new[] { typeof(TestArgs).Assembly }, services => { });