using System.Diagnostics;
using System.Reflection.Metadata;
using Spectre.Console;

Console.OutputEncoding = System.Text.Encoding.UTF8; //acentos e caracteres

// ----------------------------------------------------------------- BD --------------------------------------------------------------------------

string [] mJogos = {
    "Tortuguita",
    "Bon o Bon"
};

// Tortuguita
string [] asktortus = {
    "Qual é o ritual clássico que todo mundo faz antes de comer uma Tortuguita?",
    "Além do tradicional chocolate ao leite, qual é uma das características visuais mais marcantes da casca da Tortuguita?",
    "Nas campanhas clássicas e icônicas de TV dos anos 90, qual era o bordão irônico e famoso que a Tortuguita soltava?",
    "Historicamente, a Arcor expandiu a marca Tortuguita para além do chocolate individual. Qual destes produtos nunca integrou a família oficial da Tortuguita?",
    "Qual é o recheio mais clássico que costuma vir dentro da cabeça da Tortuguita tradicional ao leite?",
    "Qual destas opções descreve uma parceria de sucesso (collab) que expandiu o alcance da Tortuguita no mercado físico de serviços e alimentação?",
    "Qual é a grande vantagem lúdica de comer o chocolate em partes (patas primeiro, depois cabeça e corpo)?"
    //"Se a Tortuguita resolvesse criar um canal de dicas de sobrevivência na internet, qual seria o primeiro lema divertido dela",
    //"Onde as crianças e jovens costumam ver a Tortuguita ganhando vida em animações curtas, dancinhas e desafios divertidos hoje em dia"
};

string[,] alttortus = {
    { "Comer ela inteira de uma vez só sem olhar.", "Cortar a tartaruga ao meio com uma faca e garfo.", "Morder primeiro as patinhas e a cabeça, e deixar o corpinho por último.", "Colocar a Tortuguita de molho no leite quente até derreter" },
    { "Ela tem desenhos de corações e estrelas.", "O casco é quadriculado e simula o formato de um casco real de tartaruga.", "Ela brilha no escuro.", "Ela vem pintada com corante azul e rosa." },
    { "Tô de olho em você!", "Compre batatom!", "Estúpida!", "Derreto na boca, não na mão!" },
    { "Ovos de Páscoa recheados com brindes colecionáveis.", "Biscoitos recheados e wafers.", "Balas de gelatina em formato de tartaruguinhas.", "Cereal matinal crocante de sabor integral com chia" },
    { "Recheio cremoso sabor baunilha (estilo milk-shake)", "Pasta de amendoim crocante.", "Geleia de morango natural!", "Caramelo salgado com pedaços de castanha." },
    { "Parcerias com redes de fast-food e cinemas para sobremesas e combos temáticos.", "Uma linha exclusiva de roupas de inverno em alta-costura parisiense.", "Fabricação de carros elétricos em formato de casco de tartaruga.!", "Uma rede de hotéis all-inclusive na praia inspirada na personagem." },
    { "O chocolate derrete mais devagar na geladeira.", "Transforma o ato de comer em uma brincadeira interativa de faz de conta.", "Impede que o chocolate suje os dedos das mãos.", "Garante que o gosto do recheio suma mais rápido." }
   //{ "Corra mais rápido que o coelho da Páscoa!", "Nunca confie em quem morde o corpo da tartaruga antes da cabeça!!", "O chocolate derrete mais rápido que o tempo.", "Guarde sempre o casco para construir uma casa." },
   //{ "Em fitas cassete antigas guardadas no porão.", "Nas redes sociais oficiais da marca, como Instagram e TikTok.", "Em outdoors impressos nas estradas de terra.", "Apenas nos jornais impressos de domingo." }
    };

int[] certortus = { 2, 1, 2, 3, 0, 0, 1};//1, 1 // 2, 1, 2, 3, 0, 0, 1


// Bon o Bon

