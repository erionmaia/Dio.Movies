using System;

namespace Dio.Movies
{
    class Program
    {
        static MovieRepository repository = new MovieRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();
            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListMovie();
                        break;
                    case "2":
                        InsertMovie();
                        break;
                    case "3":
                        UpdateMovie();
                        break;
                    case "4":
                        DeleteMovie();
                        break;
                    case "5":
                        InfoMovie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOption();
            }
            System.Console.WriteLine("Thanks for using our services!");
            Console.ReadLine();
        }
        private static void DeleteMovie()
        {
            System.Console.WriteLine("Insert Movie's code: ");
            int indexMovie = int.Parse(Console.ReadLine());
            
            repository.Delete(indexMovie);
        }
        private static void InfoMovie()
        {
            System.Console.WriteLine("Insert Movie's code: ");
            int indexMovie = int.Parse(Console.ReadLine());
            var movie = repository.ReturnByCod(indexMovie);
            System.Console.WriteLine(movie);
        }
        private static void UpdateMovie()
        {
            System.Console.WriteLine("Insert Movie's code: ");
            int indexMovie = int.Parse(Console.ReadLine());
            
            foreach (int i in Enum.GetValues(typeof(Category)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Category), i));
            }
            System.Console.WriteLine("Choose your category by the options ahead: ");
            int pushCategory = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter movie's title: ");
            string pushTitle = Console.ReadLine();

            System.Console.WriteLine("Enter movie's release date: ");
            int pushYear = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter movie's description: ");
            string pushDescription = Console.ReadLine();

            Movie updateMovie = new Movie(cod: indexMovie,
                                        category: (Category)pushCategory,
                                        title: pushTitle,
                                        year: pushYear,
                                        description: pushDescription);
            repository.Update(indexMovie, updateMovie);
        }
        private static void ListMovie()
        {
            System.Console.WriteLine("List movies: ");
            
            var list = repository.List();
            if (list.Count == 0)
            {
                System.Console.WriteLine("No movies registered.");
                return;
            }
            foreach (var movie in list)
            {
                var excluded = movie.returnExcluded();
                System.Console.WriteLine("#COD {0}: - {1} {2}", movie.returnCod(), movie.returnTitle(), (excluded ? "*EXCLUDED*" : ""));
            }
        }
        private static void InsertMovie()
        {
            System.Console.WriteLine("Enter new movie");
            
            foreach (int i in Enum.GetValues(typeof(Category)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Category), i));
            }
            System.Console.WriteLine("Choose your category by the options ahead: ");
            int pushCategory = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter movie's title: ");
            string pushTitle = Console.ReadLine();

            System.Console.WriteLine("Enter movie's release date: ");
            int pushYear = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter movie's description: ");
            string pushDescription = Console.ReadLine();

            Movie newMovie = new Movie(cod: repository.NextCod(),
                                        category: (Category)pushCategory,
                                        title: pushTitle,
                                        year: pushYear,
                                        description: pushDescription);
            repository.Insert(newMovie);
        }
        private static string GetUserOption()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("   Welcome do ErionFlix!   ");
            System.Console.WriteLine("    Choose your option: ");
            System.Console.WriteLine("1- List of Movies");
            System.Console.WriteLine("2- Enter new Movie");
            System.Console.WriteLine("3- Update Movie");
            System.Console.WriteLine("4- Delete Movie");
            System.Console.WriteLine("5- Movie's Info");
            System.Console.WriteLine("C- Clear");
            System.Console.WriteLine("X- Exit");
            System.Console.WriteLine();
            string userOption = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return userOption;
        }

    }
}