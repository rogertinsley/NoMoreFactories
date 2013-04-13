using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoMoreFactories.ViewModels
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            Choices = new List<Choice>
                {
                    new Choice { Id = "Ford", Text = "Ford" }, 
                    new Choice { Id = "Volkswagon", Text = "Volkswagon" },
                    new Choice { Id = "Peugeot", Text = "Peugeot" },
                };
        }

        public IEnumerable<Choice> Choices { get; set; }

        [Required]
        public string SelectedId { get; set; }
    }

    public class Choice
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }
}