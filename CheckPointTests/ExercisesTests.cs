using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckPoint;
using System.Text.Json.Serialization;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.EventHandlers;

namespace CheckPoint.Tests
{
    [TestClass()]
    public class ExercisesTests
    {
        [TestMethod()]
        public void DemonstrarTiposDadosTest()
        {
            string response = CheckPoint.Exercises.DemonstrarTiposDados();
            Assert.AreNotEqual(string.Empty, response);
        }

        [DataTestMethod]
        // Valid Operator Batch
        [DataRow(0, 0, '+', 0)]
        [DataRow(0, 5, '+', 5)]
        [DataRow(5, 0, '+', 5)]
        [DataRow(5, 7, '+', 12)]

        [DataRow(0, 0, '-', 0)]
        [DataRow(0, 5, '-', -5)]
        [DataRow(5, 0, '-', 5)]
        [DataRow(5, 7, '-', -2)]

        [DataRow(0, 0, '*', 0)]
        [DataRow(0, 5, '*', 0)]
        [DataRow(5, 0, '*', 0)]
        [DataRow(5, 7, '*', 35)]

        [DataRow(0, 0, '/', 0, false)]
        [DataRow(0, 5, '/', 0, false)]
        [DataRow(5, 0, '/', 0, false)]
        [DataRow(5, 7, '/', 0.7142857142857143)]

        [DataRow(0, 0, '%', 0, false)]
        [DataRow(0, 5, '%', 0, false)]
        [DataRow(5, 0, '%', 0, false)]
        [DataRow(5, 7, '%', 5)]
        [DataRow(7, 5, '%', 2)] // Extra Test

        // Invalid Operator Batch
        [DataRow(0, 0, '^', 0, false)]
        [DataRow(0, 5, '^', 0, false)]
        [DataRow(5, 0, '^', 0, false)]
        [DataRow(5, 7, '^', 0, false)]

        public void CalculadoraBasicaTest(double x, double y, char op, double expected, bool expectSuccess = true)
        {
            try
            {
                double result = CheckPoint.Exercises.CalculadoraBasica(x, y, op);
                Assert.AreEqual(expected, result, 1e-10);
            }
            catch (Exception ex)
            {
                Assert.IsFalse(expectSuccess, ex.Message);
            }
        }

        [DataTestMethod]

        [DataRow(-15, "Idade inválida")]
        [DataRow(145, "Idade inválida")]

        [DataRow(0, "Criança")]
        [DataRow(7, "Criança")]

        [DataRow(17, "Adolescente")]

        [DataRow(35, "Adulto")]

        [DataRow(78, "Idoso")]

        public void ValidarIdadeTest(int age, string expected)
        {
            string definition = CheckPoint.Exercises.ValidarIdade(age);
            Assert.AreEqual(expected, definition);
        }

        [DataTestMethod]
        // Expected Success
        [DataRow("15", "int", "15")]
        [DataRow("-15", "int", "-15")]

        [DataRow("false", "bool", "False")]
        [DataRow("true", "bool", "True")]

        [DataRow("15,7", "double", "15,7")]
        [DataRow("-15,7", "double", "-15,7")]

        // Error by porpose
        [DataRow("-15,7", "var", "-15,7", false)]
        [DataRow("false", "double", "False", false)]
        [DataRow("15,7", "bool", "15,7", false)]

        public void ConverterStringTest(string value, string type, string expected, bool expectSuccess = true)
        {
            string result = CheckPoint.Exercises.ConverterString(value, type);
            if (expectSuccess)
            {
                Assert.AreEqual($"{type}: {expected}", result);
            }
            else
            {
                Assert.AreEqual($"Conversão impossível para [{type}]", result);
            }
        }

        [DataTestMethod]

        [DataRow(9.5, "Excelente")]
        [DataRow(8.0, "Bom")]
        [DataRow(6.0, "Regular")]
        [DataRow(2.0, "Insuficiente")]

        [DataRow(-1.0, "Nota inválida")]
        [DataRow(13.0, "Nota inválida")]

        public void ClassificarNotaTest(double nota, string expected)
        {
            Assert.AreEqual(expected, Exercises.ClassificarNota(nota));
        }

        [TestMethod()]
        public void GerarTabuadaTest()
        {
            string expected = "7 x 1 = 7\n7 x 2 = 14\n7 x 3 = 21\n7 x 4 = 28\n7 x 5 = 35\n7 x 6 = 42\n7 x 7 = 49\n7 x 8 = 56\n7 x 9 = 63\n7 x 10 = 70";
            Assert.AreEqual(expected, Exercises.GerarTabuada(7));
        }

