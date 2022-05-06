using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica
{
    class Agenda
    {
        private const int SIZE = 10;  
        private Contact[] _contacts;
        private int _index;

        public int ContactNumber
        {
            get
            {
                return _index;
            }
        }
        public Agenda()
        {
            _index = 0;
            _contacts = new Contact[SIZE];
        }

        public void AddContact(Contact contact)
        {
             
            if (_index < SIZE)
            {
                _contacts[_index] = contact;
                _index++;
            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Agrege mas memoria a la agenda");
            }
        }

        public void DeleteContact(string name)
        {
            var contactToDelete = _contacts.FirstOrDefault(contact => contact.Name == name);

            if (_index > 0)
            {
                if (contactToDelete != null)
                {
                    int index = Array.IndexOf(_contacts, contactToDelete);
                    _contacts[index] = null;
                    _index--;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("La agenda esta vacia");
            }
        }

        private bool IsEmpty()
        {
            if (_index == 0)
            {
                return true;
            }

            return false;
        }

        public void ShowContactsSorted(string input)
        {
            if (IsEmpty() != true && (input == "A" || input == "D"))
            {
                Contact[] sortedContacts = new Contact[_index];
                Array.Copy(_contacts, sortedContacts, _index);
                Array.Sort(sortedContacts);
                if (input == "D")
                {
                    Array.Reverse(sortedContacts);
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(ContactsChain(sortedContacts));
            }
            else if (IsEmpty())
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("La agenda esta vacia");
            }

        }

        public Contact SearchByName(string name)
        {
            foreach (Contact contact in _contacts)
            {
                if (contact != null && contact.Name.ToLowerInvariant() == name.ToLowerInvariant())
                {
                    return contact;
                }
            }

            return null;
        }

         public void ShowContacts()
        {

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return ContactsChain(_contacts);
        }

         private string ContactsChain(Contact[] contacts)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _index; i++)
            {
                if (contacts[i] != null)
                {
                    string data = string.Format("{0}. {1}", i + 1, contacts[i]);
                    sb.AppendLine(data);
                }
            }

            return sb.ToString();
        }

    }

}
