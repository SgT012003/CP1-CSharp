namespace CheckPoint
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Adicional (verifique ao projeto de teste para visualizar os testes unitarios).
            Console.WriteLine("=== CHECKPOINT 1 - FUNDAMENTOS C# - Turma  3ESPY ===\n");

            // 1.
            Console.WriteLine("1. Testando DemonstrarTiposDados...");
            Console.WriteLine(Exercises.DemonstrarTiposDados());

            // 2.
            Console.WriteLine("\n2. Testando CalculadoraBasica (SWITCH)...");
            Console.WriteLine(Exercises.CalculadoraBasica(10, 5, '+'));

            // 3.
            Console.WriteLine("\n3. Testando ValidarIdade (IF/ELSE)...");
            Console.WriteLine(Exercises.ValidarIdade(25));

            // 4.
            Console.WriteLine("\n4. Testando ConverterString...");
            Console.WriteLine(Exercises.ConverterString("123", "int"));

            // 5.
            Console.WriteLine("\n5. Testando ClassificarNota (SWITCH)...");
            Console.WriteLine(Exercises.ClassificarNota(8.5));

            // 6.
            Console.WriteLine("\n6. Testando GerarTabuada (FOR)...");
            Console.WriteLine(Exercises.GerarTabuada(5));

            // 7.
            Console.WriteLine("\n7. Testando JogoAdivinhacao (WHILE)...");
            Console.WriteLine(Exercises.JogoAdivinhacao(50, new int[]{25, 75, 50}));

            // 8.
            Console.WriteLine("\n8. Testando ValidarSenha (DO-WHILE)...");
            Console.WriteLine(Exercises.ValidarSenha("MinhaSenh@123"));

            // 9.
            Console.WriteLine("\n9. Testando AnalisarNotas (FOREACH)...");
            Console.WriteLine(Exercises.AnalisarNotas(new double[]{8.5, 7.0, 9.2, 6.5, 10.0}));


            // 10.
            Console.WriteLine("\n10. Testando ProcessarVendas (FOREACH múltiplo)...");
            double[] vendas = { 500, 300, 700, 200, 400, 600 };
            string[] categorias = { "A", "B", "A", "C", "B", "C" };
            double[] comissoes = { 10, 7, 5 };            // A=10%, B=7%, C=5%
            string[] nomesCategorias = { "A", "B", "C" };
            Console.WriteLine(Exercises.ProcessarVendas(vendas, categorias, comissoes, nomesCategorias));

            Console.WriteLine("\n=== RESUMO: TODAS AS ESTRUTURAS FORAM TESTADAS ===");
            Console.WriteLine("✅ IF/ELSE: Testado na validação de idade");
            Console.WriteLine("✅ SWITCH: Testado na calculadora e classificação de notas");
            Console.WriteLine("✅ FOR: Testado na tabuada");
            Console.WriteLine("✅ WHILE: Testado no jogo de adivinhação");
            Console.WriteLine("✅ DO-WHILE: Testado na validação de senha");
            Console.WriteLine("✅ FOREACH: Testado na análise de notas e processamento de vendas");

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
