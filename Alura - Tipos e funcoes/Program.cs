string mensagem = (@"


░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");

string mensagemInicial = ("Bem vindos ao Screen Sound !");

//List<string> listaDasBandas = new List<string> {"U2","Beatles","CPM22" };

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Linkin Park", new List<int> { 10, 8, 6 });
bandasRegistradas.Add("Eagles", new List<int>());

void ExibirLogo ()
{
    Console.WriteLine(mensagem);
    Console.WriteLine(mensagemInicial);
}

void ExibirOpcoes()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;                   
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);         

    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBanda();    
            break;
        case 2: MostrarBandasRegistradas();
         
            break;
        case 3: AvaliarUmaBanda();
            
            break;
        case 4: MediaBanda();
             
            break;
        case -1:
            Console.WriteLine("Bye!");
            break;
        default: Console.WriteLine("Opção inválida");
            break;
    }

}


void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro das bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    //listaDasBandas.Add(nomeDaBanda);
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso");
    Thread.Sleep(4000);
    Console.Clear() ;
    ExibirOpcoes();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas");
  
    /*List----------------------------------------------------
     * for (int i = 0; i < listaDasBandas.Count; i++)
    {
        Console.WriteLine($"Banda: {listaDasBandas[i]}");
    }------------------------------------------------------*/
    
    /* List-----------------------------------------------------
    * foreach(string banda in listaDasBandas)
    {
        Console.WriteLine($"Banda: {banda}");
    }
   -----------------------------------------------------------*/

    foreach (string banda  in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nPressione uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoes();


}

void ExibirTituloDaOpcao(string titulo)
{
    int qtdDeLetras = titulo.Length;
    string asteriscos =string.Empty.PadLeft(qtdDeLetras,'*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarUmaBanda()
{
    //digite qual banda deseja avaliar
    //Se a banda existir no dicionario > Atribuir nota
    //Se não, volta ao menu principal

    Console.Clear();
    ExibirTituloDaOpcao("Avaliar Banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"A nota  {nota} foi registada com sucesso para a banda {nomeDaBanda}");
        Thread.Sleep(2000);
        Console.Clear() ;
        ExibirOpcoes();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada");
        Console.WriteLine("Digite uma tecla para voltar ao Menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoes();
    }
}

void MediaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Media da banda");
    Console.Write("Digite o nome da banda que deseja ver a media: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda)){

        // Obter a lista de notas da banda
        var nota = bandasRegistradas[nomeDaBanda];

        // Calcular a média das notas
        double mediaBanda = nota.Average();

        Console.WriteLine($"A média da banda {nomeDaBanda} é: {mediaBanda}");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoes();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não existe");
        Console.WriteLine("Pressione uma tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoes();
    }
}

ExibirOpcoes();
