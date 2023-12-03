using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Dicionário para armazenar credenciais de usuários (nome de usuário e senha)
        Dictionary<string, string> userCredentials = new Dictionary<string, string>();

        // Dicionário para armazenar informações sobre senhas associadas a sites (site, usuário e senha)
        Dictionary<string, (string, string)> passwordDatabase = new Dictionary<string, (string, string)>();

        // Loop principal do programa
        while (true)
        {
            // Exibição do menu principal
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("\nBoas vindas ao Gerenciador de Senhas\n");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("[1] - Efetuar Login");
            Console.WriteLine("[2] - Realizar Cadastro");
            Console.WriteLine("[3] - Sair");
            Console.WriteLine("--------------------------------------");
            Console.Write("\nInsira uma opção: ");
            string choice = Console.ReadLine();

            // Opção 1: Efetuar Login
            if (choice == "1")
            {
                Console.Write("Digite o seu nome de usuário: ");
                string username = Console.ReadLine();
                Console.Write("Digite a sua senha: ");
                string password = Console.ReadLine();

                // Verificar se as credenciais fornecidas estão corretas
                if (userCredentials.ContainsKey(username) && userCredentials[username] == password)
                {
                    // Loop do menu de gerenciamento de senhas
                    while (true)
                    {
                        Console.WriteLine("\n--------------------------------------");
                        Console.WriteLine("[1] - Adicionar Senha");
                        Console.WriteLine("[2] - Editar Senha");
                        Console.WriteLine("[3] - Remover Senha");
                        Console.WriteLine("[4] - Visualizar senhas");
                        Console.WriteLine("[5] - Voltar");
                        Console.WriteLine("--------------------------------------");
                        Console.Write("\nInsira uma opção: ");
                        string option = Console.ReadLine();

                        // Opção 1: Adicionar Senha
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
                        // Opção 2: Editar Senha
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
                                Console.WriteLine("\n-\n[Site editado com sucesso!]\n");
                            }
                            else
                            {
                                Console.WriteLine("\n-\n[Site não encontrado!]\n");
                            }
                        }
                        // Opção 3: Remover Senha
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
                                Console.WriteLine("\n-\n[Site não encontrado!]\n");
                            }
                        }
                        // Opção 4: Visualizar senhas
                        else if (option == "4")
                        {
                            Console.WriteLine("-\n\nSenhas Cadastradas:");
                            foreach (var entry in passwordDatabase)
                            {
                                Console.WriteLine($"# Site: {entry.Key}, Usuário: {entry.Value.Item1}, Senha: {entry.Value.Item2}");
                            }
                        }
                        // Opção 5: Voltar
                        else if (option == "5")
                        {
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\n-\n[Credenciais Inválidas!]\n\n\n");
                }
            }
            // Opção 2: Realizar Cadastro
            else if (choice == "2")
            {
                Console.Write("Digite um novo nome de usuário: ");
                string newUser = Console.ReadLine();
                Console.Write("Digite uma nova senha: ");
                string newPassword = Console.ReadLine();

                // Adicionar as novas credenciais ao dicionário de usuários
                userCredentials[newUser] = newPassword;
            }
            // Opção 3: Sair do programa
            else if (choice == "3")
            {
                break;
            }
        }
    }
}
