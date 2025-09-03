using Microsoft.VisualBasic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace CheckPoint
{
    public class Exercises
    {
        // =====================================================================
        // QUESTÃO 1 - VARIÁVEIS E TIPOS DE DADOS (10 pontos)
        // =====================================================================

        /// <summary>
        /// Create a int prefix ("System.") that is the meta Class( compiler level ) used by the Warpers.
        /// Declarate all variables.
        /// Create a String Array (Can be List<String>).
        /// Insert Manualy all Type with a hand-made RemovePrefix and pure values.
        /// and save on formated string "%s : %w" (%w -> var or dynamic equivalent).
        /// Return all joined parts into a response string.
        /// </summary>
        public static string DemonstrarTiposDados()
        {
            // prefix length declaration
            int prefix = "System.".Length;

            // variables
            int integer = 8;                                    //Int32
            double floatPoint = 8.7;                            //Double
            bool boolean = false;                               //Boolean
            char charater = 'y';                                //Char
            string stringText = "Lorem ipsum dolor sit amet";   //String

            // create strings to response [ <Type.ToString()[prefix(length..)]> : <value> ]
            string[] parts =
            [
                $"{integer.GetType().ToString()[prefix..]} : {integer}",
                $"{floatPoint.GetType().ToString()[prefix..]} : {floatPoint}",
                $"{boolean.GetType().ToString()[prefix..]} : {boolean}",
                $"{charater.GetType().ToString()[prefix..]} : {charater}",
                $"{stringText.GetType().ToString()[prefix..]} : {stringText}",
            ];

            // return it
            return String.Join($"\n", parts);
        }

        // =====================================================================
        // QUESTÃO 2 - OPERADORES ARITMÉTICOS (10 pontos)
        // =====================================================================

        /// <summary>
        /// Validate if operator is a division
        /// if it`s verify if num1 or num2 equal zero
        /// if it`s throw a division by zero exception
        /// fall on switch to find operator
        /// if is a valid operator do and return the calculus value else throw an generic exception with operator unkown on message
        /// </summary>
        public static double CalculadoraBasica(double num1, double num2, char operador)
        {
            // validate divisions by zero
            if ((operador == '%' || operador == '/') && (num1 == 0 || num2 == 0)) throw new DivideByZeroException();

            // try to identify operator on switch (if exists return specified calculus || if dont exist return operator exception)
            return operador switch
            {
                '+' => num1 + num2,
                '-' => num1 - num2,
                '*' => num1 * num2,
                '%' => num1 % num2,
                '/' => num1 / num2,
                _ => throw new Exception($"unkwon operator [{operador}] expected : [ +, -, *, %, / ]"),
            };
        }

        // =====================================================================
        // QUESTÃO 3 - OPERADORES RELACIONAIS E LÓGICOS (10 pontos)  
        // =====================================================================

        /// <summary>
        /// Validate Base case < 0 or > 120 (invalid age)
        /// Validate individualy one-by-one case with early returns.
        /// ( Criança < 12 || Adolescente > Criança AND Adolescente < 18 || Adulto > Adolescente AND Adulto < 66 || Idoso )
        /// </summary>
        public static string ValidarIdade(int idade)
        {
            if (idade < 0 || idade > 120)
            {
                return "Idade inválida";
            }
            else if (idade < 12)
            {
                return "Criança";
            }
            else if (idade < 18)
            {
                return "Adolescente";
            }
            else if (idade < 66)
            {
                return "Adulto";
            }
            else
            {
                return "Idoso";
            }
        }

        // Clean Code Aproach -> reversion and ordering method (don't nesting if else statements)
        /*  public static string ValidarIdade(int idade)
         *  {
         *      if (idade < 0) return "Idade inválida";
         *      if (idade < 12) return "Criança";
         *      if (idade < 18) return "Adolescente";
         *      if (idade < 66) return "Adulto";
         *      if (idade < 121) return "Idoso";
         *      return "Idade inválida";
         *  }
         */


        // =====================================================================
        // QUESTÃO 4 - CONVERSÃO DE TIPOS (10 pontos)
        // =====================================================================

        /// <summary>
        /// Create default error msg, and switch by default types to find the correct parser
        /// ( if error during return default error msg or return value )
        /// or return default error msg 
        /// </summary>
        public static string ConverterString(string valor, string tipoDesejado)
        {
            string errorText = $"Conversão impossível para [{tipoDesejado}]";
            return tipoDesejado.ToLower() switch
            {
                "int" => int.TryParse(valor, out var i) ? $"{tipoDesejado}: {i}" : errorText,
                "double" => double.TryParse(valor, out var d) ? $"{tipoDesejado}: {d}" : errorText,
                "bool" => bool.TryParse(valor, out var b) ? $"{tipoDesejado}: {b}" : errorText,
                _ => errorText,
            };
        }

        // =====================================================================
        // QUESTÃO 5 - ESTRUTURA CONDICIONAL SWITCH (10 pontos)
        // =====================================================================

        /// <summary>
        /// verify on switch within nota fit's and return correspondent string to it
        /// </summary>
        public static string ClassificarNota(double nota)
        {
            return nota switch
            {
                >= 9.0 and <= 10.0 => "Excelente",
                >= 7.0 and < 9.0 => "Bom",
                >= 5.0 and < 7.0 => "Regular",
                >= 0.0 and < 5.0 => "Insuficiente",
                _ => "Nota inválida"
            };
        }

        // =====================================================================
        // QUESTÃO 6 - ESTRUTURA FOR (10 pontos)
        // =====================================================================

        /// <summary>
        /// Create a string array with lenght size
        /// use a for to iterate from 1 to lenght
        /// save on array the formated string "{numero} x {i} = {numero * i}"
        /// return the joined array with \n separator
        /// </summary>
        public static string GerarTabuada(int numero, int lenght = 10)
        {
            string[] results = new string[lenght];
            for (int i = 1; i <= lenght; i++)
            {
                results[i - 1] = $"{numero} x {i} = {numero * i}";
            }
            return String.Join("\n", results);
        }

        // =====================================================================
        // QUESTÃO 7 - ESTRUTURA WHILE (15 pontos)
        // =====================================================================

        /// <summary>
        /// Create a string array with the size of attempts
        /// Instantiate attempt counter
        /// Create a while to iterate while attempt < attempts.length
        /// Read current attempt value and save on array the formated string with the result of the comparison
        /// stop the loop if the attempt is correct
        /// else increment attempt counter and continue until attempts ends
        /// </summary>
        public static string JogoAdivinhacao(int numeroSecreto, int[] tentativas)
        {
            string[] attemptResults = new string[tentativas.Length];
            int attempt = 0;
            while (attempt < tentativas.Length)
            {
                int currentAttempt = tentativas[attempt];
                attemptResults[attempt] = currentAttempt < numeroSecreto ? $"Tentativa {attempt + 1}: muito baixo" : currentAttempt > numeroSecreto ? $"Tentativa {attempt + 1}: muito alto" : $"Tentativa {attempt + 1}: correto";
                if (currentAttempt == numeroSecreto) break;
                attempt++;
            }
            return string.Join("\n", attemptResults, 0, attempt + 1);
        }

        // =====================================================================
        // QUESTÃO 8 - ESTRUTURA DO-WHILE (15 pontos)
        // =====================================================================

        /// <summary>
        /// Create a string List to save errors
        /// Validate each rule with do-while
        /// if rule not passed add the error to errors List
        /// return "Senha válida" if no errors or return joined errors with \n separator
        /// </summary>
        public static string ValidarSenha(string senha)
        {
            List<string> errors = [];

            // validate length
            if (senha.Length < 8)
            {
                errors.Add("Deve ter pelo menos 8 caracteres");
            }

            // validate numbers with do-while
            bool hasNumber = false;
            int i = 0;
            do
            {
                if (char.IsDigit(senha[i]))
                {
                    hasNumber = true;
                }
                i++;
            } while (i < senha.Length && !hasNumber);
            if (!hasNumber)
            {
                errors.Add("Deve ter pelo menos 1 número");
            }
            // validate uppercase letters with do-while
            bool hasUpperCase = false;
            i = 0;
            do
            {
                if (char.IsUpper(senha[i]))
                {
                    hasUpperCase = true;
                }
                i++;
            } while (i < senha.Length && !hasUpperCase);
            if (!hasUpperCase)
            {
                errors.Add("Deve ter pelo menos 1 letra maiúscula");
            }
            // validate special characters with do-while
            bool hasSpecialChar = false;
            i = 0;
            do
            {
                if ("!@#$%&*".Contains(senha[i]))
                {
                    hasSpecialChar = true;
                }
                i++;
            } while (i < senha.Length && !hasSpecialChar);
            if (!hasSpecialChar)
            {
                errors.Add("Deve ter pelo menos 1 caractere especial (!@#$%&*)");
            }
            // verify if has errors and return it or return valid msg
            if (errors.Count == 0)
            {
                return "Senha válida";
            }
            else
            {
                return String.Join("\n", errors);
            }
        }

        // Using Regex (alternative solution)
        /*  public static string ValidarSenha(string senha)
        *   {
        *       List<string> errors = [];
        *       // validate length
        *       if (senha.Length< 8)
        *       {
        *          errors.Add("Deve ter pelo menos 8 caracteres");
        *       }
        *       // validate numbers
        *       if (!Regex.IsMatch(senha, @"\d"))
        *       {
        *          errors.Add(..errors, "Deve ter pelo menos 1 número");
        *       }
        *       // validate uppercase letters
        *       if (!Regex.IsMatch(senha, "[A-Z]"))
        *       {
        *           errors.Add(.. errors, "Deve ter pelo menos 1 letra maiúscula");
        *       }
        *       //  validate special characters
        *       if (!Regex.IsMatch(senha, @"[!@#$%&*]"))
        *       {
        *          errors.Add(.. errors, "Deve ter pelo menos 1 letra minúscula");
        *       }
        *       if (errors.Length == 0)
        *       {
        *           return "Senha válida";
        *       }
        *       else
        *       {
        *           return String.Join("\n", errors);
        *       }
        *   }
        */


        // =====================================================================
        // QUESTÃO 9 - ESTRUTURA FOREACH (15 pontos)
        // =====================================================================

        /// <summary>
        /// Create variables to sum, max, min and passing count
        /// Verify if notas is null or empty and return "Nenhuma nota para analisar"
        /// filter brackets with switch pattern matching and save on dynamic dictionary
        /// return the formated string with all results
        /// </summary>
        public static string AnalisarNotas(double[] notas)
        {
            if (notas == null || notas.Length == 0) return "Nenhuma nota para analisar";
            double sum = 0, max = double.MinValue, min = double.MaxValue;
            int passingCount = 0;
            // Dynamic dictionary to count grade brackets
            var gradeBuckets = new Dictionary<string, int>();
            foreach (var grade in notas)
            {
                if (grade < 0 || grade > 10) continue; // Skip invalid grades

                sum += grade;
                if (grade >= 7) passingCount++;
                if (grade > max) max = grade;
                if (grade < min) min = grade;
                // Determine grade bracket using switch pattern matching
                string bucket = grade switch
                {
                    >= 9.0 and <= 10.0 => "A",
                    >= 8.0 and < 9.0 => "B",
                    >= 7.0 and < 8.0 => "C",
                    >= 5.0 and < 7.0 => "D",
                    < 5.0 => "F",
                    _ => throw new NotImplementedException(), // This should never happen due to earlier validation
                };
                // Add or increment the bucket in the dictionary
                if (gradeBuckets.TryGetValue(bucket, out int value)) // Try to get existing value (Thread Safe || Concurrent Safe)
                    gradeBuckets[bucket] = ++value;
                else
                    gradeBuckets[bucket] = 1;
            }
            double average = sum / notas.Length;
            // Build the grade bucket string dynamically
            string bucketsStr = string.Join(", ", gradeBuckets.Select(kv => $"{kv.Key}: {kv.Value}"));
            return $"Média: {average:F1}\n" +
                   $"Aprovados: {passingCount}\n" +
                   $"Maior: {max:F1}\n" +
                   $"Menor: {min:F1}\n" +
                   bucketsStr;
        }

        // =====================================================================
        // QUESTÃO 10 - MULTIPLE FOREACH (DESAFIO) (20 pontos)
        // =====================================================================

        /// <summary>
        /// This function is designed to process an array of sales figures. It categorizes each sale,
        /// calculates the corresponding commission based on predefined rates, and then aggregates
        /// the total sales and total commissions for each category. The core logic intentionally
        /// uses multiple foreach loops to meet specific implementation requirements. Finally, it
        /// compiles all the processed information into a single, well-formatted report string,
        /// with each category's summary on a new line.
        /// </summary>
        public static string ProcessarVendas(double[] vendas, string[] categorias, double[] comissoes, string[] nomesCategorias)
        {
            if (vendas == null || categorias == null || comissoes == null || nomesCategorias == null || vendas.Length != categorias.Length)
            {
                return "Dados Invalidos";
            }
            var totalSalesPerCategory = new Dictionary<string, double>();
            var totalCommissionPerCategory = new Dictionary<string, double>();
            foreach (var categoryName in nomesCategorias)
            {
                totalSalesPerCategory[categoryName] = 0;
                totalCommissionPerCategory[categoryName] = 0;
            }
            int saleIndex = 0;
            // to calculate its impact on the totals. This is the first required 'foreach' loop.
            foreach (var saleValue in vendas)
            {
                // For the current sale, let's find out which category it belongs to.
                string currentCategory = categorias[saleIndex];
                double commissionPercentage = 0;
                // through the 'categoryNames' array to find a match.
                int categoryIndex = 0;
                foreach (var categoryName in nomesCategorias)
                {
                    if (categoryName == currentCategory)
                    {
                        commissionPercentage = comissoes[categoryIndex];
                        break; // A small optimization: once we find the rate, there's no need to continue the inner loop.
                    }
                    categoryIndex++;
                }
                totalSalesPerCategory[currentCategory] += saleValue;
                totalCommissionPerCategory[currentCategory] += saleValue * commissionPercentage / 100.0;

                // Finally, we increment our sale index to ensure we look at the correct category for the next sale.
                saleIndex++;
            }

            // Now that all sales have been processed, it's time to build the final report.
            var reportLines = new List<string>();

            // We'll use our third 'foreach' loop to iterate through the 'categoryNames'. This ensures the report
            // is generated in a consistent and predictable order.
            foreach (var categoryName in nomesCategorias)
            {
                double totalSales = totalSalesPerCategory[categoryName];
                double totalCommission = totalCommissionPerCategory[categoryName];
                reportLines.Add($"Categoria {categoryName}: Vendas R$ {totalSales:F2}, Comissão R$ {totalCommission:F2}");
            }
            return string.Join("\n", reportLines);
        }
    }
}
