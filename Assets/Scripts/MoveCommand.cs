using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveCommand : CommandWithSlider
{

    protected override void Setup()
    {
        base.Setup();

        sliderValueLabel.text = "Distance: " + (sliderInput.value * 0.5f);
    }

    protected override void OnInputValueChanged(Slider input)
    {
        value = input.value * 0.5f;

        sliderValueLabel.text = "Distance: " + value;
    }

    public override void Execute()
    {
        gameController.MovePosition(value);
    }
}
