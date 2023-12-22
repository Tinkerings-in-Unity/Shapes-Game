using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WidthCommand : CommandWithSlider
{

    protected override void Setup()
    {
        base.Setup();

        sliderValueLabel.text = "Width: " + (sliderInput.value * 0.1f);
    }

    protected override void OnInputValueChanged(Slider input)
    {
        value = input.value * 0.1f;

        sliderValueLabel.text = "Width: " + value;
    }

    public override void Execute()
    {
        gameController.SetWidth(value);
    }
}
