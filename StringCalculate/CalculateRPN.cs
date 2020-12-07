using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculate
{
    public struct Operator
    {
        public byte Priority;
        public Func <double,double,double> Execute;
        
        public Operator(Func<double, double, double> execute, byte priority)
        {
            Priority = priority;
            Execute = execute;
        }
    }

    static class CalculateRPN
    {
        /// <summary>
        /// Словарь функций. Например sinr(a)
        /// </summary>
        public static Dictionary<string, Func<double, double>> PrefixFunctions = new Dictionary<string, Func<double, double>>
        {
            { "sinr", (v)=>Math.Abs(v) > 9223372036854775299 ? 0 : Math.Sin(v)},
            { "cosr", (v)=>Math.Abs(v) > 9223372036854775299 ? 0 : Math.Cos(v)},
            { "tanr", (v)=>Math.Abs(v) > 9223372036854775299 ? 0 : Math.Tan(v)},
            { "ctgr", (v)=>Math.Abs(v) > 9223372036854775299 ? 0 : Math.Pow(Math.Tan(v), -1)},
            { "sind", (v)=>Math.Abs(v) > 9223372036854775299 ? 0 : Math.Sin(v*Math.PI /180)},
            { "cosd", (v)=>Math.Abs(v) > 9223372036854775299 ? 0 : Math.Cos(v*Math.PI / 180)},
            { "tand", (v)=>Math.Abs(v) > 9223372036854775299 ? 0 : Math.Tan(v* Math.PI / 180)},
            { "ctgd", (v)=>Math.Abs(v) > 9223372036854775299 ? 0 : Math.Pow(Math.Tan(v* Math.PI / 180), -1)},
            { "asin", (v)=>Math.Asin(v)},
            { "acos", (v)=>Math.Acos(v)},
            { "atan", (v)=>Math.Atan(v)},
            { "sinh", (v)=>Math.Sinh(v)},
            { "cosh", (v)=>Math.Cosh(v)},
            { "tanh", (v)=>Math.Tanh(v)},
            { "sqrt", (v)=>Math.Sqrt(v)},
            { "abs", (v)=>Math.Abs(v)},
            { "exp", (v)=>Math.Exp(v)},
            { "ln", (v)=>Math.Log(v)},
            { "log", (v)=>Math.Log(v,2)},
            { "logd", (v)=>Math.Log10(v)},
            { "sign", (v)=>Math.Sign(v)},
            { "round", (v)=>Math.Round(v)},
            { "ceiling", (v)=>Math.Ceiling(v)},
            { "floor", (v)=>Math.Floor(v)},
            { "fract", (v)=>v-Math.Truncate(v)},
            { "inv", (v)=>-v}
        };

        /// <summary>
        /// Словарь постфиксных функции. Пример "2!" 
        /// </summary>
        public static Dictionary<string, Func<double, double>> PostfixFunctions = new Dictionary<string, Func<double, double>>()
        {
            {"!", (v)=>
            {   if (!long.TryParse(v.ToString(), out long l))
                    throw new ArgumentException();
                return Factorial((long)v); 
            }},
            {"%", (v)=>v/100.0}
        };

        /// <summary>
        /// Словарь математических констант
        /// </summary>
        public static Dictionary<string, double> MathConsts = new Dictionary<string, double>
        { 
            { "pi", Math.PI }, 
            { "e", Math.E } 
        };

        /// <summary>
        /// Словарь математических операторов
        /// </summary>
        public static Dictionary<string, Operator> Operations = new Dictionary<string, Operator>()
        {
            {"+", new Operator((a,b)=>a+b, 1)},
            {"-", new Operator((a,b)=>a-b, 1)},
            {"*", new Operator((a,b)=>a*b, 2)},
            {"/", new Operator((a,b)=>a/b, 2)},
            {"\\", new Operator((a,b)=>Math.Floor(a / b), 2)},
            {":", new Operator((a,b)=>a%b, 3)},
            {"^", new Operator((a,b)=>Math.Pow(a,b), 3)}
        };

        /// <summary>
        /// Список регулярных выражений для метода ConvertMathExpressionToArray
        /// </summary>
        private static readonly List<Regex> _regexList = new List<Regex>
        {
            new Regex(@"\s*[-+*/()\\^!%:]\s*", RegexOptions.Compiled), 
            new Regex(@"([+*/(|\\^:]|^)\s*(?:(?:-)\s*([A-Za-z0-9(.]))", RegexOptions.Compiled)
        };

        private static MatchEvaluator _evaluator;

        private readonly static CultureInfo _culture = new CultureInfo("en-US");

        /*--------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Метод для образования входного выражения в выходной массив токенов
        /// </summary>
        /// <param name="expression">Математическое выражение</param>
        /// <returns></returns>
        private static string[] ConvertMathExpressionToArray(string expression)
        {
            _evaluator = new MatchEvaluator((m) => $" { m.Value} ");
            expression = _regexList[0].Replace(expression, _evaluator);
            _evaluator = new MatchEvaluator((m) => $"{ m.Groups[1].Value} inv { m.Groups[2].Value}");
            expression = _regexList[1].Replace(expression, _evaluator);

            return expression.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Метод для преобразования выражения из инфиксной формы в постфиксную форму
        /// </summary>
        /// <param name="expression">Математическое выражение</param>
        /// <param name="isError">Флаг ошибки</param>
        /// <returns></returns>
        public static string ConvertToPostfixNotation(string expression, out bool isError)
        {
            StringBuilder outputExpression = new StringBuilder();
            Stack<string> stack = new Stack<string>();
            string valueOfStack;
            isError = false;

            string[] expressionArray = ConvertMathExpressionToArray(expression);

            foreach (string selectToken in expressionArray)
            {
                if (double.TryParse(selectToken, NumberStyles.Float, _culture, out double t) || PostfixFunctions.ContainsKey(selectToken))
                {
                    outputExpression.Append($"{selectToken} ");
                }   
                else if (MathConsts.ContainsKey(selectToken))
                {
                    outputExpression.Append($"{MathConsts[selectToken]} ");
                }
                else if (Operations.ContainsKey(selectToken))
                {
                    byte priorityValueOfStack;

                    while (stack.Count>0)
                    {
                        valueOfStack = stack.Peek();
                        if (Operations.ContainsKey(valueOfStack))
                            priorityValueOfStack = Operations[valueOfStack].Priority;
                        else if (PrefixFunctions.ContainsKey(valueOfStack))
                            priorityValueOfStack = 4;
                        else priorityValueOfStack = 255;

                        if (priorityValueOfStack < Operations[selectToken].Priority || priorityValueOfStack == 255)
                            break;
                        else
                        {
                            valueOfStack = stack.Pop();
                            outputExpression.Append($"{valueOfStack} ");
                        }
                    }
                    stack.Push(selectToken);
                }
                else if (selectToken == ")")
                {
                    bool isOpenBracket = false;

                    while (stack.Count>0)
                    {
                        valueOfStack = stack.Pop();
                        if (valueOfStack == "(")
                        {
                            isOpenBracket = true;
                            break;
                        }
                        else
                            outputExpression.Append(valueOfStack + " ");
                    }
                    if (!isOpenBracket) isError = true;
                }
                else if (PrefixFunctions.ContainsKey(selectToken) || selectToken == "(")
                {
                    stack.Push(selectToken);
                }
                else isError = true;
            }

            while (stack.Count>0)
            {
                valueOfStack = stack.Pop();
                if (valueOfStack == "(") isError = true;
                outputExpression.Append($"{valueOfStack} ");
            }
            
            return isError == true ? "" : outputExpression.ToString();
        }
 
        public static string[] ConvertToPostfixNotationInArray(string expression, out bool isError)
        {
            string resultExpression = ConvertToPostfixNotation(expression, out isError);
            if (!isError)
            {
                string[] OutputArray = resultExpression.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return OutputArray;
            }
            else
                return new string[] { "" };
        }

        /// <summary>
        /// Метод для вычисления выражения из массива токенов постфиксной формы
        /// </summary>
        /// <param name="expression">Математическое выражение в виде массива токенов в постфиксной форме</param>
        /// <param name="isError">Флаг ошибки</param>
        /// <returns></returns>
        private static double CalcExpFromPostfixNotation(string[] expression, out bool isError)
        {
            Stack<string> stack = new Stack<string>(); 
            isError = false;
            double result=0, a, b;
            foreach (string token in expression)
            {
                if (isError) 
                    break;
                if (double.TryParse(token, NumberStyles.Float, _culture, out double t))
                {
                    result = t;
                }
                else if (Operations.ContainsKey(token))
                {
                    try
                    {
                        b = double.Parse(stack.Pop());
                        a = double.Parse(stack.Pop());
                        result = Operations[token].Execute(a, b);
                    }
                    catch
                    {
                        isError = true;
                        break;
                    }
                }
                else
                {
                    try
                    {
                        a = double.Parse(stack.Pop());
                        if (PostfixFunctions.ContainsKey(token))
                            result = PostfixFunctions[token].Invoke(a);
                        else if (PrefixFunctions.ContainsKey(token))
                             result = PrefixFunctions[token].Invoke(a);
                    }
                    catch
                    {
                        isError = true;
                        break;
                    }
                }
                if (double.IsNaN(result))
                    isError = true;
                else
                    stack.Push(result.ToString());
            }
            return isError == false ? (stack.Count == 0 ? 0 : double.Parse(stack.Pop())) : 0;
        }

        /// <summary>
        /// Вычисления математического выражение expression
        /// </summary>
        /// <param name="expression">МатематическоЕ выражение</param>
        /// <param name="isError">Флаг ошибки</param>
        /// <returns></returns>
        public static double CalcalateExpression(string expression, out bool isError)
        {
            string[] resConvertToPosfixForm = ConvertToPostfixNotationInArray(expression, out isError);
            if (isError) return 0;
            double result = CalcExpFromPostfixNotation(resConvertToPosfixForm, out isError);
            return isError ? 0 : result;
        }

        /*--------------------------------------------------------------------------------------------------------------------*/

        private static double Factorial(long n)
        {
            double result = 1.0;
            if (n<=0)
                return 1.0;
            else if (n > 170.0)
                return double.PositiveInfinity;
            else
            {
                for (int i = 1; i <= n; i++)
                    result *= i;
                return result;
            }
        }
    }
}