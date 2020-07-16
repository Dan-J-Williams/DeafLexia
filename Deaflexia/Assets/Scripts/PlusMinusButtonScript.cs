using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusMinusButtonScript : MonoBehaviour
{
    public Text currentValueText;
    public Button minusButton;
    public Button plusButton;
    public int upperBounds;
    public int lowerBounds;

    private int _currentValue;
    private Color _plusButtonColour;
    private Color _minusButtonColour;

    private void Awake()
    {
        _currentValue = int.Parse(currentValueText.text);
        _minusButtonColour = minusButton.colors.normalColor;
        _plusButtonColour = plusButton.colors.normalColor;
    }

    public void DecrementValue()
    {
        if (_currentValue > lowerBounds)
        {
            if (_currentValue == upperBounds)
            {
                plusButton.enabled = true;
            }

            _currentValue--;
            currentValueText.text = _currentValue.ToString();

            if (_currentValue == lowerBounds)
            {
                _minusButtonColour.a = 100;
                minusButton.enabled = false;
            }
        }
    }

    public void IncrementValue()
    {
        if(_currentValue < upperBounds)
        {
            if (_currentValue == lowerBounds)
            {
                minusButton.enabled = true;
            }

            _currentValue++;
            currentValueText.text = _currentValue.ToString();

            if (_currentValue == upperBounds)
            {
                _plusButtonColour.a = 100;
                plusButton.enabled = false;
            }
        }
    }

}
