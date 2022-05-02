using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using CSharp.Lab04.Models;
using CSharp.Lab04.Tools;
using CSharp.Lab04.Tools.Managers;
using CSharp.Lab04.Tools.Navigation;
using CSharp.Lab04.Tools.Exceptions;

namespace CSharp.Lab04.ViewModels
{
    class AddPersonViewModel : BaseViewModel, INotifyPropertyChanged
    {

        private Person _person = StationManager.CurrentPerson;

        private RelayCommand<object> _proceedCommand;
        private RelayCommand<object> _cancelCommand;

        public AddPersonViewModel()
        {
        }

        public Person PersonObject

        {
            get { return _person; }
            set
            {
                _person = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<Object> ProceedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand = new RelayCommand<object>(
                           Proceed, CanExecuteProceed));
            }
        }

        private async void Proceed(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            bool res = await Task.Run(() => {
                try
                {
                    _person.Validation();
                }
                catch (IncorrectNameException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                catch (IncorrectSurnameException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                catch (IncorrectEmailException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                catch (UnbornPersonException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                catch (OveragedPersonException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                catch (NullBirthDateException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                return true;
            });

            LoaderManager.Instance.HideLoader();
            if (res)
            {
                StationManager.DataStorage.AddPerson(_person);
                _person = new Person("", "", "");
                PersonObject = _person;
                NavigatableManager.Instance.Navigate(ViewType.MainScreenView);
            }
        }

        private bool CanExecuteProceed(Object obj)
        {
            return !String.IsNullOrWhiteSpace(PersonObject.Mail) && !String.IsNullOrWhiteSpace(PersonObject.Name) && !String.IsNullOrWhiteSpace(PersonObject.Surname);
        }

        public RelayCommand<Object> CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand<object>(
                           Cancel));
            }
        }

        private void Cancel(object obj)
        {
            StationManager.TablePersonViewModel.Update();
            NavigatableManager.Instance.Navigate(ViewType.MainScreenView);
        }
        
    }
}
