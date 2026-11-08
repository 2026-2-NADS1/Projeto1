using System.Diagnostics;
using Spectre.Console;

Console.OutputEncoding = System.Text.Encoding.UTF8; //acentos e caracteres

// ===================== BANCO DE QUESTÕES =====================
string[] faixasEtarias = {
    "Até 12 anos", "13 a 17 anos", "18 a 24 anos",
    "25 a 39 anos", "40 anos ou mais", "Prefiro não informar"
};

string[] enunciados = {
    "Qual é o ritual clássico que todo mundo faz antes de comer uma Tortuguita?",
    "Além do tradicional chocolate ao leite, qual é uma das características visuais mais marcantes da casca da Tortuguita?",
    "Nas campanhas clássicas e icônicas de TV dos anos 90, qual era o bordão irônico e famoso que a Tortuguita soltava?",
    "Historicamente, a Arcor expandiu a marca Tortuguita para além do chocolate individual. Qual destes produtos nunca integrou a família oficial da Tortuguita?",
    "Qual é o recheio mais clássico que costuma vir dentro da cabeça da Tortuguita tradicional ao leite?",
    "Qual destas opções descreve uma parceria de sucesso (collab) que expandiu o alcance da Tortuguita no mercado físico de serviços e alimentação?",
    "Qual é a grande vantagem lúdica de comer o chocolate em partes (patas primeiro, depois cabeça e corpo)?",
    "Se a Tortuguita resolvesse criar um canal de dicas de sobrevivência na internet, qual seria o primeiro lema divertido dela",
    "Onde as crianças e jovens costumam ver a Tortuguita ganhando vida em animações curtas, dancinhas e desafios divertidos hoje em dia"
};

string[] niveis = { "F", "F", "M","D","D","D","M","M","F"};

string[] dicas = {
    "Lembre-se do comercial.",
    "Formato da parte de cima de um casco de tartaruga",
    "Lembre-se do comercial.",
    "O que se come no café da manhã.",
    "Vem de uma flor.",
    "Esta relacionado a comida.",
    "Divertimento.",
    "Tem haver com seu ritual.",
    "Youtube"

};

string[,] alternativas = {
    { "Comer ela inteira de uma vez só sem olhar.", "Cortar a tartaruga ao meio com uma faca e garfo.", "Morder primeiro as patinhas e a cabeça, e deixar o corpinho por último.", "Colocar a Tortuguita de molho no leite quente até derreter" },
    { "Ela tem desenhos de corações e estrelas.", "O casco é quadriculado e simula o formato de um casco real de tartaruga.", "Ela brilha no escuro.", "Ela vem pintada com corante azul e rosa." },
    { "Tô de olho em você!", "Compre batatom!", "Estúpida!", "Derreto na boca, não na mão!" },
    { "Ovos de Páscoa recheados com brindes colecionáveis.", "Biscoitos recheados e wafers.", "Balas de gelatina em formato de tartaruguinhas.", "Cereal matinal crocante de sabor integral com chia" },
    { "Recheio cremoso sabor baunilha (estilo milk-shake)", "Pasta de amendoim crocante.", "Geleia de morango natural!", "Caramelo salgado com pedaços de castanha." },
    { "Parcerias com redes de fast-food e cinemas para sobremesas e combos temáticos.", "Uma linha exclusiva de roupas de inverno em alta-costura parisiense.", "Fabricação de carros elétricos em formato de casco de tartaruga.!", "Uma rede de hotéis all-inclusive na praia inspirada na personagem." },
    { "O chocolate derrete mais devagar na geladeira.", "Transforma o ato de comer em uma brincadeira interativa de faz de conta.", "Impede que o chocolate suje os dedos das mãos.", "Garante que o gosto do recheio suma mais rápido." },
    { "Corra mais rápido que o coelho da Páscoa!", "Nunca confie em quem morde o corpo da tartaruga antes da cabeça!!", "O chocolate derrete mais rápido que o tempo.", "Guarde sempre o casco para construir uma casa." },
    { "Em fitas cassete antigas guardadas no porão.", "Nas redes sociais oficiais da marca, como Instagram e TikTok.", "Em outdoors impressos nas estradas de terra.", "Apenas nos jornais impressos de domingo." }
    };

int[] corretas = { 2, 1, 2, 3, 0, 0, 1, 1, 1};

// ===================== INÍCIO DO JOGO =====================
Console.Clear();
MostrarAbertura();

string nickname = LerNickname();
string faixa = LerFaixaEtaria(faixasEtarias);
Console.Clear();

int totalQuestoes = enunciados.Length;
int[] questoesPorNivel = new int[9];
int[] acertosPorNivel = new int[9];
bool[] usouDica = new bool[totalQuestoes];
bool terminou = false;

Stopwatch cronometro = Stopwatch.StartNew();

