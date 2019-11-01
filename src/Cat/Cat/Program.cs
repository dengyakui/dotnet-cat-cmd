using System;
using McMaster.Extensions.CommandLineUtils;

namespace CliDemo
{
    class Program
    {
        static int Main(string[] args)
        {
            var app = new CommandLineApplication(){ShortVersionGetter = ()=>"1.0",LongVersionGetter = ()=>"long version 1.0.1"};
            app.HelpOption();

            app.ExtendedHelpText = "this command tool is only for demo, should not use in production environment";

            // add first argument
            var firstNameArgument = app.Argument<string>("name", "your name", false);


            var subOption = app.Option("-s|--subject", "the subject", CommandOptionType.SingleValue);

            app.OnExecute(() =>
            {
                Console.WriteLine($"Hello, {firstNameArgument.ParsedValue}, your subject is {subOption.Value()}");
                return 0;
            });

            return app.Execute(args);


        }


    }
}
