﻿namespace Day07;

public class Equation(long result, long[] inputs)
{
    private long[] Inputs { get; } = inputs;
    public long Result { get; } = result;

    public bool IsValid(List<Operator> operators)
    {
        var operatorCombinations = GetOperatorCombinations(operators, Inputs.Length - 1);
        
        return operatorCombinations.Any(combination => Calculate(combination) == Result);
    }

    private long Calculate(List<Operator> operators)
    {
        var calcResult = Inputs[0];

        for (var i = 0; i < operators.Count; i++)
        {
            var op = operators[i];
            switch (op)
            {
                case Operator.Add:
                    calcResult += Inputs[i + 1];
                    break;
                case Operator.Multiply: 
                    calcResult *= Inputs[i + 1];
                    break;
                case Operator.Concatenation:
                    calcResult = long.Parse($"{calcResult}{Inputs[i + 1]}");
                    break;
                default: 
                    throw new NotSupportedException($"Operator {op} is not supported.");
            }
        }

        return calcResult;
    }
   
    /// <summary>
    /// 0
    /// 1
    ///
    /// 00
    /// 01
    /// 10
    /// 11
    ///
    /// 000
    /// 001
    /// 010
    /// 011
    /// 100
    /// 101
    /// 110
    /// 111
    /// </summary>
    private static List<List<Operator>> GetOperatorCombinations(List<Operator> validOperators, int operatorCount)
    {
        if (operatorCount <= 1)
        {
            return validOperators.Select(op => new List<Operator> { op }).ToList();
        }

        var previousCombinations = GetOperatorCombinations(validOperators, --operatorCount);
        var newCombinations = new List<List<Operator>>();
        
        foreach (var op in validOperators)
        {
            foreach (var combination in previousCombinations)
            {
                newCombinations.Add([op, .. combination]);
            }
        }
        
        return newCombinations;
    }
    
}