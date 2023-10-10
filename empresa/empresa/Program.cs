using System;
using System.Collections.Generic;

class Program
{
    static List<Empregado> listaEmpregados = new List<Empregado>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Cadastrar Empregado");
            Console.WriteLine("2. Listar Todos Empregados cadastrados");
            Console.WriteLine("3. Promover um Empregado");
            Console.WriteLine("4. Demitir um Empregado");
            Console.WriteLine("5. Listar salário anual do Empregado");
            Console.WriteLine("6. Sair");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CadastrarEmpregado();
                    break;
                case 2:
                    ListarEmpregados();
                    break;
                case 3:
                    PromoverEmpregado();
                    break;
                case 4:
                    DemitirEmpregado();
                    break;
                case 5:
                    ListarSalarioAnual();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void CadastrarEmpregado()
    {
        Console.WriteLine("Digite o primeiro nome do empregado:");
        string primeiroNome = Console.ReadLine();

        Console.WriteLine("Digite o sobrenome do empregado:");
        string sobrenome = Console.ReadLine();

        Console.WriteLine("Digite a matrícula do empregado:");
        string matricula = Console.ReadLine();

        Console.WriteLine("Digite a idade do empregado:");
        int idade = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite a data de nascimento do empregado (dd/mm/yyyy):");
        DateTime dataNascimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        Console.WriteLine("Digite a data de contratação do empregado (dd/mm/yyyy):");
        DateTime dataContratacao = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        Console.WriteLine("Digite o salário mensal do empregado:");
        double salarioMensal = double.Parse(Console.ReadLine());

        // Verifica se o salário é menor que o salário mínimo
        double salarioMinimo = 1000.0; // Exemplo de salário mínimo
        if (salarioMensal < salarioMinimo)
        {
            salarioMensal = salarioMinimo;
        }

        Empregado empregado = new Empregado(primeiroNome, sobrenome, matricula, idade, dataNascimento, dataContratacao, salarioMensal);
        listaEmpregados.Add(empregado);
        Console.WriteLine("Empregado cadastrado com sucesso!");
    }

    static void ListarEmpregados()
    {
        Console.WriteLine("Lista de Empregados:");
        foreach (var empregado in listaEmpregados)
        {
            Console.WriteLine($"{empregado.PrimeiroNome} {empregado.Sobrenome} - Matrícula: {empregado.Matricula}");
        }
    }

    static void PromoverEmpregado()
    {
        Console.WriteLine("Digite o primeiro nome do empregado a ser promovido:");
        string primeiroNome = Console.ReadLine();

        Console.WriteLine("Digite o sobrenome do empregado a ser promovido:");
        string sobrenome = Console.ReadLine();

        Empregado empregado = EncontrarEmpregado(primeiroNome, sobrenome);

        if (empregado != null)
        {
            empregado.AumentarSalario(0.10); // Aumento de 10%
            Console.WriteLine("Empregado promovido com sucesso!");
        }
        else
        {
            Console.WriteLine("Empregado não encontrado.");
        }
    }

    static void DemitirEmpregado()
    {
        Console.WriteLine("Digite o primeiro nome do empregado a ser demitido:");
        string primeiroNome = Console.ReadLine();

        Console.WriteLine("Digite o sobrenome do empregado a ser demitido:");
        string sobrenome = Console.ReadLine();

        Empregado empregado = EncontrarEmpregado(primeiroNome, sobrenome);

        if (empregado != null)
        {
            listaEmpregados.Remove(empregado);
            Console.WriteLine("Empregado demitido com sucesso!");
        }
        else
        {
            Console.WriteLine("Empregado não encontrado.");
        }
    }

    static void ListarSalarioAnual()
    {
        Console.WriteLine("Digite o primeiro nome do empregado para listar o salário anual:");
        string primeiroNome = Console.ReadLine();

        Console.WriteLine("Digite o sobrenome do empregado para listar o salário anual:");
        string sobrenome = Console.ReadLine();

        Empregado empregado = EncontrarEmpregado(primeiroNome, sobrenome);

        if (empregado != null)
        {
            double salarioAnual = empregado.CalcularSalarioAnual();
            Console.WriteLine($"Salário anual de {empregado.PrimeiroNome} {empregado.Sobrenome}: {salarioAnual:C}");
        }
        else
        {
            Console.WriteLine("Empregado não encontrado.");
        }
    }

    static Empregado EncontrarEmpregado(string primeiroNome, string sobrenome)
    {
        return listaEmpregados.Find(emp => emp.PrimeiroNome.Equals(primeiroNome, StringComparison.OrdinalIgnoreCase)
                                          && emp.Sobrenome.Equals(sobrenome, StringComparison.OrdinalIgnoreCase));
    }
}

class Empregado
{
    public string PrimeiroNome { get; set; }
    public string Sobrenome { get; set; }
    public string Matricula { get; set; }
    public int Idade { get; set; }
    public DateTime DataNascimento { get; set; }
    public DateTime DataContratacao { get; set; }
    public double SalarioMensal { get; set; }

    public Empregado(string primeiroNome, string sobrenome, string matricula, int idade, DateTime dataNascimento, DateTime dataContratacao, double salarioMensal)
    {
        PrimeiroNome = primeiroNome;
        Sobrenome = sobrenome;
        Matricula = matricula;
        Idade = idade;
        DataNascimento = dataNascimento;
        DataContratacao = dataContratacao;
        SalarioMensal = salarioMensal;
    }

    public void AumentarSalario(double percentual)
    {
        SalarioMensal += SalarioMensal * percentual;
    }
    public double CalcularSalarioAnual()
    {
        return SalarioMensal * 12; // Supondo que o salário anual seja calculado multiplicando o salário mensal por 12 meses
    }
}