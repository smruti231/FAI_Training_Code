using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1
    {
    class Q5Movies
        {
        class Movie
            {
            public string Title { get; set; }
            public string Director { get; set; }
            public int Year { get; set; }
            }

        class Program
            {
            static List<Movie> movies = new List<Movie>();

            static void Main(string[] args)
                {
                bool continueRunning = true;

                while (continueRunning)
                    {
                    Console.WriteLine("Movie Database App");
                    Console.WriteLine("1. Add Movie");
                    Console.WriteLine("2. Remove Movie");
                    Console.WriteLine("3. Find Movie");
                    Console.WriteLine("4. Update Movie");
                    Console.WriteLine("5. Exit");
                    Console.Write("Select an option: ");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                        {
                        case 1:
                            AddMovie();
                            break;
                        case 2:
                            RemoveMovie();
                            break;
                        case 3:
                            FindMovie();
                            break;
                        case 4:
                            UpdateMovie();
                            break;
                        case 5:
                            continueRunning = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select again.");
                            break;
                        }
                    }
                }

            static void AddMovie()
                {
                Console.Write("Enter movie title: ");
                string title = Console.ReadLine();

                Console.Write("Enter director's name: ");
                string director = Console.ReadLine();

                Console.Write("Enter release year: ");
                int year = int.Parse(Console.ReadLine());

                Movie newMovie = new Movie
                    {
                    Title = title,
                    Director = director,
                    Year = year
                    };

                movies.Add(newMovie);
                Console.WriteLine("Movie added successfully!");
                }

            static void RemoveMovie()
                {
                Console.Write("Enter the title of the movie to remove: ");
                string titleToRemove = Console.ReadLine();

                Movie movieToRemove = movies.Find(movie => movie.Title.Equals(titleToRemove, StringComparison.OrdinalIgnoreCase));

                if (movieToRemove != null)
                    {
                    movies.Remove(movieToRemove);
                    Console.WriteLine("Movie removed successfully!");
                    }
                else
                    {
                    Console.WriteLine("Movie not found.");
                    }
                }

            static void FindMovie()
                {
                Console.Write("Enter the title of the movie to find: ");
                string titleToFind = Console.ReadLine();

                Movie foundMovie = movies.Find(movie => movie.Title.Equals(titleToFind, StringComparison.OrdinalIgnoreCase));

                if (foundMovie != null)
                    {
                    Console.WriteLine($"Title: {foundMovie.Title}");
                    Console.WriteLine($"Director: {foundMovie.Director}");
                    Console.WriteLine($"Year: {foundMovie.Year}");
                    }
                else
                    {
                    Console.WriteLine("Movie not found.");
                    }
                }

            static void UpdateMovie()
                {
                Console.Write("Enter the title of the movie to update: ");
                string titleToUpdate = Console.ReadLine();

                Movie movieToUpdate = movies.Find(movie => movie.Title.Equals(titleToUpdate, StringComparison.OrdinalIgnoreCase));

                if (movieToUpdate != null)
                    {
                    Console.Write("Enter new movie title: ");
                    movieToUpdate.Title = Console.ReadLine();

                    Console.Write("Enter new director's name: ");
                    movieToUpdate.Director = Console.ReadLine();

                    Console.Write("Enter new release year: ");
                    movieToUpdate.Year = int.Parse(Console.ReadLine());

                    Console.WriteLine("Movie updated successfully!");
                    }
                else
                    {
                    Console.WriteLine("Movie not found.");
                    }
                }
            }
        }

    }
