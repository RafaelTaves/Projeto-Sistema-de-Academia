class Professor
{
    public Professor(string nome, string cpf, string telefone, string email)
    {
        Nome = nome;
        Cpf = cpf;
        Telefone = telefone;
        Email = email;
    }

    public string Nome { get; }
    public string Cpf { get; }
    public string Telefone { get; }
    public string Email { get; }
}