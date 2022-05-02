using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp.Lab04.Models;
using CSharp.Lab04.Tools;
using CSharp.Lab04.Tools.Managers;
using CSharp.Lab04.Tools.Navigation;
using CSharp.Lab04.Tools.Exceptions;

namespace CSharp.Lab04.ViewModels
{
    class EditPersonViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public EditPersonViewModel()
        {
            StationManager.EditPersonViewModel = this;
        }
        
        private Person _person = StationManager.CurrentPerson;
        private Person _editPerson = StationManager.EditPerson;

        private RelayCommand<object> _confirmCommand;
        private RelayCommand<object> _cancelCommand;
        
        public Person EditPerson
        {
            get { return _editPerson; }
            set
            {
                _editPerson = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<Object> ConfirmCommand
        {
            get
            {
                return _confirmCommand ?? (_confirmCommand = new RelayCommand<object>(
                           Confirm, CanExecuteProceed));
            }
        }

        private bool CanExecuteProceed(Object obj)
        {
            return !String.IsNullOrWhiteSpace(EditPerson.Mail) && !String.IsNullOrWhiteSpace(EditPerson.Name) && !String.IsNullOrWhiteSpace(EditPerson.Surname);
        }

        private async void Confirm(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            bool res = await Task.Run(() => {
                try
                {
                    _editPerson.Validation();
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
                _person.Name = _editPerson.Name;
                _person.Surname = _editPerson.Surname;
                _person.Mail = _editPerson.Mail;
                _person.BirthDate = _editPerson.BirthDate;
                StationManager.EditPerson = null;
                StationManager.DataStorage.DoChanges();
                StationManager.TablePersonViewModel.Update();
                NavigatableManager.Instance.Navigate(ViewType.MainScreenView);
            }
        }

        public void Update()
        {
            _editPerson = StationManager.EditPerson;
            _person = StationManager.CurrentPerson;
            OnPropertyChanged("EditPerson");
        }

        public RelayCommand<Object> CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand<object>(
                           Cancel));
            }
        }


        private async void Cancel(object obj)
        {
            StationManager.EditPerson = null;
            NavigatableManager.Instance.Navigate(ViewType.MainScreenView);

        }

    }
}
