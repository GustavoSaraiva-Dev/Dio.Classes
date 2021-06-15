using Dio.Series.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dio.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string escolhaUsuario = ObterOpcaoUsuario();
            while (escolhaUsuario.ToUpper() != "X")
            {
                switch (escolhaUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        break;
                }

                escolhaUsuario = ObterOpcaoUsuario();
            }
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            List<Serie> lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada!");
                return;
            }

            foreach (Serie serie in lista)
            {
                Console.WriteLine($"#ID: {serie.RetornaId()}: - {serie.RetornaTitulo()}, Excluído: {serie.RetornaExcluido()}");
            }
        }

        private static Serie Persistencia(int acao, int? indexSerie = null)
        {
            foreach (int genero in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($" {genero} - {Enum.GetName(typeof(Genero), genero)}");
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            Genero entradaGenero = (Genero)int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            return new Serie(id: acao == 1 ? repositorio.proximoId() : (int)indexSerie, genero: entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);


        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");
            repositorio.Inserir(Persistencia(acao: 1));
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Deseja visualizar a lista de séries antes de editar?  -  [1 - Sim] [2 - Não]");
            int escolhaUsuario = int.Parse(Console.ReadLine());

            if (escolhaUsuario == 1)
                ListarSeries();


            Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            repositorio.Alterar(idSerie, Persistencia(acao: 2, idSerie));
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(idSerie);
        }
        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            Console.WriteLine(repositorio.RetonaPorId(idSerie));
        }



        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries ao seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;

        }
    }
}
