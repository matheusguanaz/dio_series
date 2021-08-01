using System;
using DIO_Series.Tipo;

namespace DIO_Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario;
            do{
                opcaoUsuario = ObterOpcaoUsuario();

                switch(opcaoUsuario){
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
                        Console.WriteLine("Digite uma opção válida");
                        break;
                } 
            }while (opcaoUsuario != "X");
        }
        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair \n");

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine(repositorio.RetornaPorId(indiceSerie));
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Deletar(indiceSerie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

            string Titulo, Descricao;
            int Ano, novoGenero;
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

            Console.Write("Digite o número equivalente ao gênero da série: ");
            novoGenero = int.Parse(ValidarEntrada(Console.ReadLine(), "o número equivalente ao gênero ","genero"));//int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Digite o ano de estreia da série: ");
            Ano = int.Parse(ValidarEntrada(Console.ReadLine(), "o ano de estreia ","ano"));
            Console.WriteLine();

            Console.Write("Digite o titulo da série: ");
            Titulo = ValidarEntrada(Console.ReadLine(), "o titulo ","titulo");
            Console.WriteLine();

            Console.Write("Digite a descrição da série: ");
            Descricao = ValidarEntrada(Console.ReadLine(), "a descrição ","descricao");
            Console.WriteLine();

            Serie serie = new Serie(id: indiceSerie, 
                                    ano: Ano, 
                                    descricao: Descricao, 
                                    titulo: Titulo,
                                    genero: (Genero)novoGenero);
            
            repositorio.Atualizar(indiceSerie,serie);
        }

        private static void InserirSerie()
        {
            string Titulo, Descricao;
            int Ano, novoGenero;
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

            Console.Write("Digite o número equivalente ao gênero da série: ");
            novoGenero = int.Parse(ValidarEntrada(Console.ReadLine(), "o número equivalente ao gênero ","genero"));//int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Digite o ano de estreia da série: ");
            Ano = int.Parse(ValidarEntrada(Console.ReadLine(), "o ano de estreia ","ano"));
            Console.WriteLine();

            Console.Write("Digite o titulo da série: ");
            Titulo = ValidarEntrada(Console.ReadLine(), "o titulo ","titulo");
            Console.WriteLine();

            Console.Write("Digite a descrição da série: ");
            Descricao = ValidarEntrada(Console.ReadLine(), "a descrição ","descricao");
            Console.WriteLine();

            Serie serie = new Serie(id: repositorio.ProximoId(), 
                                    ano: Ano, 
                                    descricao: Descricao, 
                                    titulo: Titulo,
                                    genero: (Genero)novoGenero);
            
            repositorio.Insere(serie);

        }

        private static string ValidarEntrada(string entrada, string texto, string atributo)
        {
            bool valido = false;
            string resposta ="";
            while(!valido)
            {
                switch(atributo)
                {
                    case "ano":
                        if(int.TryParse(entrada, out int ano))
                        {
                            resposta = $"{ano}";
                            valido = true;
                        }
                        else
                        {
                            valido = false;
                            Console.WriteLine("Insira um valor válido");
                        }
                        break;
                    case "descricao":
                        if(!string.IsNullOrEmpty(entrada))
                            {
                                resposta = entrada;
                                valido = true;
                            }
                            else
                            {
                                valido = false;
                                Console.WriteLine("Insira um valor válido");
                            }
                        break;
                    case "titulo":
                        if(!string.IsNullOrEmpty(entrada))
                            {
                                resposta = entrada;
                                valido = true;
                            }
                            else
                            {
                                valido = false;
                                Console.WriteLine("Insira um valor válido");
                            }
                        break;
                    case "genero":
                        if(int.TryParse(entrada, out int genero))
                            {
                                resposta = $"{genero}";
                                valido = true;
                            }
                            else
                            {
                                valido = false;
                                Console.WriteLine("Insira um valor válido");
                            }
                        break;
                    default:
                        throw new ArgumentException("atributo de série desconhecido");
                    
                }
                if(!valido)
                {
                    Console.Write($"Digite {texto} da série: ");
                    entrada = Console.ReadLine();
                }
                
            }
            return resposta;
        }

        

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
                Console.WriteLine("Não há séries adicionadas");
            else
            {
                foreach(var serie in lista){
                    var excluido = serie.retornaExcluido();
                    Console.WriteLine($"ID: {serie.retornaId()} --- {serie.retornaTitulo()}  {(excluido ? "*Excluido*":"")}");
                }
            }

        }
    }
}
