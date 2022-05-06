 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica
{
    
    public class Program
    {
        static Control control = new Control(new Agenda());
        static void Main(string[] args)
        {

            string choice = "";

            do
            {
               Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine("Agenda de contactos");
                PrintMenu();
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        control.SeeContacts();
                        break;
                    case "2":
                        control.AddContact();
                        break;
                    case "3":
                        control.DeleteContact();
                        break;
                    case "4":
                        control.SearchByName();
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("Opcion no Valida");
                        break;
                }
            } while (choice != "5");

        }

        static void PrintMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("1. Ver los contacto");
            sb.AppendLine("2. Nuevo Contacto");
            sb.AppendLine("3. Eliminar  contacto");
            sb.AppendLine("4. Buscar por nombre");
            sb.AppendLine("5. Exit");
            sb.AppendLine("Seleccione una opcion: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(sb);
        }
    }
}
