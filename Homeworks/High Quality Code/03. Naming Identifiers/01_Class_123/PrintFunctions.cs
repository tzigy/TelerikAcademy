namespace PrintVariables
{
    using System;

    public class PrintingFunctions
    {
        public void PrintBooleanAsString(bool boolVariable)
        {
            string boolVariableAsString = boolVariable.ToString();
            Console.WriteLine(boolVariableAsString);
        }
    }
}
