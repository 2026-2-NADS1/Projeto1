String nome;
int faixa, questaof, acertof, questaom, acertom, questaod, acertod, totalq, tempo, dica;
bool convertTorF;
string linha1, linha2,linha3,linha4,linha5,linha6,linha7,linha8,linha9,linha10;


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











// Relatorio
    Console.WriteLine("===== ARCOR – DESAFIO DAS MARCAS: RESUMO DA PARTIDA =====");
    Console.WriteLine("Jogador: " + nome);

//    
if (faixa==1) {

    Console.WriteLine("Faixa Etária: Até 12 anos");

} else if (faixa==2)
{
    Console.WriteLine("Faixa Etária: 13 a 17 anos");

}else if (faixa==3)
{
    Console.WriteLine("Faixa Etária: 18 a 24 anos");
}else if (faixa==4)
{
    Console.WriteLine("Faixa Etária: 25 a 39 anos");
}else if (faixa==5)
{
    Console.WriteLine("Faixa Etária: 40 anos ou mais");
}else if (faixa==6)
{
    Console.WriteLine("Faixa Etária: Prefiro não informar");
}

//

