using CSharp.Lab04.Tools.Exceptions;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;


namespace CSharp.Lab04.Models
{
    [Serializable]
    internal class Person
    {
        private string _name;
        private string _surname;
        private string _mail;
        private DateTime? _birthDate;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Mail
        {
            get { return _mail; }
            set
            {
                _mail = value;
                OnPropertyChanged();
            }
        }

        public DateTime? BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = Convert.ToDateTime(value);

                OnPropertyChanged();
                OnPropertyChanged("IsAdult");
                OnPropertyChanged("IsBirthday");
                OnPropertyChanged("BirthdayString");
                OnPropertyChanged("SunSign");
                OnPropertyChanged("ChineseSign");
            }
        }

        public Person(string name, string surname, string email, DateTime? birthDate = null)
        {
            _name = name.Trim();
            _surname = surname.Trim();
            _mail = email.Trim();
            _birthDate= birthDate.Value;

        }

        public Person(string name = " ", string surname = " ", string email = " ")
        {
            _name = name.Trim();
            _surname = surname.Trim();
            _mail = email.Trim();
        }

        public Person(string name, string surname, DateTime? birthDate)
        {
            _name = name.Trim();
            _surname = surname.Trim();
            _birthDate = birthDate;
        }

        private int Age
        {
            get { return DefineAge(); }
        }

        public bool IsAdult
        {
            get { return Age >= 18; }
        }

        public string BirthdayString
        {
            get { return _birthDate.Value.ToString("dd MMMM yyyy"); }
        }

        public string SunSign
        {
            get { return DefineSunSign(); }
        }

        public string ChineseSign
        {
            get { return DefineChineseSign(); }
        }

        public bool IsBirthday
        {
            get { return DateTime.Now.DayOfYear == BirthDate.Value.DayOfYear; }
        }

        public void Validation()
        {
            NameIsCorrect();
            SurnameIsCorrect();
            EmailIsCorrect();
            BirthDateIsCorrect();
        }

        private int DefineAge()
        {
            int age = -1;
            age = DateTime.Now.Year - BirthDate.Value.Year;
            if (DateTime.Now.DayOfYear < BirthDate.Value.DayOfYear)
            {
                age -= 1;
            }
            return age;
        }

        private string DefineSunSign()
        {
            string zodiac = "";
            int month = BirthDate.Value.Month;
            int day = BirthDate.Value.Day;
            if ((day >= 21 && month == 3) || (day <= 19 && month == 4))
                zodiac = "Aries";
            if ((day >= 23 && month == 9) || (day <= 23 && month == 10))
                zodiac = "Libra";
            if ((day >= 20 && month == 4) || (day <= 20 && month == 5))
                zodiac = "Taurus";
            if ((day >= 24 && month == 10) || (day <= 21 && month == 11))
                zodiac = "Scorpio";
            if ((day >= 21 && month == 5) || (day <= 21 && month == 6))
                zodiac = "Gemini";
            if ((day >= 22 && month == 11) || (day <= 21 && month == 12))
                zodiac = "Sagittarius";
            if ((day >= 22 && month == 6) || (day <= 22 && month == 7))
                zodiac = "Cancer";
            if ((day >= 22 && month == 12) || (day <= 19 && month == 1))
                zodiac = "Capricorn";
            if ((day >= 23 && month == 7) || (day <= 22 && month == 8))
                zodiac = "Leo";
            if ((day >= 20 && month == 1) || (day <= 18 && month == 2))
                zodiac = "Aquarius";
            if ((day >= 24 && month == 8) || (day <= 23 && month == 9))
                zodiac = "Virgo";
            if ((day >= 19 && month == 2) || (day <= 20 && month == 3))
                zodiac = "Pisces";
            return zodiac;
        }

        private string DefineChineseSign()
        {
            
            int zodiac = (_birthDate.Value.Year - 4) % 12;
            string[] animals = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
            string chineseZodiac = animals[zodiac];
            return chineseZodiac;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void EmailIsCorrect()
        {
            if (!Regex.IsMatch(Mail, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase))
            {
                throw new IncorrectEmailException(Mail);
            }
        }

        private void NameIsCorrect()
        {
            if (!Regex.IsMatch(Name, @"^[a-zA-Z]+$"))
            {
                throw new IncorrectNameException(Name);
            }

        }
        private void SurnameIsCorrect()
        {
            if (!Regex.IsMatch(Surname, @"^[a-zA-Z]+$"))
            {
                throw new IncorrectSurnameException(Surname);
            }
        }


        private void BirthDateIsCorrect()
        {
            if(!BirthDate.HasValue)
            {
                throw new NullBirthDateException();
            }
            if (Age < 0)
            {
                throw new UnbornPersonException(BirthDate.Value);
            }

            if (Age > 135)
            {
                throw new OveragedPersonException(BirthDate.Value);
            }
        }
    }
}
