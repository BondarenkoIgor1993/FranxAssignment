using System;
using Franx.Assignment.Application.Services;
using Franx.Assignment.Domain.Factories;
using Franx.Assignment.Domain.Models;
using SimpleInjector;

namespace Franx.Assignment.ConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            var sentence = Console.ReadLine();

            using (var container = CreateContainer())
            {
                var textService = container.GetInstance<ITextService>();

                var reversed = textService.TransformText(Transformation.Reverse, sentence);
                Console.WriteLine($"Reversed: {reversed}");

                var deduplicated = textService.TransformText(Transformation.Deduplicate, sentence);
                Console.WriteLine($"Deduplicated: {deduplicated}");
            }
        }

        private static Container CreateContainer()
        {
            var container = new Container();

            container.Register<ITextService, TextService>();
            container.Register<ITransformationFactory, TransformationFactory>();

            return container;
        }
    }
}