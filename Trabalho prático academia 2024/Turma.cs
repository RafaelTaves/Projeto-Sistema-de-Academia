class Turma
{
    public Turma(string horarioAula, string diaDaSemana, string professor, string faixaEtaria, int minAlunos, int maxAlunos, string tipoDeAula)
    {
        HorarioAula = horarioAula;
        DiaDaSemana = diaDaSemana;
        Professor = professor;
        FaixaEtaria = faixaEtaria;
        MinAlunos = minAlunos;
        MaxAlunos = maxAlunos;
        TipoDeAula = tipoDeAula;
        Alunos = new List<Aluno>();
    }

    public string? Identificador { get; private set; }

    private static int contador = 0;
    private const string arquivoContador = "contadorTurma.txt";
    public string HorarioAula { get; }
    public string TipoDeAula { get; }
    public string DiaDaSemana { get; }
    public string Professor { get; }
    public string FaixaEtaria  { get; }
    public int MinAlunos { get; }
    public int MaxAlunos { get; }

    public List<Aluno> Alunos { get; set; }

    public static void ResetarContador()
    {
        File.WriteAllText(arquivoContador, "0");
    }

    public void geradorDeId()
    {
        TimeSpan horarioDaAulaConv;
        TimeSpan.TryParse(HorarioAula, out horarioDaAulaConv);
        TimeSpan inicioManha = new TimeSpan(8, 0, 0); // 08:00
        TimeSpan fimManha = new TimeSpan(12, 0, 0);   // 12:00
        TimeSpan inicioTarde = new TimeSpan(12, 0, 1); // 12:00:01
        TimeSpan fimTarde = new TimeSpan(18, 0, 0);   // 18:00

        char letraTipoDeAula = TipoDeAula[0];
        contador++;
        char letraPeriodo;

        if (horarioDaAulaConv >= inicioManha && horarioDaAulaConv < fimManha)
        {
            letraPeriodo = 'M';
        }
        else if (horarioDaAulaConv > inicioTarde && horarioDaAulaConv <= fimTarde)
        {
            letraPeriodo = 'T';
        }
        else
        {
            letraPeriodo = 'N';
        }

        Identificador = $"{letraTipoDeAula}{contador}{letraPeriodo}";
        SalvarContador();
    }

    static Turma()
    {
        // Tenta carregar o contador do arquivo
        if (File.Exists(arquivoContador))
        {
            // Lê o conteúdo do arquivo e converte para int
            string conteudo = File.ReadAllText(arquivoContador);
            if (!int.TryParse(conteudo, out contador))
            {
                // Se falhar ao parsear, resetamos o contador
                contador = 0;
            }
        }
        else
        {
            // Se o arquivo não existir, inicia o contador com 0
            contador = 0;
        }
    }

    private static void SalvarContador()
    {
        // Escreve o valor do contador no arquivo
        File.WriteAllText(arquivoContador, contador.ToString());
    }


    public void AdicionarAluno(Aluno aluno)
    {
        Alunos.Add(aluno);
    }

    public void RemoverAluno(Aluno aluno)
    {
        Alunos.Remove(aluno);
    }

    public int QuantidadeDeAlunos()
    {
        return Alunos.Count;
    }
}