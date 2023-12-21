using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveCommand : Command
{
    private float _distance;

    [SerializeField]
    private TMP_Text sliderValueLabel;

    [SerializeField]
    
    private Slider distanceInput;


    protected override void Start()
    {
        base.Start();

        distanceInput.onValueChanged.AddListener(delegate { OnDistanceInputValueChanged(distanceInput); });

        sliderValueLabel.text = "Distance: " + (distanceInput.value * 0.5f);
    }

    private void OnDistanceInputValueChanged(Slider input)
    {
        _distance = input.value * 0.5f;

        sliderValueLabel.text = "Distance: " + _distance;
    }


    public override void Execute()
    {
        gameController.MovePosition(_distance);
    }
}
