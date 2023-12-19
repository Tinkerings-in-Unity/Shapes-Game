using TMPro;
using UnityEngine;

public class MoveCommand : Command
{
    private float _distance;
    private float _angle;

    [SerializeField]
    private TMP_InputField distanceInputField;

    [SerializeField]
    private TMP_InputField angleInputField;

    protected override void Start()
    {
        base.Start();

        distanceInputField.onValueChanged.AddListener(delegate { OnDistanceInputValueChanged(distanceInputField); });
        angleInputField.onValueChanged.AddListener(delegate { OnAngleInputValueChanged(distanceInputField); });
    }

    private void OnDistanceInputValueChanged(TMP_InputField inputField)
    {
        string inputValue = inputField.text;

        if (float.TryParse(inputValue, out float floatValue))
        {
            _distance = floatValue;
        }
        else
        {
            Debug.LogError("Invalid input value");
        }

    }

    private void OnAngleInputValueChanged(TMP_InputField inputField)
    {
        string inputValue = inputField.text;

        if (float.TryParse(inputValue, out float floatValue))
        {
            _distance = floatValue;
        }
        else
        {
            Debug.LogError("Invalid input value");
        }

    }

    public override void Execute()
    {
        gameController.MovePosition(_distance, _angle);
    }
}