        [TestMethod()]
        public void JogoAdivinhacaoTest()
        {
            string response = Exercises.JogoAdivinhacao(15, new int[4] { 2, 6, 8, 15 });
            if (response != string.Empty)
            {
                Assert.AreNotEqual(string.Empty, response);
            }
            else
            {
                Assert.Fail();
            }
        }

        [DataTestMethod]
        [DataRow("Senha12345@")]
        [DataRow("Senha1@", false)]
        [DataRow("senha1@", false)]
        [DataRow("Senha@", false)]
        [DataRow("Senha1", false)]
        public void ValidarSenhaTest(string password, bool expectSuccess = true)
        {
            if (expectSuccess)
            {
                string response = Exercises.ValidarSenha(password);
                Assert.AreEqual("Senha válida", response);
            }
            else
            {
                Assert.IsFalse(expectSuccess);
            }
        }


        [DataTestMethod]
        [DataRow(new double[] { 10.0, 10.0, 10.0 }, "Média: 10,0\nAprovados: 3\nMaior: 10,0\nMenor: 10,0\nA: 3")]
        [DataRow(new double[] { 0.0, 0.0, 0.0 }, "Média: 0,0\nAprovados: 0\nMaior: 0,0\nMenor: 0,0\nF: 3")]
        [DataRow(new double[] { 5.0, 6.0, 6.9 }, "Média: 6,0\nAprovados: 0\nMaior: 6,9\nMenor: 5,0\nD: 3")]
        [DataRow(new double[] { 7.0, 7.0, 7.0 }, "Média: 7,0\nAprovados: 3\nMaior: 7,0\nMenor: 7,0\nC: 3")]
        [DataRow(new double[] { 8.0, 8.5, 8.9 }, "Média: 8,5\nAprovados: 3\nMaior: 8,9\nMenor: 8,0\nB: 3")]
        [DataRow(new double[] { 9.0, 9.5, 9.9 }, "Média: 9,5\nAprovados: 3\nMaior: 9,9\nMenor: 9,0\nA: 3")]
        [DataRow(new double[] { }, "Nenhuma nota para analisar")]
        [DataRow(null, "Nenhuma nota para analisar")]
        public void AnalisarNotasTest(double[] notas, string expected)
        {
            string result = Exercises.AnalisarNotas(notas);
            Assert.AreEqual(expected, result);
        }


        [DataTestMethod]
        [DataRow(new double[] { 100, 200, 300 }, new string[] { "A", "B", "A" }, new double[] { 10, 5 }, new string[] { "A", "B" }, "Categoria A: Vendas R$ 400,00, Comissão R$ 40,00\nCategoria B: Vendas R$ 200,00, Comissão R$ 10,00")]
        [DataRow(new double[] { 1000, 500, 2000 }, new string[] { "Eletronicos", "Livros", "Eletronicos" }, new double[] { 8, 12 }, new string[] { "Eletronicos", "Livros" }, "Categoria Eletronicos: Vendas R$ 3000,00, Comissão R$ 240,00\nCategoria Livros: Vendas R$ 500,00, Comissão R$ 60,00")]
        [DataRow(new double[] { 100, 200 }, new string[] { "A", "B" }, new double[] { 0, 0 }, new string[] { "A", "B" }, "Categoria A: Vendas R$ 100,00, Comissão R$ 0,00\nCategoria B: Vendas R$ 200,00, Comissão R$ 0,00")]
        [DataRow(null, new string[] { "A" }, new double[] { 10 }, new string[] { "A" }, "Dados Invalidos")]
        [DataRow(new double[] { 100 }, null, new double[] { 10 }, new string[] { "A" }, "Dados Invalidos")]
        [DataRow(new double[] { 100 }, new string[] { "A" }, null, new string[] { "A" }, "Dados Invalidos")]
        [DataRow(new double[] { 100 }, new string[] { "A" }, new double[] { 10 }, null, "Dados Invalidos")]
        [DataRow(new double[] { 100, 200 }, new string[] { "A" }, new double[] { 10 }, new string[] { "A" }, "Dados Invalidos")]
        public void ProcessarVendasTest(double[] vendas, string[] categorias, double[] comissoes, string[] nomesCategorias, string expected)
        {
            string result = Exercises.ProcessarVendas(vendas, categorias, comissoes, nomesCategorias);
            Assert.AreEqual(expected, result);
        }
    }
}