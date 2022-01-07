using System;

namespace Dio.Movies
{
    public class Movie : EntityBase
    {
        private Category Category { get; set; }
        private string Title {get; set; }
        private string Description {get; set; }
        private int Year {get; set; }
        private bool Excluded {get; set; }

        public Movie(int cod, Category category, string title, string description, int year)
        {
            this.Cod = cod;
            this.Category = category;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Excluded = false;
        }
        public override string ToString()
        {
            string response = "";
            response += "Category: " + this.Category + Environment.NewLine;
            response += "Title: " + this.Title + Environment.NewLine;
            response += "Description: " + this.Description + Environment.NewLine;
            response += "Release Date: " + this.Year + Environment.NewLine;
            response += "Excluded: " + this.Excluded + Environment.NewLine;
            return response;
        }
        public string returnTitle()
        {
            return this.Title;
        }
        public int returnCod()
        {
            return this.Cod;
        }
        public bool returnExcluded()
        {
            return this.Excluded;
        }
        public void Delete()
        {
            this.Excluded = true;
        }
    }
}