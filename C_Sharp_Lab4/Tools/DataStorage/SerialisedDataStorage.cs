using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharp.Lab04.Models;
using CSharp.Lab04.Tools.Managers;

namespace CSharp.Lab04.Tools.DataStorage
{
    internal class SerializedDataStorage : IDataStorage
    {
        private readonly List<Person> _persons;

        internal SerializedDataStorage()
        {
            try
            {
                _persons = SerializationManager.Deserialize<List<Person>>(FileStorage.DatabaseFilePath);
            }
            catch (FileNotFoundException)
            {
                _persons = new List<Person>();
                string[] names =
                {
                    "Ammi",
                    "Alisa",
                    "Amer",
                    "Baruk",
                    "Borya",
                    "Valeria",
                    "Vlad",
                    "Marina",
                    "Meriem",
                    "Lesia",
                    "Danylo",
                    "Maria",
                    "Angelina",
                    "Natali",
                    "Vasylysa",
                    "Mirabella",
                    "Elizabeth",
                    "Sigizmund",
                    "Charle",
                    "Jean",
                    "Christine",
                    "Michael",
                    "Michelle",
                    "Artur",
                    "Ursula",
                    "Cinderella",
                    "Malificenta",
                    "Karim",
                    "Izmir",
                    "Cler",
                    "Daria",
                    "Olya",
                    "Pierre",
                    "Andre",
                    "Perrine",
                    "Sandrine",
                    "Amelie",
                    "Sergii",
                    "Anastasia",
                    "Marta",
                    "Davyd",
                    "Sergii",
                    "Gertruda",
                    "Lukrecia",
                    "Margo",
                    "Misha",
                    "Marsym",
                    "Illya",
                    "Vanda",
                    "Claude"
                };
                string[] surnames =
                {
                    "Birais",
                    "Clerine",
                    "Budenkov",
                    "Jovtuha",
                    "Stepanenko",
                    "Pelovysh",
                    "Kozlov",
                    "Vasylkov",
                    "Karpyn",
                    "Svitlyk",
                    "Curie",
                    "Mendeleev",
                    "Jeriko",
                    "Delacroix",
                    "Caravadgo",
                    "Brevi",
                    "Marais",
                    "Nardew",
                    "Chucishvili",
                    "Voloshyna",
                    "Kruchan",
                    "Grebenuk",
                    "Chagal",
                    "Maistrenko",
                    "Bondarenko",
                    "Buchko",
                    "Bublik",
                    "Vovk",
                    "Gorborykov",
                    "Lesiasnyk",
                    "Cyrylin",
                    "Dupee",
                    "Frou",
                    "Glybovets",
                    "Maeivskiy",
                    "Grucheva",
                    "Kaliina",
                    "Kalyta",
                    "Borovyk",
                    "Nazarenko",
                    "Medici",
                    "Buanarotti",
                    "Marceil",
                    "Ulitka",
                    "Cemilenko",
                    "Crutinkov",
                    "Povorotyk",
                    "Davletova",
                    "Omar",
                    "Strezenko"
                };
                string[] mails = surnames.Select(s => s.ToLowerInvariant()).ToArray();

                Random random = new Random();
                DateTime start = new DateTime(1889, 5, 1);
                int range = (DateTime.Today - start).Days;
                for (int i = 0; i < 50; ++i)
                {
                    Person person = new Person(names[i], surnames[i], mails[i] + "@gmail.com", start.AddDays(random.Next(range)));
                    _persons.Add(person);
                }

                SaveChanges();
            }
        }



        public void AddPerson(Person person)
        {
            _persons.Add(person);
            SaveChanges();
        }

        public void RemovePerson(Person person)
        {
            _persons.Remove(person);
            SaveChanges();
        }

        public void DoChanges()
        {
            SaveChanges();
        }

        public List<Person> PersonsList
        {
            get { return _persons; }
        }

        private void SaveChanges()
        {
            SerializationManager.Serialize(_persons, FileStorage.DatabaseFilePath);
        }
    }
}
