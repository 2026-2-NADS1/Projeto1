String nome;
int faixa, questaof, acertof, questaom, acertom, questaod, acertod, totalq, tempo, dica;
bool convertTorF;
string linha1, linha2,linha3,linha4,linha5,linha6,linha7,linha8,linha9;


//
Console.WriteLine("Olá, digite seu Nickname:");
nome = Console.ReadLine()!;

//Validacao 1
if (nome == null || nome == "")
{
    Console.WriteLine("Nickname em branco!");
    Environment.Exit(1);

}


//
Console.WriteLine("Digite qual idade enquadra sua faixa etaria: 1. Até 12 anos 2. 13 a 17 anos 3. 18 a 24 anos 4. 25 a 39 anos 5.40 anos ou mais 6. Prefiro não informar");
linha1 = Console.ReadLine()!;

// Validacao 2
convertTorF = int.TryParse(linha1, out faixa);

if (!convertTorF ) {

    Console.WriteLine("ERRO na entrada 2, digite um valor numérico.");
    Environment.Exit(1);


} else if (faixa < 1 || faixa > 6)
{
    Console.WriteLine("ERRO na entrada 2, digite um numero entre 1 a 6.");
    Environment.Exit(1);
}


//Faceis
Console.WriteLine("Quantas questões fáceis foram respondidas?");
linha2 = Console.ReadLine()!;

// Validacao Facil (3)

convertTorF = int.TryParse(linha2, out questaof);

if (!convertTorF) {

    Console.WriteLine("ERRO na entrada 3, digite um valor numérico.");
    Environment.Exit(1);

} else if (questaof < 0)
{
    Console.WriteLine("ERRO na entrada 3, digite um valor positivo.");
    Environment.Exit(1);
}


Console.WriteLine("Quantas acertos nas questões fáceis?");
linha3 = Console.ReadLine()!;

// Validacao Facil (4)
convertTorF = int.TryParse(linha3, out acertof);

if (!convertTorF && acertof >= 0) {

    Console.WriteLine("ERRO na entrada 4, digite um valor numérico");
    Environment.Exit(1);

} else if (acertof < 0) {
        Console.WriteLine("ERRO na entrada 4, digite um valor positivo");
        Environment.Exit(1);
} else if (acertof > questaof) {
        Console.WriteLine("ERRO na entrada 4, digite um número até " + questaof);
        Environment.Exit(1);
}


//Medias
Console.WriteLine("Quantas questões medias foram respondidas?");
linha4 = Console.ReadLine()!;

//Validacao Media (5)
convertTorF = int.TryParse(linha4, out questaom);

if (!convertTorF) {

    Console.WriteLine("ERRO na entrada 5, digite um valor numérico.");
    Environment.Exit(1);
} else if (questaom < 0)
{
    Console.WriteLine("ERRO na entrada 5, digite um valor positivo.");
    Environment.Exit(1);
}

Console.WriteLine("Quantas acertos nas questões médias?");
linha5 = Console.ReadLine()!;

//Validacao Media (6)
convertTorF = int.TryParse(linha5, out acertom);

if (!convertTorF && acertom >= 0) {

    Console.WriteLine("ERRO na entrada 6, digite um valor numérico.");
    Environment.Exit(1);

} else if (acertom < 0) {
        Console.WriteLine("ERRO na entrada 4, digite um valor positivo");
        Environment.Exit(1);
} else if (acertom > questaom)
{
    Console.WriteLine("ERRO na entrada 6, digite um número até " + questaom);
    Environment.Exit(1);
}


//Dificeis
Console.WriteLine("Quantas questões dificeis foram respondidas?");
linha6 = Console.ReadLine()!;

//Validacao Dificil (7)
convertTorF = int.TryParse(linha6, out questaod);

if (!convertTorF) {

    Console.WriteLine("ERRO na entrada 7, digite um valor numérico.");
    Environment.Exit(1);

} else if (questaod < 0)
{
    Console.WriteLine("ERRO na entrada 7, digite um valor positivo.");
    Environment.Exit(1);
}


Console.WriteLine("Quantas acertos nas questões dificeis?");
linha7 = Console.ReadLine()!;

//Validacao Dificil (8)
convertTorF = int.TryParse(linha7, out acertod);

if (!convertTorF) {

    Console.WriteLine("ERRO na entrada 8, digite um valor numérico.");
    Environment.Exit(1);

} else if (acertod < 0) {
        Console.WriteLine("ERRO na entrada 8, digite um valor positivo");
        Environment.Exit(1);
} else if (acertod > questaod)
{
    Console.WriteLine("ERRO na entrada 8, digite um número até " + questaod);
    Environment.Exit(1);
}


// Validacao Total

totalq = questaof+questaom+questaod;
if (totalq <=0) {

    Console.WriteLine("ERRO no total número de questões, realize pelo menos uma questão.");
    Environment.Exit(1);

}


//
Console.WriteLine("Quanto tempo demorou?");
linha8 = Console.ReadLine()!;

//Validacao 9

convertTorF = int.TryParse(linha8, out tempo);

if (!convertTorF) {

    Console.WriteLine("ERRO na entrada 9, digite um valor numérico.");
    Environment.Exit(1);

} else if (tempo < 0) {
        Console.WriteLine("ERRO na entrada 9, digite um valor positivo.");
        Environment.Exit(1);
}


//
Console.WriteLine("Quantas dicas utilizou?");
linha9 = Console.ReadLine()!;

//Validacao 10

convertTorF = int.TryParse(linha9, out dica);

