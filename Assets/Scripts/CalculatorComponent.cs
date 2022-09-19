using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class CalculatorComponent : MonoBehaviour
{
    [SerializeField] private InputField _firstOperandInput;
    [SerializeField] private InputField _secondOperandInput;

    [SerializeField] private Text _resultText;

    public void Start()
    {
        _resultText.gameObject.SetActive(false);
    }

    public void Addition() => Execute(Operations.Addition);

    public void Subtraction() => Execute(Operations.Subtraction);

    public void Multiplication() => Execute(Operations.Multiplication);

    public void Division() => Execute(Operations.Division);

    private void Execute(Operations operation)
    {
        _resultText.gameObject.SetActive(true);

        if (!double.TryParse(_firstOperandInput.text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var firstOperand) ||
            !double.TryParse(_secondOperandInput.text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var secondOperand) ||
            (operation == Operations.Division && secondOperand == 0))
        {
            _resultText.text = "ERROR";
            return;
        }

        var result = operation switch
        {
            Operations.Addition => firstOperand + secondOperand,
            Operations.Subtraction => firstOperand - secondOperand,
            Operations.Multiplication => firstOperand * secondOperand,
            Operations.Division => firstOperand / secondOperand,
            _ => throw new NotImplementedException()
        };

        result = Math.Round(result, 5);

        _resultText.text = result.ToString();
    }

    private enum Operations
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
}
