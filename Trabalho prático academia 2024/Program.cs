using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;

string mensagemBoasVindas = "Boas vindas ao Sistema Interno da Academia";
List<Aluno> alunos;
List<Professor> professores;
List<Turma> turmas;
const string CaminhoArquivoAlunos = "alunos.json";
const string CaminhoArquivoProfessores = "professores.json";
const string CaminhoArquivoTurmas = "turmas.json";
professores = CarregarDados<Professor>(CaminhoArquivoProfessores);
alunos = CarregarDados<Aluno>(CaminhoArquivoAlunos);
turmas = CarregarDados<Turma>(CaminhoArquivoTurmas);


/*void LimparDados()
{
    File.WriteAllText(CaminhoArquivoAlunos, "[]");
    File.WriteAllText(CaminhoArquivoProfessores, "[]");
    File.WriteAllText(CaminhoArquivoTurmas, "[]");
    Turma.ResetarContador();
}
LimparDados();*/


void ExibirLogo()


{
    Console.WriteLine(@"
░██████╗██╗░██████╗████████╗███████╗███╗░░░███╗░█████╗░
██╔════╝██║██╔════╝╚══██╔══╝██╔════╝████╗░████║██╔══██╗
╚█████╗░██║╚█████╗░░░░██║░░░█████╗░░██╔████╔██║███████║
░╚═══██╗██║░╚═══██╗░░░██║░░░██╔══╝░░██║╚██╔╝██║██╔══██║
██████╔╝██║██████╔╝░░░██║░░░███████╗██║░╚═╝░██║██║░░██║
╚═════╝░╚═╝╚═════╝░░░░╚═╝░░░╚══════╝╚═╝░░░░░╚═╝╚═╝░░╚═╝

░█████╗░░█████╗░░█████╗░██████╗░███████╗███╗░░░███╗██╗░█████╗░
██╔══██╗██╔══██╗██╔══██╗██╔══██╗██╔════╝████╗░████║██║██╔══██╗
███████║██║░░╚═╝███████║██║░░██║█████╗░░██╔████╔██║██║███████║
██╔══██║██║░░██╗██╔══██║██║░░██║██╔══╝░░██║╚██╔╝██║██║██╔══██║
██║░░██║╚█████╔╝██║░░██║██████╔╝███████╗██║░╚═╝░██║██║██║░░██║
╚═╝░░╚═╝░╚════╝░╚═╝░░╚═╝╚═════╝░╚══════╝╚═╝░░░░░╚═╝╚═╝╚═╝░░╚═╝");
    Console.WriteLine($"\n{mensagemBoasVindas}");
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos + "");
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void ExibirMenu(List<Turma> turmas)

{
    ExibirLogo();

    Console.WriteLine("\nDigite 1 para cadastrar um aluno.");
    Console.WriteLine("Digite 2 para cadastrar um professor");
    Console.WriteLine("Digite 3 para cadastrar uma turma");
    Console.WriteLine("Digite 4 para inscrever um aluno em uma turma");
    Console.WriteLine("Digite 5 para cancelar a inscrição de um aluno em uma turma");
    Console.WriteLine("Digite 6 para fechar turmas");
    Console.WriteLine("Digite 7 para Listar turmas");
    Console.WriteLine("Digite 8 para listar alunos cadastrados");
    Console.WriteLine("Digite -1 para fechar o programa");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            CadastroAluno();
            break;
        case 2:
            CadastroProfessor();    
            break;
        case 3:
            CadastroTurma();
            break;
        case 4:
            InscreverAluno();
            break;
        case 5:
            RemoverAluno();
            break;
        case 6:
            FecharTurma(turmas);
            break;
        case 7:
            ListarTurmas();
            break;
        case 8:
            ListarAlunos();
            break;
        case -1:
            FecharPrograma();
            break;
        default:
            Console.Clear();
            Console.WriteLine("Opção escolhida invalida");
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ExibirMenu(turmas);
            break;

    }
}

