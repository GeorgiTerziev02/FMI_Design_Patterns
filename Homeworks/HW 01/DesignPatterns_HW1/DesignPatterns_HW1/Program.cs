using DesignPatterns_HW1.Common;
using DesignPatterns_HW1.Creators;
using DesignPatterns_HW1.Factories;
using DesignPatterns_HW1.Figures;
using DesignPatterns_HW1.FiguresContainer;
using DesignPatterns_HW1.Providers;

namespace DesignPatterns_HW1
{
    public class Program
    {

        public static void Main()
        {
            IFigureFactoryCreatorProvider figureFactoryCreatorProvider = new FigureFactoryCreatorProvider();
            IFigureFactoryCreator figureFactoryCreator =  figureFactoryCreatorProvider.GetFigureFactoryCreator();

            using var figureFactory = ReadFigureFactory(figureFactoryCreator);
            Start(figureFactory);
        }

        public static void Start(IFigureFactory figureFactory)
        {
            var figuresContainer = CreateFigures(figureFactory);

            while (true)
            {
                try
                {
                    PrintMainMenu();
                    var userInput = Console.ReadLine();
                    var tokens = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var command = tokens[0];

                    if(command == "5")
                    {
                        break;
                    }

                    switch (command)
                    {
                        case "1":
                            {
                                Console.WriteLine(figuresContainer.List());
                            }
                            break;
                        case "2":
                            {
                                Helper.AssertTokensLength(tokens, 2);

                                if (!int.TryParse(tokens[1], out int index))
                                {
                                    throw new ArgumentException(ErrorMessages.INVALID_INPUT);
                                }
                                
                                figuresContainer.RemoveAt(index);
                            }
                            break;
                        case "3":
                            {
                                Helper.AssertTokensLength(tokens, 2);

                                if (!int.TryParse(tokens[1], out int index))
                                {
                                    throw new ArgumentException(ErrorMessages.INVALID_INPUT);
                                }

                                figuresContainer.DuplicateAt(index);
                            }
                            break;
                        case "4":
                            {
                                Helper.AssertTokensLength(tokens, 2);

                                using var stream = new FileStream(tokens[1], FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                                figuresContainer.WriteToStream(stream);
                            }
                            break;
                        default: throw new ArgumentException(ErrorMessages.INVALID_INPUT);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static IFigureFactory ReadFigureFactory(IFigureFactoryCreator figureFactoryCreator)
        {
            PrintFactoryOptions();

            while (true)
            {
                try
                {
                    return figureFactoryCreator.CreateFactory(Console.ReadLine()!);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                };

                Console.WriteLine("Enter valid data");
            }
        }

        public static int ReadFiguresCount()
        {
            Console.WriteLine("Enter figures count:");

            while (true)
            {
                try
                {
                    var number = int.Parse(Console.ReadLine()!);
                    if (number > 0)
                    {
                        return number;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                };

                Console.WriteLine("Enter positive number");
            }
        }

        public static IFigure CreateValidFigure(IFigureFactory figureFactory)
        {
            while (true)
            {
                try
                {
                    return figureFactory.Create();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static IFiguresContainer CreateFigures(IFigureFactory figureFactory)
        {
            var count = ReadFiguresCount();
            var figuresContainer = FiguresContainerCreator.Create(count);

            for (int i = 0; i < count; i++)
            {
                figuresContainer.Add(CreateValidFigure(figureFactory));
            }

            return figuresContainer;
        }

        public static void PrintFactoryOptions()
        {
            Console.WriteLine("Choose creation method");
            Console.WriteLine("1 - Random");
            Console.WriteLine("2 - Console");
            Console.WriteLine("3 {fileName} - File");
            Console.WriteLine("Enter your choice");
        }

        public static void PrintMainMenu()
        {
            Console.WriteLine("Choose what to do");
            Console.WriteLine("1 - List figures");
            Console.WriteLine("2 {index} - Delete figure");
            Console.WriteLine("3 {index} - Duplicate figure");
            Console.WriteLine("4 {fileName} - Store figures to file");
            Console.WriteLine("5 - exit");
        }
    }
}