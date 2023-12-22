using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnCommand : CommandWithSlider
{
    protected override void Setup()
    {
        base.Setup();

        sliderValueLabel.text = "Angle: " + (sliderInput.value * 5f);
    }

    protected override void OnInputValueChanged(Slider input)
    {
        value = input.value * 5f;

        sliderValueLabel.text = "Angle: " + value;
    }

    public override void Execute()
    {
        gameController.TurnAngle(value);
    }
}