void CadastroAluno()
{
    Console.Clear();
    ExibirTituloDaOpcao("Cadastro de alunos");

    Console.Write("Nome: ");
    string nome = Console.ReadLine()!;
    Console.Write("CPF: ");
    string cpf = Console.ReadLine()!;
    Console.Write("Telefone: ");
    string telefone = Console.ReadLine()!;
    Console.Write("Email: ");
    string email = Console.ReadLine()!;

    Aluno aluno = new(nome, cpf, telefone, email);
    alunos.Add(aluno);
    SalvarDados(alunos, "alunos.json");

    Console.WriteLine($"\nAluno {aluno.Nome} cadastrado com sucesso!");
    FimDeFuncao("Aluno");
}

void CadastroProfessor()
{
    Console.Clear();
    ExibirTituloDaOpcao("Cadastro de professores");

    Console.Write("Nome: ");
    string nome = Console.ReadLine()!;
    Console.Write("CPF: ");
    string cpf = Console.ReadLine()!;
    Console.Write("Telefone: ");
    string telefone = Console.ReadLine()!;
    Console.Write("Email: ");
    string email = Console.ReadLine()!;

    Professor professor = new(nome, cpf, telefone, email);
    professores.Add(professor);
    SalvarDados(professores, "professores.json");

    Console.WriteLine($"\nProfessor {professor.Nome} cadastrado com sucesso!");
    FimDeFuncao("Professor");
}

void CadastroTurma()
{
    Console.Clear() ;
    ExibirTituloDaOpcao("Cadastro de turmas.");

    Console.Write("Tipo de Aula: ");
    string tipoDeAula = Console.ReadLine()!;

    Console.Write("Dia da semana (não escrever feira após o nome do dia. Ex: Segunda): ");
    string diaDaSemana = Console.ReadLine()!;

    Console.Write("Horario da Aula. (Ex: 08:10): ");
    string horarioAula = Console.ReadLine()!;

    Console.Write("Cpf do professor: ");
    string professor = Console.ReadLine()!;

    Console.Write("Faixa etária da atividade(Ex: 08-14): ");
    string faixaEtaria = Console.ReadLine()!;

    Console.Write("Mínimo de alunos: ");
    string minAlunos = Console.ReadLine()!;
    int minAlunosConv = int.Parse(minAlunos);

    Console.Write("Máximo de alunos: ");
    string maxAlunos = Console.ReadLine()!;
    int maxAlunosConv = int.Parse(maxAlunos);

    Turma turma = new(horarioAula, diaDaSemana, professor, faixaEtaria, minAlunosConv, maxAlunosConv, tipoDeAula);
    turma.geradorDeId();
    turmas.Add(turma);
    SalvarDados(turmas, "turmas.json");
    Console.WriteLine($"\nTurma de {tipoDeAula}, com Id {turma.Identificador} cadastrada com sucesso!");

    FimDeFuncao("Turma");
}

void InscreverAluno()
{
    Console.Clear();
    ExibirTituloDaOpcao("Inscrever aluno em turma.");

    Console.Write("Cpf do aluno: ");
    string idAluno = Console.ReadLine()!;

    Console.Write("Id da turma: ");
    string idTurma = Console.ReadLine()!;

    Aluno aluno = BuscarAlunoPorCPF(idAluno);
    if (aluno == null)
    {
        Console.WriteLine("Aluno não encontrado");
        return;
    }

    Turma turma = BuscarTurmaPorCodigo(idTurma);
    if(turma == null) {
        Console.WriteLine("Turma não encontrada");
        return;
    }

    turma.AdicionarAluno(aluno);
    Console.WriteLine($"Aluno {aluno.Nome} foi adicionado a turma de {turma.TipoDeAula}");

    FimDeFuncao("InscreverAluno");
}

