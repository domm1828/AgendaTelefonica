using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica
{
    class Control
    {
 
        private Agenda _agenda;

        public Control(Agenda agenda)
        {
            _agenda = agenda;
        }

        public void SeeContacts()
        {
            Clear();
            ShowSortMenu();

            string choice = Console.ReadLine().ToUpper();
            Console.WriteLine();
            Clear();

            switch (choice)
            {
                case "A":

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Ordenar de manera ascedente:");
                    Console.WriteLine();
                    _agenda.ShowContactsSorted(choice);
                    break;
                case "D":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Ordenar de Manera Descendente");
                    Console.WriteLine();
                    _agenda.ShowContactsSorted(choice);
                    break;
                case "E":
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Sin Organizar");
                    break;
            }
            PressToContinue();
        }

        public void ShowSortMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("A. Ordenar Ascendente");
            sb.AppendLine("D. Ordenar Descendente");
            sb.AppendLine("E. Ir al Menu");
            sb.AppendLine("Elegir una Opcion");

            Console.WriteLine(sb.ToString());
        }

        public void AddContact()
        {
            Clear();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Nuevo Contacto");

            Contact contact = new Contact();
            Console.WriteLine("Name");
            contact.Name = Console.ReadLine();
            Console.WriteLine("Phone Number");
            contact.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Email");
            contact.Email = Console.ReadLine();

            _agenda.AddContact(contact);
            Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Contacto Agregado "); 
            PressToContinue();
        }

        public void DeleteContact()
        {
            Clear();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Ingrese el nombre del contacto");
            string name = Console.ReadLine();

            try
            {
                _agenda.DeleteContact(name);
                Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Contacto {0} eliminado", name);
            }
            catch (Exception e)
            {
                Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("El contacto {0} no existe", name);
            }


            PressToContinue();
        }

        public void SearchByName()
        {
            Clear();

            Console.WriteLine("Buscar Por nombre");
            Console.WriteLine("Ingrese el Nombre");
            string name = Console.ReadLine();
            Clear();

            Contact contact = _agenda.SearchByName(name);
            if (contact != null)
            {
                Console.WriteLine("Contacto es \n" + contact);
            }
            else
            {
                Console.WriteLine("No se encontro el contacto");
            }

            PressToContinue();
        }

        private static void Clear()
        {
            Console.Clear();
        }

        private static void PressToContinue()
        {
            Console.WriteLine("Presione para continuar");
            Console.ReadKey();
        }
    }
}