string[] askbonobons = {
    "Em qual país da América Latina o bombom Bon O Bon foi criado pelo Grupo Arcor no ano de 1984?",
    "Qual é o recheio inconfundível e mais famoso do Bon O Bon clássico?",
    "Qual é o objetivo do famoso \"Día del Bon O Bon\", criado na Argentina no dia 1º de julho?",
    "Em termos de presença internacional, o Bon O Bon é exportado e vendido em aproximadamente quantos países ao redor do mundo?",
    "Além da versão tradicional de chocolate ao leite, qual destas é outra versão super popular do Bon O Bon encontrada nos mercados?",
    "Qual destas categorias de sobremesa já recebeu uma versão licenciada com o sabor do Bon O Bon em diversos países?",
    "Qual é o nome do fundador do Grupo Arcor que esteve por trás da visão de expandir a empresa e criar produtos icônicos como o Bon O Bon?"
    //"Em que década o Grupo Arcor lançou oficialmente o Bon O Bon no mercado, criando um novo marco para os bombons de massa?",
    //"Na Argentina, país de origem da marca, o Bon O Bon inspirou a criação de uma data comemorativa cultural e comercial muito famosa. Que data é essa?",
    //"Qual é o famoso lema emocional associado às campanhas publicitárias do Bon O Bon, especialmente no dia comemorativo da marca?",
    //"Por que a escolha da cor roxa/lilás na embalagem metalizada se tornou uma marca registrada tão forte do Bon O Bon ao longo da história?"
};

string[,] altbonobons = {
     { "Brasil", "Argentina", "Chile", "México" },
    { "Creme de amendoim (crema de maní)", "Geleia de maracujá", "Pasta de menta refrescante", "Doce de leite com coco" },
   { "Proibir a venda de doces por 24 horas.", "Incentivar o hábito de presentear amigos e amores com a frase \"um bombom vale mais do que mil palavras\".", "Fazer uma corrida de atletismo onde quem ganha leva uma caixa de papelão.", "Ensinar receitas de salada nas redes sociais." },
    { "Apenas 2 países", "Cerca de 10 países", "Mais de 60 países", "Em nenhum país fora da Argentina" },
    { "Bon O Bon Branco", "Bon O Bon sabor pimenta mexicana", "Bon O Bon sabor uva", "Bon O Bon sabor bacon" },
     { "Sorvetes e picolés", "Refrigerante de cola gasoso", "Chá quente de saquinho", "Molho de tomate para macarronada" },
     { "Fulvio Arcor Esequiel", "Willy da Silva", "Carlos Eduardo Bon", "Roberto Chocolate" }
     //{ "Década de 1960", "Década de 1970", "Década de 1980", "Década de 1990" },
     //{ "O Dia Mundial do Amendoim Tostado (12 de outubro).", "O Festival do Chocolate Roxo (15 de novembro).", "O \"Día del Bon O Bon\" (1º de julho).", "A Semana da Nostalgia dos Anos 80 (5 de maio)." },
     //{ "\"Abra a boca e feche os olhos!\"", "\"Um bombom vale mais do que mil palavras.\"", "\"O chocolate que derrete no bolso, não na mão.\"", "\"Quem tem um amigo, tem um tesouro de amendoim.\"" },
     //{ "Porque era a única cor de tinta disponível na fábrica na década de 80.", "Porque se destacava fortemente nas gôndolas e caixas de supermercado, criando uma identidade visual única e inconfundível.", "Porque o criador da marca detestava todas as outras cores do arco-íris.", "Porque a cor roxa muda de tom dependendo da temperatura ambiente." }
};

int[] cerbonobons = { 1, 0, 1, 2, 0, 0, 0};// 2, 2, 1, 1//



// ------------------------------------------------------------  Metodos  --------------------------------------------------------------------------