for (int i = 0; i < totalQuestoes; i++)
{
    int segundos = (int)cronometro.Elapsed.TotalSeconds;
    int minutos = segundos / 60;
    int segs = segundos % 60;
    AnsiConsole.Write(new Rule($"Questão {i + 1} de {totalQuestoes} | Tempo: {minutos} min {segs} s"));


   // AnsiConsole.Write(new Rule($"Questão {i + 1} de {totalQuestoes}"));

    string[] opcoes = ExtrairAlternativas(alternativas, i);
    int resultado = MostrarQuestao(enunciados[i], opcoes, corretas[i], dicas[i], usouDica, i);

    if (resultado == -1)
    {
        terminou = true;
        break;
    }

    int nivel = IndiceNivel(niveis[i]);
    questoesPorNivel[nivel]++;

    if (resultado == 1)
    {
        acertosPorNivel[nivel] = acertosPorNivel[nivel]+1;
        AnsiConsole.MarkupLine("[green]Você acertou![/]");
    
    }
    else
    {
        AnsiConsole.MarkupLine("[red]Você errou.[/] Resposta certa: " + Markup.Escape(opcoes[corretas[i]]));
     
    }
   
}


cronometro.Stop();

if (terminou)
{
    AnsiConsole.MarkupLine("[yellow]Quiz encerrado pelo jogador. Até a próxima![/]");
}
else
{
    int tempo = (int)cronometro.Elapsed.TotalSeconds;
    int dicasUsadas = ContarDicas(usouDica);
    MostrarRelatorio(nickname, faixa, questoesPorNivel, acertosPorNivel, dicasUsadas, tempo);
}

for (int i = 0; i < enunciados.Length; i++)
{
    string[] opcoes = ExtrairAlternativas(alternativas, i);
    string nivel = niveis[i];
    string pergunta = Markup.Escape(enunciados[i]);
    string respCorreta = Markup.Escape(opcoes[corretas[i]]);
    AnsiConsole.MarkupLine($"[green]{nivel}[/] {pergunta} -> {respCorreta}");


}

// ===================== FUNÇÕES =====================

static void MostrarAbertura()
{
  
    AnsiConsole.Write(new FigletText("                Desafio da Tortuguita").Color(Color.SandyBrown));
    AnsiConsole.MarkupLine("[yellow]Bem-vindo ao nosso Quiz![/]");
    AnsiConsole.MarkupLine("Use as setas para escolher a resposta e tecle Enter.");
    AnsiConsole.MarkupLine("Cada dica usada custa 5 pontos. Escolha TERMINAR para sair a qualquer momento.");
    Console.WriteLine();
}

static string LerNickname()
{
    return AnsiConsole.Ask<string>("Digite seu [green]Nome[/]:");
}

static string LerFaixaEtaria(string[] faixas)
{
    SelectionPrompt<string> prompt = new SelectionPrompt<string>();
    prompt.Title("Escolha sua [green]faixa etária[/]:");
    prompt.AddChoices(faixas);
    return AnsiConsole.Prompt(prompt);
}

static string[] ExtrairAlternativas(string[,] alternativas, int linha)
{
    int quantidade = alternativas.GetLength(1);
    string[] opcoes = new string[quantidade];
    for (int j = 0; j < quantidade; j++)
    {
        opcoes[j] = alternativas[linha, j];
    }
    return opcoes;
}

static int MostrarQuestao(string enunciado, string[] opcoes, int correta, string dica, bool[] usouDica, int indice)
{
    SelectionPrompt<string> prompt = new SelectionPrompt<string>();
    prompt.Title(enunciado);
    prompt.AddChoices(opcoes);
    prompt.AddChoices("MOSTRAR DICA", "TERMINAR");

    string escolha = AnsiConsole.Prompt(prompt);

    while (escolha == "MOSTRAR DICA")
    {
        usouDica[indice] = true;
        AnsiConsole.Status().Start("Buscando a dica...", ctx =>
        {
            Thread.Sleep(1500);
        });
        AnsiConsole.MarkupLine("[yellow]Dica:[/] " + Markup.Escape(dica));
        escolha = AnsiConsole.Prompt(prompt);
    }

    if (escolha == "TERMINAR")
    {
        return -1;
    }
    if (escolha == opcoes[correta])
    {
        return 1;
    }
    return 0;

}

static int IndiceNivel(string nivel)
{
    if (nivel == "F")
    {
        return 0;
    }
    else if (nivel == "M")
    {
        return 1;
    }
    return 2;
}

static int ContarDicas(bool[] usouDica)
{
    int total = 0;
    for (int i = 0; i < usouDica.Length; i++)
    {
        if (usouDica[i])
        {
            total++;
        }
    }
    return total;
}

static double Percentual(int acertos, int questoes)
{
    return acertos * 100.0 / questoes;
}

static int CalcularPontuacao(int[] acertosPorNivel, int dicas)
{
    int[] pesos = { 10, 20, 30 };
    int pontos = 0;
    for (int n = 0; n < 3; n++)
    {
        pontos = pontos + (acertosPorNivel[n] * pesos[n]);
    }
    pontos = pontos - dicas * 5;
    if (pontos < 0)
    {
        pontos = 0;
    }
    return pontos;
}

