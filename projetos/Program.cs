using System;
using System.Collections.Generic;
using System.IO;

namespace ContactApp
{
    class Program
    {
        static List<Contact> contacts = new List<Contact>();
        static string filePath = "contacts.txt";

        static void Main(string[] args)
        {
            LoadContacts();
            int choice;

            do
            {
                Console.WriteLine("Gerenciamento de Contatos");
                Console.WriteLine("1. Adicionar Contato");
                Console.WriteLine("2. Remover Contato");
                Console.WriteLine("3. Atualizar Contato");
                Console.WriteLine("4. Listar Contatos");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");
                
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddContact();
                        break;
                    case 2:
                        RemoveContact();
                        break;
                    case 3:
                        UpdateContact();
                        break;
                    case 4:
                        ListContacts();
                        break;
                    case 5:
                        SaveContacts();
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
                Console.WriteLine();

            } while (choice != 5);
        }

        static void AddContact()
        {
            Console.Write("Digite o nome: ");
            string name = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string phone = Console.ReadLine();

            Console.Write("Digite o email: ");
            string email = Console.ReadLine();

            contacts.Add(new Contact { Name = name, Phone = phone, Email = email });
            Console.WriteLine("Contato adicionado com sucesso!");
        }

        static void RemoveContact()
        {
            Console.Write("Digite o nome do contato a ser removido: ");
            string name = Console.ReadLine();

            Contact contactToRemove = contacts.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (contactToRemove != null)
            {
                contacts.Remove(contactToRemove);
                Console.WriteLine("Contato removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Contato não encontrado.");
            }
        }

        static void UpdateContact()
        {
            Console.Write("Digite o nome do contato a ser atualizado: ");
            string name = Console.ReadLine();

            Contact contactToUpdate = contacts.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (contactToUpdate != null)
            {
                Console.Write("Digite o novo telefone: ");
                contactToUpdate.Phone = Console.ReadLine();

                Console.Write("Digite o novo email: ");
                contactToUpdate.Email = Console.ReadLine();

                Console.WriteLine("Contato atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Contato não encontrado.");
            }
        }

        static void ListContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("Nenhum contato encontrado.");
            }
            else
            {
                Console.WriteLine("Lista de Contatos:");
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"Nome: {contact.Name}, Telefone: {contact.Phone}, Email: {contact.Email}");
                }
            }
        }

        static void SaveContacts()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var contact in contacts)
                    {
                        writer.WriteLine($"{contact.Name}|{contact.Phone}|{contact.Email}");
                    }
                }
                Console.WriteLine("Contatos salvos com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar contatos: {ex.Message}");
            }
        }

        static void LoadContacts()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var data = line.Split('|');
                            if (data.Length == 3)
                            {
                                contacts.Add(new Contact { Name = data[0], Phone = data[1], Email = data[2] });
                            }
                        }
                    }
                    Console.WriteLine("Contatos carregados com sucesso!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar contatos: {ex.Message}");
            }
        }
    }

    class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