static void InicioTelainicial()
{
  
    AnsiConsole.Write(new FigletText("                Cascos Quiz").Color(Color.SandyBrown));
    AnsiConsole.MarkupLine("[yellow]Bem-vindo ao nosso Quiz![/]");
    AnsiConsole.MarkupLine("Use as setas para escolher a resposta e tecle Enter. Caso acerte mais de 4 questões, [bold yellow] ganhe um chocolate![/]");
    AnsiConsole.MarkupLine("Escolha TERMINAR para sair a qualquer momento.");
    Console.WriteLine();
}

static string DeclacaracaoUsuario()
{
    return AnsiConsole.Ask<string>("Digite seu [green]Nome[/]:");
}

static string EscolhaMododejogo(string[] mJogos)
{
    SelectionPrompt<string> prompt = new SelectionPrompt<string>();
    prompt.Title("Agora, escolha seu modo de jogo:");
    prompt.AddChoices(mJogos);
    return AnsiConsole.Prompt(prompt);
    
}

static void GerarEmote(int pontuacao, string mjogoescolha)
{
    
    if (mjogoescolha == "Tortuguita" && pontuacao > 4 )
    {
        Console.WriteLine( @"[⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀

⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣤⣶⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣦⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣆⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⣀⡤⠤⠲⠒⠻⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⠀⠀⠀⠀⠀
⠀⠀⠀⢀⡴⠋⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⣀⠤⡀
⠀⠀⣴⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⠋⠁⢀⡇
⠀⣾⡜⠀⣰⣿⣿⣦⠀⠀⠀⣰⣾⣷⣦⠀⠀⠀⠀⢹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⢠⠞⠀
⢸⣃⠇⠀⢻⣿⣿⡟⠀⠀⠀⢻⣿⣿⡿⠀⠀⠀⠀⠀⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢏⣼⠋⠀⠀
⢸⡯⠀⠀⠀⠀⣡⣄⠀⢂⠀⣀⣌⠋⠀⠀⠀⠀⠀⠀⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠏⣜⠁⠀⠀⠀
⠈⣧⠄⠀⠀⠀⠙⢿⣷⣶⣾⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠃⠀⢻⠀⠀⠀⠀
⠀⠹⡄⠠⠀⠀⠀⠀⠈⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠟⠉⠀⠀⠀⠘⡇⠀⠀⠀
⠀⠀⠙⢄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠻⠿⠿⠿⠿⠿⠟⠛⠛⠉⢡⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀
⠀⠀⠀⠀⠙⠦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⡶⠿⣦⠀⠀⠀⠀⣀⡼⠃⠀⠀⠀
⠀⠀⠀⠀⠀⠀⡾⠁⠀⠀⠀⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣶⠖⠋⠁⠀⠀⠈⠉⠙⠛⠉⠁⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⠀⠀⢸⡟⠛⠚⠓⠒⠒⠒⣶⣆⠀⠀⠀⠀⠀⠀⠀⢹⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠸⣇⠢⡀⠀⠀⠀⠀⢸⠃⠀⠀⠀⠀⠀⠈⠀⣿⠀⠀⠀⠀⠀⠀⠀⣸⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠈⠙⠒⠒⠔⠒⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⢷⠀⡀⠀⠀⠀⠀⢀⡽⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠑⠒⠒⠒⠒⠚⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
AnsiConsole.MarkupLine($"[bold green]Parabéns, você ganhou um chocolate![/]");

    } else if (mjogoescolha == "Bon o Bon" && pontuacao > 4)
    {
        Console.WriteLine( @"*⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀

⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠤⢒⣉⢲⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⣀⠴⠾⡅⠂⠁⠀⠱⢻⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⣀⡔⠪⠐⠉⢳⡛⣆⠀⣀⠀⣀⠽⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⣀⠔⡋⠴⣝⣆⠀⠀⠀⠁⢹⣷⡔⠊⠔⠳⢿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⣷⡄⠀⠀⠈⠊⢣⡐⣢⢔⡫⢌⢳⡄⠀⠀⠀⢙⡧⠤⢀⣀⡀⠀⠀⠀⠀⠀⠀⠀
⠘⣿⡄⠦⢄⡠⠜⠿⡄⠀⠀⠀⠀⠻⣌⡠⠐⣁⠀⠰⣄⣈⡈⠭⠂⠀⠀⠀⠀⠀
⠀⠈⢿⣶⠁⠈⠉⠃⠹⣆⠒⢂⠄⠊⠙⠛⠲⠈⠲⣴⡞⢫⡀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⢻⣧⡐⠄⠀⡀⡜⠪⢷⣦⣄⣤⣀⠀⢀⠜⠋⠀⠀⣿⣄⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⢹⣷⣔⡡⠴⠻⠶⠋⠏⠓⠛⠙⠧⠎⠀⠀⡠⠂⠀⣿⣦⠀⠀⠀⠀⠀
⠀⠀⠀⠀⢧⣼⣿⣅⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⠊⢀⠔⠈⠈⢻⣧⠀⠀⠀⠀
⠀⠀⠀⠀⠈⠉⢻⣿⣆⠀⠀⠀⠀⠀⠀⠀⣠⠎⡠⢊⠀⠀⠀⠀⠀⠘⢷⡀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠹⣿⣦⠀⠀⠀⠀⢀⢼⡣⢊⠔⠁⠀⠀⠀⠀⠀⠀⠀⢳⡀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣷⡀⠀⡐⡡⠋⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠱⡀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢿⣿⡄⠀⠔⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢻⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠴⠁
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⣿⣆⠀⠀⠀⠀⠀⠀⠀⢠⣤⡲⠖⠊⠁⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣿⣧⠀⠀⠀⣠⣴⡿⠛⠉⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣿⣧⣀⡶⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");

        AnsiConsole.MarkupLine($"[bold green]Parabéns, você ganhou um chocolate![/]");
    } else
    {
        Console.WriteLine();
        Console.WriteLine();
        AnsiConsole.Write(new FigletText("     Obrigado por jogar!").Color(Color.SandyBrown));
    }
   
}



// ------------------------------------------------------------  Quiz --------------------------------------------------------------------------
Console.Clear();

InicioTelainicial();
string nome = DeclacaracaoUsuario();
string mjogoescolha = EscolhaMododejogo(mJogos);
int pontuacao = 0;
int tempo=0;

Console.Clear();
switch (mjogoescolha)
{
    case "Tortuguita":
        Stopwatch cronometro = Stopwatch.StartNew();
        for (int i =0; i < asktortus.Length; i++)
        {

            //cronometro
            int segundos = (int)cronometro.Elapsed.TotalSeconds;
            int minutos = segundos / 60;
            int segs = segundos % 60;
            AnsiConsole.Write(new Rule($"Questão {i + 1} de {asktortus.Length} | Tempo: {minutos} min {segs} s"));

            //perguntas
            SelectionPrompt<string> prompt = new SelectionPrompt<string>();
            prompt.Title(asktortus[i]);
            prompt.AddChoices(alttortus[i,0],alttortus[i,1],alttortus[i,2],alttortus[i,3]);
            prompt.AddChoices("Encerrar partida");
        
            string escolha = AnsiConsole.Prompt(prompt);

              if (escolha == "Encerrar partida")
            {
                Console.Clear();
                AnsiConsole.MarkupLine("[yellow]Quiz encerrado pelo jogador. Obrigado por jogar![/]");

                break;
            }else if (escolha == alttortus[i,certortus[i]] )
            {
                AnsiConsole.MarkupLine("[green]Parabéns. Você acertou![/]");
                pontuacao = pontuacao + 1;
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Você errou.[/] Resposta certa: " + Markup.Escape(alttortus[i,certortus[i]]));
            }
        }

    cronometro.Stop();
    tempo = (int)cronometro.Elapsed.TotalSeconds;
    // Geração de Relatorio
    Console.Clear();
    AnsiConsole.Status().Start("Calculando sua nota...", ctx =>
    {
        Thread.Sleep(2500); 
        Console.Clear();
    });
        
    AnsiConsole.Write(new Rule($"[bold blue] Cascos Quiz [/] - Modo escolhido [bold yellow] {mjogoescolha} - RESUMO DA PARTIDA[/]"));
    AnsiConsole.Write(new Rule($"Jogador:[bold yellow] {nome}[/]"));
    Console.WriteLine();
    Console.WriteLine();
    AnsiConsole.MarkupLine($"[bold yellow]Total[/]: {pontuacao} acertos e {asktortus.Length - pontuacao} erros");
    AnsiConsole.MarkupLine($"[bold yellow]Percentual de acertos[/]: {((double)pontuacao)/asktortus.Length*100:F1}%");
    AnsiConsole.MarkupLine($"[bold yellow]Tempo total[/]: {tempo / 60} min {tempo % 60} s | Média:  {tempo/asktortus.Length} s por questão");
    
    GerarEmote(pontuacao, mjogoescolha);
    break;

    case "Bon o Bon":
        Stopwatch cronometro2 = Stopwatch.StartNew();
        for (int i =0; i < askbonobons.Length; i++)
        {

            //cronometro
            int segundos = (int)cronometro2.Elapsed.TotalSeconds;
            int minutos = segundos / 60;
            int segs = segundos % 60;
            AnsiConsole.Write(new Rule($"Questão {i + 1} de {askbonobons.Length} | Tempo: {minutos} min {segs} s"));

            //perguntas
            SelectionPrompt<string> prompt = new SelectionPrompt<string>();
            prompt.Title(askbonobons[i]);
            prompt.AddChoices(altbonobons[i,0],altbonobons[i,1],altbonobons[i,2],altbonobons[i,3]);
            prompt.AddChoices("Encerrar partida");
        
            string escolha = AnsiConsole.Prompt(prompt);

              if (escolha == "Encerrar partida")
            {
                Console.Clear();
                AnsiConsole.MarkupLine("[yellow]Quiz encerrado pelo jogador. Obrigado por jogar![/]");

                break;
            }else if (escolha == altbonobons[i,cerbonobons[i]] )
            {
                AnsiConsole.MarkupLine("[green]Parabéns. Você acertou![/]");
                pontuacao = pontuacao + 1;
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Você errou.[/] Resposta certa: " + Markup.Escape(alttortus[i,cerbonobons[i]]));
            }
        }

    cronometro2.Stop();
    tempo = (int)cronometro2.Elapsed.TotalSeconds;
    
    // Geração de Relatorio
    Console.Clear();
    AnsiConsole.Status().Start("Calculando sua nota...", ctx =>
    {
        Thread.Sleep(2500); 
        Console.Clear();
    });
        
    AnsiConsole.Write(new Rule($"[bold blue] Cascos Quiz [/] - Modo escolhido [bold yellow] {mjogoescolha} - RESUMO DA PARTIDA[/]"));
    AnsiConsole.Write(new Rule($"Jogador:[bold yellow] {nome}[/]"));
    Console.WriteLine();
    Console.WriteLine();
    AnsiConsole.MarkupLine($"[bold yellow]Total[/]: {pontuacao} acertos e {askbonobons.Length - pontuacao} erros");
    AnsiConsole.MarkupLine($"[bold yellow]Percentual de acertos[/]: {((double)pontuacao/askbonobons.Length)*100:F1}%");
    AnsiConsole.MarkupLine($"[bold yellow]Tempo total[/]: {tempo / 60} min {tempo % 60} s | Média:  {tempo/askbonobons.Length} s por questão");

    GerarEmote(pontuacao, mjogoescolha);
    break;
}



