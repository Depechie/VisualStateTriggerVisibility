using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;

namespace VisualStateTriggerVisibility
{
    public class Person
    {
        public string Name { get; set; }
    }

    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public List<Person> People { get; set; }

        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                if(value == _selectedPerson)
                    return;

                _selectedPerson = value;
                OnPropertyChanged();
            }
        }

        public MainPage()
        {
            this.InitializeComponent();

            People = new List<Person>() { new Person() { Name = "Glenn" }, new Person() { Name = "Bart" }, new Person() { Name = "Nico" } };
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
