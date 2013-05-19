using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculate
{
    
    public static class Evaluator
    {
        
        public static decimal Parse(string expression)
        {
            decimal d;
            if (decimal.TryParse(expression, out d))
            {
               
                return d;
            }
            else
            {
                return CalculateValue(expression);
            }
        }

       
        public static bool TryParse(string expression, out decimal value)
        {
            if (IsExpression(expression))
            {
                try
                {
                    value = Parse(expression);
                    return true;
                }
                catch
                {
                    value = 0;
                    return false;
                }
            }
            else
            {
                value = 0;
                return false;
            }
        }

       
        public static bool IsExpression(string s)
        {
          
            Regex RgxUrl = new Regex("^[0-9+*-/^()., ]+$");
            return RgxUrl.IsMatch(s);
        }

       
        private static List<string> TokenizeExpression(string expression, Dictionary<char, int> operators)
        {
            List<string> elements = new List<string>();
            string currentElement = string.Empty;

            int state = 0;
            
            int bracketCount = 0;
            for (int i = 0; i < expression.Length; i++)
            {
                switch (state)
                {
                    case 0:
                        if (expression[i] == '(')
                        {
                            
                            state = 1;
                            bracketCount = 0;
                            if (currentElement != string.Empty)
                            {
                               
                                elements.Add(currentElement);
                                elements.Add("*");
                                currentElement = string.Empty;
                            }
                        }
                        else if (operators.Keys.Contains(expression[i]))
                        {
                            //The current character is an operator
                            elements.Add(currentElement);
                            elements.Add(expression[i].ToString());
                            currentElement = string.Empty;
                        }
                        else if (expression[i] != ' ')
                        {
                           
                            currentElement += expression[i];
                        }
                        break;
                    case 1:
                        if (expression[i] == '(')
                        {
                            bracketCount++;
                            currentElement += expression[i];
                        }
                        else if (expression[i] == ')')
                        {
                            if (bracketCount == 0)
                            {
                                state = 2;
                            }
                            else
                            {
                                bracketCount--;
                                currentElement += expression[i];
                            }
                        }
                        else if (expression[i] != ' ')
                        {
                            
                            currentElement += expression[i];
                        }
                        break;
                    case 2:
                        if (operators.Keys.Contains(expression[i]))
                        {
                            
                            state = 0;
                            elements.Add(currentElement);
                            currentElement = string.Empty;
                            elements.Add(expression[i].ToString());
                        }
                        else if (expression[i] != ' ')
                        {
                            elements.Add(currentElement);
                            elements.Add("*");
                            currentElement = string.Empty;


                            if (expression[i] == '(')
                            {
                                state = 1;
                                bracketCount = 0;
                            }
                            else
                            {
                                currentElement += expression[i];
                                state = 0;
                            }
                        }
                        break;
                }
            }

            
            if (currentElement.Length > 0)
            {
                elements.Add(currentElement);
            }

            return elements;
        }

       
        private static decimal CalculateValue(string expression)
        {
           
            Dictionary<char, int> operators = new Dictionary<char, int>
            { 
                {'+', 1}, {'-', 1}, {'*', 2}, {'/', 2}, {'^', 3}
            };

         
            List<string> elements = TokenizeExpression(expression, operators);

          
            decimal value = 0;

           
            for (int i = operators.Values.Max(); i >= operators.Values.Min(); i--)
            {

                
                while (elements.Count >= 3
                    && elements.Any(element => element.Length == 1 &&
                        operators.Where(op => op.Value == i)
                        .Select(op => op.Key).Contains(element[0])))
                {
                   
                    int pos = elements
                        .FindIndex(element => element.Length == 1 &&
                        operators.Where(op => op.Value == i)
                        .Select(op => op.Key).Contains(element[0]));

                    
                    value = EvaluateOperation(elements[pos], elements[pos - 1], elements[pos + 1]);
                   
                    elements[pos - 1] = value.ToString();
                  
                    elements.RemoveRange(pos, 2);
                }
            }

            return value;
        }

    
        private static decimal EvaluateOperation(string oper, string operand1, string operand2)
        {
            if (oper.Length == 1)
            {
                decimal op1 = Parse(operand1);
                decimal op2 = Parse(operand2);

                decimal value = 0;
                switch (oper[0])
                {
                    case '+':
                        value = op1 + op2;
                        break;
                    case '-':
                        value = op1 - op2;
                        break;
                    case '*':
                        value = op1 * op2;
                        break;
                    case '/':
                        value = op1 / op2;
                        break;
                    case '^':
                        value = Convert.ToDecimal(Math.Pow(Convert.ToDouble(op1), Convert.ToDouble(op2)));
                        break;
                    default:
                        throw new ArgumentException("Unsupported operator");
                }
                return value;
            }
            else
            {
                throw new ArgumentException("Unsupported operator");
            }
        }
    }
}