void RemoverAluno()
{
    Console.Clear();
    ExibirTituloDaOpcao("Remover aluno de turma.");

    Console.Write("Cpf do aluno: ");
    string idAluno = Console.ReadLine()!;

    Console.Write("Id da turma");
    string idTurma = Console.ReadLine()!;

    Aluno aluno = BuscarAlunoPorCPF(idAluno);
    if (aluno == null)
    {
        Console.WriteLine("Aluno não encontrado");
        return;
    }
    Turma turma = BuscarTurmaPorCodigo(idTurma);
    if (turma == null)
    {
        Console.WriteLine("Turma não encontrada");
        return;
    }

    turma.RemoverAluno(aluno);
    Console.WriteLine($"Aluno {aluno.Nome} foi removido da turma de {turma.TipoDeAula}");

    FimDeFuncao("RemoverAluno");
}

void FecharTurma(List<Turma> turmas)
{
    Console.Clear();
    ExibirTituloDaOpcao("Fechar Turmas");

    Console.Write("Digite um número de alunos e fecharemos todas as turmas que possuem um número abaixo do informado ");
    string opcaoEscolhida = Console.ReadLine()!;
    int limiteMinimo = int.Parse(opcaoEscolhida);

    turmas.RemoveAll(turma => turma.QuantidadeDeAlunos() < limiteMinimo);
    Console.WriteLine($"Turmas com menos de {limiteMinimo} alunos foram removidas.");
}

void ListarTurmas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Listando todas as turmas confirmadas");

    foreach(Turma turma in turmas)
    {
        Console.WriteLine($"Turma de {turma.TipoDeAula}\n");
        Console.WriteLine($"Dia: {turma.DiaDaSemana}");
        Console.WriteLine($"Horario: {turma.HorarioAula}");
        Console.WriteLine($"Professor: {turma.Professor}");
        Console.WriteLine("-------------------------------------\n");
    }

    Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
    Console.ReadKey();
    Console.Clear();
    ExibirMenu(turmas);
}

void ListarAlunos()
{
    Console.Clear();
    Console.WriteLine("Lista de Alunos Cadastrados:");
    Console.WriteLine("----------------------------");

    foreach (Aluno aluno in alunos)
    {
        Console.WriteLine($"Nome: {aluno.Nome}");
        Console.WriteLine($"CPF: {aluno.Cpf}");
        Console.WriteLine($"Telefone: {aluno.Telefone}");
        Console.WriteLine($"Email: {aluno.Email}");
        Console.WriteLine("----------------------------");
    }

    Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
    Console.ReadKey();
    Console.Clear();
    ExibirMenu(turmas);
}

void FecharPrograma()
{
    Console.Clear();
    Console.WriteLine("Até Logo");
    Thread.Sleep(2000);
    Environment.Exit(0);
}

void FimDeFuncao(string palavraChave)
{
    Console.WriteLine($"\nDigite 1 para cadastrar outro {palavraChave}.");
    Console.WriteLine("Digite 2 para retornar ao menu principal");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            if(palavraChave == "Professor")
            {
                CadastroProfessor();
            }else if(palavraChave == "Aluno"){
                CadastroAluno();
            } else if(palavraChave == "Turma")
            {
                CadastroTurma();
            } else if (palavraChave == "RemoverAluno")
            {
                RemoverAluno();
            } else if (palavraChave == "InscreverAluno")
            {
                InscreverAluno();
            }
            break;
        case 2:
            Console.Clear();
            ExibirMenu(turmas);
            break;
    }
}

Aluno BuscarAlunoPorCPF(string cpf)
{
    foreach (Aluno aluno in alunos)
    {
        if (aluno.Cpf == cpf)
        {
            return aluno;
        }
    }

    return null; 
}

 Turma BuscarTurmaPorCodigo(string codigo)
{
    foreach (Turma turma in turmas)
    {
        if (turma.Identificador == codigo)
        {
            return turma;
        }
    }

    return null; 
}

List<T> CarregarDados<T>(string caminhoArquivo)
{
    if (!File.Exists(caminhoArquivo))
    {
        return new List<T>();
    }

    string jsonString = File.ReadAllText(caminhoArquivo);
    return JsonSerializer.Deserialize<List<T>>(jsonString) ?? new List<T>();
}

void SalvarDados<T>(List<T> dados, string caminhoArquivo)
{
    string jsonString = JsonSerializer.Serialize(dados, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(caminhoArquivo, jsonString);
}

ExibirMenu(turmas);