if (!convertTorF) {

    Console.WriteLine("ERRO na entrada 10, digite um valor numérico, positivo e até o número de total de questões");
    Environment.Exit(1);

}else if (dica < 0) {
        Console.WriteLine("ERRO na entrada 9, digite um valor positivo.");
        Environment.Exit(1);
}else if (dica > totalq) {
        Console.WriteLine("ERRO na entrada 9, digite um número de dicas até o total de questões realizadas.");
        Environment.Exit(1);
}

// calculos (matheus)

// 5.1 - acertos
int totalAcertos = acertof + acertom + acertod;
int totalErros = totalq - totalAcertos;
double percentualGeral = totalAcertos * 100.0 / totalq;

double percentualFaceis = 0;
double percentualMedias = 0;
double percentualDificeis = 0;

if (questaof > 0)
{
    percentualFaceis = acertof * 100.0 / questaof;
}

if (questaom > 0)
{
    percentualMedias = acertom * 100.0 / questaom;
}

if (questaod > 0)
{
    percentualDificeis = acertod * 100.0 / questaod;
}

// 5.2 - pontuacao
int penalidadeDicas = dica * 5;
int pontuacao = acertof * 10 + acertom * 20 + acertod * 30 - penalidadeDicas;
if (pontuacao < 0)
{
    pontuacao = 0;
}
int pontuacaoMaxima = questaof * 10 + questaom * 20 + questaod * 30;
double aproveitamentoPontuacao = pontuacao * 100.0 / pontuacaoMaxima;

// 5.3 - tempo
int minutos = tempo / 60;
int segundosrestantes = tempo % 60;
double tempoMedioPorQuestao = tempo * 1.0 / totalq;

// 5.4 - faixa etaria
string faixaetaria = "";
if (faixa == 1)
{
    faixaetaria = "Até 12 anos";
}
else if (faixa == 2)
{
    faixaetaria = "13 a 17 anos";
}
else if (faixa == 3)
{
    faixaetaria = "18 a 24 anos";
}
else if (faixa == 4)
{
    faixaetaria = "25 a 39 anos";
}
else if (faixa == 5)
{
    faixaetaria = "40 anos ou mais";
}
else if (faixa == 6)
{
    faixaetaria = "Prefiro não informar";
}

// 5.5 - classificacao
string classificacao;
if (percentualGeral >= 90)
{
    classificacao = "Mestre das Marcas";
}
else if (percentualGeral >= 70)
{
    classificacao = "Conhecedor de Marcas";
}
else if (percentualGeral >= 50)
{
    classificacao = "Aprendiz";
}
else
{
    classificacao = "Iniciante";
}

// 5.6 - ritmo
string ritmo;
if (tempoMedioPorQuestao <= 10)
{
    ritmo = "Rápido";
}
else if (tempoMedioPorQuestao <= 20)
{
    ritmo = "Normal";
}
else
{
    ritmo = "Pausado";
}

// 5.7 - nivel
string melhorNivel = "";
double melhorPercentual = -1;
if (questaof > 0)
{
    melhorNivel = "Fácil";
    melhorPercentual = percentualFaceis;
}

if (questaom > 0 && percentualMedias >= melhorPercentual)
{
    melhorNivel = "Médio";
    melhorPercentual = percentualMedias;
}
if (questaod > 0 && percentualDificeis >= melhorPercentual)
{
    melhorNivel = "Difícil";
    melhorPercentual = percentualDificeis;
}
// fim dos calculos (matheus)

// Relatorio
    Console.WriteLine("===== ARCOR – DESAFIO DAS MARCAS: RESUMO DA PARTIDA =====");

    Console.WriteLine("Jogador: " + nome);

    Console.WriteLine("Faixa etária: " + faixaetaria);

    Console.WriteLine();

    Console.WriteLine("Desempenho por nível:");
    
if (questaof > 0)
{
    string graficoFaceis = "";
    for (int i = 0; i < acertof; i++)
    {
        graficoFaceis = graficoFaceis + "*";
    }
    Console.WriteLine($"Fácil   ({acertof}/{questaof}) {percentualFaceis:F1}% {graficoFaceis}");
}
else
{
    Console.WriteLine("Fácil   (0/0) não jogado");
}

if (questaom > 0)
{
    string graficoMedias = "";
    for (int i = 0; i < acertom; i++)
    {
        graficoMedias = graficoMedias + "*";
    }
    Console.WriteLine($"Médio   ({acertom}/{questaom}) {percentualMedias:F1}% {graficoMedias}");
}
else
{
    Console.WriteLine("Médio   (0/0) não jogado");
}

if (questaod > 0)
{
    string graficoDificeis = "";
    for (int i = 0; i < acertod; i++)
    {
        graficoDificeis = graficoDificeis + "*";
    }
    Console.WriteLine($"Difícil ({acertod}/{questaod}) {percentualDificeis:F1}% {graficoDificeis}");
}
else
{
    Console.WriteLine("Difícil (0/0) não jogado");
}

    Console.WriteLine();

    Console.WriteLine($"Total: {totalAcertos} acertos e {totalErros} erros em {totalq} questões ({percentualGeral:F1}%)");

    Console.WriteLine($"Pontuação: {pontuacao} de {pontuacaoMaxima} pontos possíveis ({aproveitamentoPontuacao:F1}%)");

    Console.WriteLine($"Dicas usadas: {dica} (penalidade de {penalidadeDicas} pontos)");

    Console.WriteLine($"Tempo total: {minutos} min {segundosrestantes} s | Média: {tempoMedioPorQuestao:F1} s por questão");

    Console.WriteLine("Ritmo: " + ritmo);

    Console.WriteLine("Melhor nível: " + melhorNivel);

    Console.WriteLine("Classificação: " + classificacao);

    Console.WriteLine("========================================================");
//