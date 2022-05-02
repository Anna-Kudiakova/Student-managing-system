using CSharp.Lab04.Models;
using System.Collections.Generic;


namespace CSharp.Lab04.Tools.DataStorage
{
    internal interface IDataStorage
    {

        void AddPerson(Person person);

        void RemovePerson(Person person);

        void DoChanges();

        List<Person> PersonsList { get; }
    }
}
