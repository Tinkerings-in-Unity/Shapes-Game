using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnCommand : Command
{
    private float _angle;

    [SerializeField]
    private TMP_Text sliderValueLabel;

    [SerializeField]
    private Slider angleInput;


    protected override void Start()
    {
        base.Start();

        angleInput.onValueChanged.AddListener(delegate { OnInputValueChanged(angleInput); });

        sliderValueLabel.text = "Angle: " + (angleInput.value * 5f);
    }

    private void OnInputValueChanged(Slider input)
    {

       _angle= input.value * 5f;

        sliderValueLabel.text = "Angle: " + _angle;

    }

    public override void Execute()
    {
        gameController.TurnAngle(_angle);
    }
}
