using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Context;
using UserManagement.Models;
using UserManagement.Repository.Interface;

namespace UserManagement.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MyContext conn;
        public PersonRepository(MyContext conn)
        {
            this.conn = conn;
        }
        public int Delete(string NIK)
        {
            //throw new NotImplementedException();
            var delPerson = conn.Persons.Find(NIK);
            conn.Persons.Remove(delPerson);
            var result = conn.SaveChanges();
            return result;
        }

        public IEnumerable<Person> Get()
        {
            IEnumerable<Person> persons = new List<Person>();
            persons = conn.Persons.ToList();
            return persons;
        }

        public Person Get(string NIK)
        {
            Person persons = new Person();
            persons = conn.Persons.Find(NIK);
            return persons;
        }

        public int Insert(Person person)
        {
            conn.Persons.Add(person);  //menyimpan ke db
            var result = conn.SaveChanges();
            return result;
        }

        public int Update(Person person)
        {
            Person persons = new Person();
            persons = conn.Persons.Find(person.NIK);
            conn.Persons.Update(person);
            var result = conn.SaveChanges();
            return result;
        }
    }
}
