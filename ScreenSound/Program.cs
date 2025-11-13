using ScreenSound.Banco;
using ScreenSound.Menu;
using ScreenSound.Modelo;


var context = new ScreenSoundContext();
var artistaDAL = new DAL<Artista>(context);
string opcao;
int opcaoMenu;

var opcoes = new Dictionary<int, Menu>()
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
        Console.Clear();

        var _ = int.TryParse(opcao, out opcaoMenu);
        if (opcoes.TryGetValue(opcaoMenu, out Menu? menu))
        {
            menu.Executar(artistaDAL);
        }
        else
        {
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