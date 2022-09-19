using System;
using UnityEngine;
using UnityEngine.UI;

public class ComparerComponent : MonoBehaviour
{
    [SerializeField] private InputField _firstNumberInput;
    [SerializeField] private InputField _secondNumberInput;

    [SerializeField] private Text _resultText;

    private void Start()
    {
        _resultText.gameObject.SetActive(false);
    }

    public void Compare()
    {
        _resultText.gameObject.SetActive(true);

        if (!int.TryParse(_firstNumberInput.text, out var firstNumber) ||
            !int.TryParse(_secondNumberInput.text, out var secondNumber))
        {
            _resultText.text = "ERROR";
            return;
        }

        _resultText.text = GetResultText(firstNumber, secondNumber);
    }

    private string GetResultText(int firstNumber, int secondNumber) =>
        firstNumber == secondNumber
            ? "EQUAL"
            : Math.Max(firstNumber, secondNumber).ToString();
}
