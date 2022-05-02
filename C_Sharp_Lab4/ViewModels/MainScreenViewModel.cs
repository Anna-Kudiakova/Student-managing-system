
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using System.Windows.Forms;
using CSharp.Lab04.Models;
using CSharp.Lab04.Tools;
using CSharp.Lab04.Tools.Managers;
using CSharp.Lab04.Tools.Navigation;

namespace CSharp.Lab04.ViewModels
{
    internal class MainScreenViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public MainScreenViewModel()
        {
            StationManager.TablePersonViewModel = this;
        }

        private List<Person> _personList = StationManager.DataStorage.PersonsList;

        private string[] _sortingList =
        {
            "Name",
            "Surname",
            "Email",
            "Birth date",
            "Sun sign",
            "Chinese sign"
        };

        private string[] _filteringList =
        {
            "Name",
            "Surname",
            "Email",
            "Sun sign",
            "Chinese sign"
        };

        private RelayCommand<object> _addCommand;
        private RelayCommand<object> _editCommand;
        private RelayCommand<object> _removeCommand;
        private RelayCommand<object> _filteringCommand;

        private int _sorting = 0;
        private int _filtering = 0;

        public string FilterString { get; set; }

        public int Sorting
        {
            get { return _sorting; }
            set
            {
                _sorting = value;
                OnPropertyChanged("PersonList");
            }
        }

        public int Filtering
        {
            get { return _filtering; }
            set
            {
                _filtering = value;
                OnPropertyChanged("PersonList");
            }
        }


        public object SelectedPerson { get; set; }

        public IEnumerable<Person> PersonList
        {
            get
            {
                IEnumerable<Person> peopleList = _personList;

                switch (Sorting)
                {
                    case 0:
                        peopleList = peopleList.OrderBy(x => x.Name);
                        break;
                    case 1:
                        peopleList = peopleList.OrderBy(x => x.Surname);
                        break;
                    case 2:
                        peopleList = peopleList.OrderBy(x => x.Mail);
                        break;
                    case 3:
                        peopleList = peopleList.OrderBy(x => x.BirthDate);
                        break;
                    case 4:
                        peopleList = peopleList.OrderBy(x => x.SunSign);
                        break;
                    case 5:
                        peopleList = peopleList.OrderBy(x => x.ChineseSign);
                        break;
                }

                if (String.IsNullOrWhiteSpace(FilterString))
                    return peopleList;

                switch (Filtering)
                {
                    case 0:
                        peopleList = peopleList.Where(x => x.Name.Contains(FilterString));
                        break;
                    case 1:
                        peopleList = peopleList.Where(x => x.Surname.Contains(FilterString));
                        break;
                    case 2:
                        peopleList = peopleList.Where(x => x.Mail.Contains(FilterString));
                        break;
                    case 3:
                        peopleList = peopleList.Where(x => x.SunSign.Contains(FilterString));
                        break;
                    case 4:

                        peopleList = peopleList.Where(x => x.ChineseSign.Contains(FilterString));

                        break;
                }

                return peopleList;
            }
        }

        public IEnumerable<string> SortingList
        {
            get { return _sortingList; }
        }

        public IEnumerable<string> FilteringList
        {
            get { return _filteringList; }
        }

        public RelayCommand<object> AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand<object>(
                           AddPerson));
            }
        }

        private void AddPerson(object obj)
        {
            StationManager.CurrentPerson = new Person("", "", "");
            NavigatableManager.Instance.Navigate(ViewType.AddPersonView);
        }

        public RelayCommand<object> EditCommand
        {
            get
            {
                return _editCommand ?? (_editCommand =
                           new RelayCommand<object>(EditPerson, CanModifyPerson));
            }
        }

        private async void EditPerson(object obj)
        {
            LoaderManager.Instance.ShowLoader();

            await Task.Run(() =>
            {
                StationManager.CurrentPerson = (Person)SelectedPerson;

                StationManager.EditPerson = new Person(
                    StationManager.CurrentPerson.Name,
                    StationManager.CurrentPerson.Surname,
                    StationManager.CurrentPerson.Mail,
                    StationManager.CurrentPerson.BirthDate

                );
            });
            LoaderManager.Instance.HideLoader();
            if (StationManager.EditPersonViewModel != null)
                StationManager.EditPersonViewModel.Update();

            NavigatableManager.Instance.Navigate(ViewType.EditPersonView);
        }

        public RelayCommand<object> RemoveCommand
        {
            get
            {
                return _removeCommand ?? (_removeCommand =
                           new RelayCommand<object>(RemovePerson, CanModifyPerson));
            }
        }

        private async void RemovePerson(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                Person person = (Person)SelectedPerson;

                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(
                    "Are you sure you want to delete " + person.Name + " " + person.Surname + "?",
                    "Deleting in process",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    StationManager.DataStorage.RemovePerson(person);
                    OnPropertyChanged("PersonList");
                }
            });

            LoaderManager.Instance.HideLoader();
        }

        public RelayCommand<object> FilteringCommand
        {
            get
            {
                return _filteringCommand ?? (_filteringCommand = new RelayCommand<object>(
                           (o => { OnPropertyChanged("PersonList"); })));
            }
        }

        private bool CanModifyPerson(object obj)
        {
            return SelectedPerson != null;
        }



        public void Update()
        {
            OnPropertyChanged("PersonList");
        }
    }
}