static int CalcularPontuacaoMaxima(int[] questoesPorNivel)
{
    int[] pesos = { 10, 20, 30 };
    int maximo = 0;
    for (int n = 0; n < 3; n++)
    {
        maximo = maximo + questoesPorNivel[n] * pesos[n];
    }
    return maximo;
}

static string Classificar(double percentual)
{
    if (percentual >= 90)
    {
        return "Mestre das Marcas";
    }
    else if (percentual >= 70)
    {
        return "Conhecedor de Marcas";
    }
    else if (percentual >= 50)
    {
        return "Aprendiz";
    }
    return "Iniciante";
}

static string GerarBarra(int acertos)
{
    string barra = "";
    for (int i = 0; i < acertos; i++)
    {
        barra = barra + "*";
    }
    return barra;
}

static string DefinirRitmo(double mediaPorQuestao, int segundos, int totalQuestoes)
{
    // DESAFIO A (opcional): devolva "Rápido" (até 10 s), "Normal" (até 20 s) ou "Pausado" (acima de 20 s), com as mesmas regras da Entrega 1.
    
    mediaPorQuestao = segundos/totalQuestoes;

    if (mediaPorQuestao <= 10) {
        return "Rápido";
    } else if (mediaPorQuestao <= 20) {
        return "Normal";
    } else {
        return "Pausado";
    };

}

static string MelhorNivel(int[] questoesPorNivel, int[] acertosPorNivel, string[] nomesNiveis)
{
    // DESAFIO B (opcional): percorra os 3 níveis com um for, ignore os níveis, não jogados e devolva o nome do nível de maior percentual.
    // Em caso de empate, vence o nível mais difícil. Dica: use a função Percentual e o vetor nomesNiveis.

    double [] perAniveis = new Double[3];
    double check = -1.0;
    int checkposi = 0;
 
    for (int i=0; i < nomesNiveis.Length; i++) {
        perAniveis[i] = ((double)acertosPorNivel[i]/questoesPorNivel[i])*100;

        if (perAniveis[i] >= check) {
            check = perAniveis[i];
            checkposi = i;
         }  

        }
    return nomesNiveis [checkposi];

    
}
static void MostrarRelatorio(string nickname, string faixa, int[] questoesPorNivel, int[] acertosPorNivel, int dicas, int tempo)
{
    Console.Clear(); 
    string[] nomesNiveis = { "Fácil", "Médio", "Difícil" };

    int totalQuestoes = 0;
    int totalAcertos = 0;
    for (int n = 0; n < 3; n++)
    {
        totalQuestoes = totalQuestoes + questoesPorNivel[n];
        totalAcertos = totalAcertos + acertosPorNivel[n];
    }

    AnsiConsole.Status().Start("Calculando sua nota...", ctx =>
    {
        Thread.Sleep(2500); 
        Console.Clear();
    });
    
    double percentualGeral = Percentual(totalAcertos, totalQuestoes);
    int pontos = CalcularPontuacao(acertosPorNivel, dicas);
    int maximo = CalcularPontuacaoMaxima(questoesPorNivel);
    double media = tempo * 1.0 / totalQuestoes;
    
    Console.Clear(); 
    Console.WriteLine();
    AnsiConsole.Write(new Rule(@"[bold blue]ARCOR[/] – [bold yellow] DESAFIO DAS MARCAS: RESUMO DA PARTIDA[/]"));
    AnsiConsole.Write(new Rule($"Jogador:[bold yellow] {nickname}[/]"));
    Console.WriteLine("Faixa etária: " + faixa);
    Console.WriteLine();
    Console.WriteLine("Desempenho por nível:");
    for (int n = 0; n < 3; n++)
    {
        if (questoesPorNivel[n] == 0)
        {
            Console.WriteLine($"{nomesNiveis[n],-8}(0/0)  não jogado");
        }
        else
        {
            double p = Percentual(acertosPorNivel[n], questoesPorNivel[n]);
            Console.WriteLine($"{nomesNiveis[n],-8}({acertosPorNivel[n]}/{questoesPorNivel[n]})  {p,5:F1}%  {GerarBarra(acertosPorNivel[n])}");
        }
    }


    Console.WriteLine();
    Console.WriteLine($"Total: {totalAcertos} acertos e {totalQuestoes - totalAcertos} erros em {totalQuestoes} questões ({percentualGeral:F1}%)");
    Console.WriteLine($"Pontuação: {pontos} de {maximo} pontos possíveis ({pontos * 100.0 / maximo:F1}%)");
    Console.WriteLine($"Dicas usadas: {dicas} (penalidade de {dicas * 5} pontos)");
    Console.WriteLine($"Tempo total: {tempo / 60} min {tempo % 60} s | Média: {media:F1} s por questão");
    Console.WriteLine($"Ritmo: {DefinirRitmo(media, tempo, totalQuestoes)}");
    Console.WriteLine($"Melhor nível: {MelhorNivel(questoesPorNivel, acertosPorNivel, nomesNiveis)}");
    Console.WriteLine($"Classificação: " + Classificar(percentualGeral));
    Console.WriteLine("=========================================================");
}