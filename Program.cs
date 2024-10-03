using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ScreenSound
{
    class Program
    {
        static void Main(string[] args)
        {
            Banda queen = new Banda();
            queen.Nome = "Queen";

            Album albumDoQueen = new Album();
            albumDoQueen.Nome = "A night at the opera";

            Musica musica1 = new Musica( queen);
            musica1.Nome = "Love of my life";
            musica1.Duracao = 273;
            musica1.Disponivel = true;

            Musica musica2 = new Musica(queen);
            musica2.Nome = "Bohemian Rhapsody";
            musica2.Duracao = 354;
            musica2.Disponivel = true;

            //Musica musica3 = new Musica();
            //musica3.Nome = "Vertigo";
            //musica3.Duracao = 393;
            //musica3.Disponivel = true;

            albumDoQueen.AdicionarMusica(musica1);
            albumDoQueen.AdicionarMusica(musica2);

            albumDoQueen.ExibirMusicasDoAlbum();


            queen.AdicionarAlbum(albumDoQueen);
            queen.ExibirDiscografia();

            string mensagemBoasVindas = "Boas vindas ao Screen Sound!";
            //List<string> ListaDasBandas = new List<string> { "U2", "Bon Jovi", "Calypso"}; 

            Dictionary<string, List<int>> bandasRegistraddas = new Dictionary<string, List<int>>();
            bandasRegistraddas.Add("U2", new List<int> { 10, 8, 5 });
            bandasRegistraddas.Add("Bon Jovi", new List<int>());


            void ExibirLogo()
            {
                Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
                                    ");

                Console.WriteLine(mensagemBoasVindas);

                Console.WriteLine("");
            };

            void ExibirOpcesDoMenu()
            {
                ExibirLogo();

                //  \n para pular uma linha
                Console.WriteLine("\nDigite 1 para registrar uma banda");
                Console.WriteLine("Digite 2 para mostrar todas as bandas");
                Console.WriteLine("Digite 3 para avaliar uma banda");
                Console.WriteLine("Digite 4 para exibir a média de uma banda");
                Console.WriteLine("Digite -1 para sair");

                Console.Write("\nDigite uma opção: ");

                string opcaoSelecionada = Console.ReadLine()!;

                int opcaoEscolhida = int.Parse(opcaoSelecionada);

                switch (opcaoEscolhida)
                {
                    case 1:
                        RegistrarBanda();
                        break;
                    case 2:
                        ExibirBandasRegistradas();
                        break;
                    case 3:
                        AvaliarUmaBanda();
                        break;
                    case 4:
                        ExibirMedia();
                        break;
                    case -1:
                        Console.WriteLine("bye - bye :)");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            };

            void ExibirTitulosDasOpções(string titulo)
            {
                int qtdeLetras = titulo.Length;
                string asteriscos = string.Empty.PadLeft(qtdeLetras, '*');

                Console.WriteLine(asteriscos);
                Console.WriteLine(titulo);
                Console.WriteLine(asteriscos + "\n");
            }

            void RegistrarBanda()
            {
                ExibirTitulosDasOpções("Registro de Bandas");

                Console.WriteLine("Digite o nome da banda:");

                string nomeBanda = Console.ReadLine()!;

                bandasRegistraddas.Add(nomeBanda, new List<int>());

                Console.WriteLine($"\nA banda {nomeBanda} foi registrada com sucesso");

                Thread.Sleep(2000);
                Console.Clear();

                ExibirOpcesDoMenu();
            };

            void ExibirBandasRegistradas()
            {
                ExibirTitulosDasOpções("Exibindo todas as bandas registradas");

                foreach (string banda in bandasRegistraddas.Keys)
                {
                    Console.WriteLine($"Banda: {banda}");
                }

                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
                ExibirOpcesDoMenu();

            };

            void AvaliarUmaBanda()
            {
                //digita qual banda deseja avaliar
                //se a banda exsistir no dicionario -> atribuir uma nota
                //se não volta ao menu principal

                Console.Clear();
                ExibirTitulosDasOpções("Avaliar Banda");
                Console.Write("Digite o nome da banda que deseja avaliar:");
                string nomeDaBanda = Console.ReadLine()!;

                if (bandasRegistraddas.ContainsKey(nomeDaBanda))
                {
                    Console.WriteLine($"Qual  a nota que a banda {nomeDaBanda} merece:");
                    int nota = int.Parse(Console.ReadLine()!);

                    //atribuindo a nota para a banda
                    bandasRegistraddas[nomeDaBanda].Add(nota);

                    Console.WriteLine($"\nA nota {nota} foi registrada com sucesso.");
                    Thread.Sleep(4000);
                    Console.Clear();
                    ExibirOpcesDoMenu();
                }
                else
                {
                    Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada");
                    Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                    Console.ReadKey();
                    Console.Clear();
                    ExibirOpcesDoMenu();
                }

            }

            void ExibirMedia()
            {
                Console.Clear();

                //titulo
                ExibirTitulosDasOpções("Exibir média da banda");

                //digital a  banda
                Console.Write("Digite o nome da banda que deseja ver sa média:");

                string nomeDaBanda = Console.ReadLine()!;

                //verifica se ea band aesta na lista
                if (bandasRegistraddas.ContainsKey(nomeDaBanda))
                {
                    //mostrar a media da banda
                    List<int> notasBands = bandasRegistraddas[nomeDaBanda];
                    Console.WriteLine($"\nA média da banda {nomeDaBanda} é {notasBands.Average()}");
                    Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                    Console.ReadKey();
                    Console.Clear();
                    ExibirOpcesDoMenu();
                }
                else
                {
                    Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada");
                    Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                    Console.ReadKey();
                    Console.Clear();
                    ExibirOpcesDoMenu();
                }
            }

        }

    }
}
