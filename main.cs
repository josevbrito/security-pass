using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, string> userCredentials = new Dictionary<string, string>();
        Dictionary<string, (string, string)> passwordDatabase = new Dictionary<string, (string, string)>();

        while (true)
        {
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Criar novo login");
            Console.WriteLine("3. Sair");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Digite o nome de usuário: ");
                string username = Console.ReadLine();
                Console.Write("Digite a senha: ");
                string password = Console.ReadLine();

                if (userCredentials.ContainsKey(username) && userCredentials[username] == password)
                {
                    while (true)
                    {
                        Console.WriteLine("1. Adicionar site");
                        Console.WriteLine("2. Editar site");
                        Console.WriteLine("3. Remover site");
                        Console.WriteLine("4. Visualizar senhas");
                        Console.WriteLine("5. Voltar");
                        string option = Console.ReadLine();

                        if (option == "1")
                        {
                            Console.Write("Nome do site: ");
                            string site = Console.ReadLine();
                            Console.Write("Nome de usuário: ");
                            string siteUsername = Console.ReadLine();
                            Console.Write("Senha: ");
                            string sitePassword = Console.ReadLine();
                            passwordDatabase[site] = (siteUsername, sitePassword);
                        }
                        else if (option == "2")
                        {
                            Console.Write("Nome do site a ser editado: ");
                            string siteToEdit = Console.ReadLine();
                            if (passwordDatabase.ContainsKey(siteToEdit))
                            {
                                Console.Write("Novo nome de usuário: ");
                                string newUsername = Console.ReadLine();
                                Console.Write("Nova senha: ");
                                string newPassword = Console.ReadLine();
  
                                // Atualizar o site com as novas informações
                                passwordDatabase[siteToEdit] = (newUsername, newPassword);
                                Console.WriteLine("Site editado com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Site não encontrado.");
                            }
                        }
                        else if (option == "3")
                        {
                            Console.Write("Nome do site a ser removido: ");
                            string siteToRemove = Console.ReadLine();
                            if (passwordDatabase.ContainsKey(siteToRemove))
                            {
                                passwordDatabase.Remove(siteToRemove);
                            }
                            else
                            {
                                Console.WriteLine("Site não encontrado.");
                            }
                        }
                        else if (option == "4")
                        {
                            foreach (var entry in passwordDatabase)
                            {
                                Console.WriteLine($"Site: {entry.Key}, Usuário: {entry.Value.Item1}, Senha: {entry.Value.Item2}");
                            }
                        }
                        else if (option == "5")
                        {
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Credenciais inválidas.");
                }
            }
            else if (choice == "2")
            {
                Console.Write("Digite um novo nome de usuário: ");
                string newUser = Console.ReadLine();
                Console.Write("Digite uma nova senha: ");
                string newPassword = Console.ReadLine();

                userCredentials[newUser] = newPassword;
            }
            else if (choice == "3")
            {
                break;
            }
        }
    }
}
