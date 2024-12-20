using MimersView.Desktop.Models;
using System.Collections.ObjectModel;

namespace MimersView.Desktop.ViewModels
{
    public class ClassesViewVM
    {
        // Observable collection for binding
        public ObservableCollection<SchoolClass> Classes { get; set; } = [];

        public ClassesViewVM()
        {
            // Add standard course data
            Classes.Add(new SchoolClass
            {
                Name = "Matematik",
                ContactPerson = "John Nielsen",
                Description = "This course covers written and oral mathematics, preparing students for practical problem-solving."
            });

            Classes.Add(new SchoolClass
            {
                Name = "Engelsk",
                ContactPerson = "Sofie Andersen",
                Description = "Focus on oral and written English skills, including communication and comprehension."
            });

            Classes.Add(new SchoolClass
            {
                Name = "Fysik",
                ContactPerson = "Lars Petersen",
                Description = "Explore the fundamentals of physics, including mechanics, electricity, and thermodynamics."
            });

            Classes.Add(new SchoolClass
            {
                Name = "Kemi",
                ContactPerson = "Lars Petersen",
                Description = "An introduction to chemical reactions, the periodic table, and lab experiments."
            });

            Classes.Add(new SchoolClass
            {
                Name = "Biologi",
                ContactPerson = "Mette Sørensen",
                Description = "Study living organisms, ecosystems, and the environment."
            });

            Classes.Add(new SchoolClass
            {
                Name = "Geografi",
                ContactPerson = "Kasper Hansen",
                Description = "Learn about Earth's physical features, climate, and human geography."
            });

            Classes.Add(new SchoolClass
            {
                Name = "Historie",
                ContactPerson = "Mette Sørensen",
                Description = "Understand the key events, figures, and movements that shaped the modern world."
            });

            Classes.Add(new SchoolClass
            {
                Name = "Samfundsfag",
                ContactPerson = "Kasper Hansen",
                Description = "Examine social structures, political systems, and economics in society."
            });

            Classes.Add(new SchoolClass
            {
                Name = "Kristendom",
                ContactPerson = "Mette Sørensen",
                Description = "Study Christian traditions, ethics, and their impact on culture and history."
            });

            Classes.Add(new SchoolClass
            {
                Name = "Idræt",
                ContactPerson = "Kasper Hansen",
                Description = "Focus on physical education, teamwork, and maintaining a healthy lifestyle."
            });
        }
    }
}