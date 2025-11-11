using ScreenSound.Banco;
using ScreenSound.Menu;
using ScreenSound.Modelo;

try
{
    var artistaDAL = new ArtistaDAL();
    //artistaDAL.Adicionar(new Artista("Link Park", "Bio Link Park"));
    //var artista = artistaDAL.BuscarArtista(2);
    //artistaDAL.Atualizar(new("Evanescence", "Bio Evanescence") { Id = 1, FotoPerfil = "Foto do Perfil" });
    //artistaDAL.Deletar(artista);
    var listaArtista = artistaDAL.Listar();

    foreach( var art in listaArtista)
    {
        Console.WriteLine(art);
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.ToString());
}

return;

var artistas = new List<Artista>();
string opcao;
int opcaoMenu;

Dictionary<int, Menu> opcoes = new()
{
    { 1, new MenuRegistrarArtista() },
    { 2, new MenuRegistrarMusica() },
    { 3, new MenuMostrarArtistas() },
    { 4, new MenuMostrarMusicas() },
    { -1, new MenuSair() },
};

ExibirOpcoesDoMenu();

void ExibirOpcoesDoMenu()
{
    do
    {
        ExibirLogo();

        Console.WriteLine("1: Registrar um artista;");
        Console.WriteLine("2: Registrar a música de um artista;");
        Console.WriteLine("3: Exibir todos os artista");
        Console.WriteLine("4: Exibir todas as músicas de um artista");
        Console.WriteLine("-1: Sair");

        Console.Write("\nDigite uma opção: ");
        opcao = Console.ReadLine()!;

        var _ = int.TryParse(opcao, out opcaoMenu);
        if (opcoes.TryGetValue(opcaoMenu, out Menu? menu))
        {
            menu.Executar(artistas);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Opção inválida");
            Console.ReadKey();
            Console.Clear();
        }
    }while(opcaoMenu != -1);
}

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
    Console.WriteLine("Boas vindas ao Screen Sound 3.0!\n");
}