using TMPro;
using UnityEngine;

public class TurnCommand: Command
{
    private float _angle;

    [SerializeField]
    private TMP_InputField inputField;


    protected override void Start()
    {
        base.Start();

        inputField.onValueChanged.AddListener(delegate { OnInputValueChanged(inputField); });
    }

    private void OnInputValueChanged(TMP_InputField inputField)
    {
        string inputValue = inputField.text;

        if (float.TryParse(inputValue, out float floatValue))
        {
            _angle = floatValue;
        }
        else
        {
            Debug.LogError("Invalid input value");
        }

    }

    public override void Execute()
    {
        gameController.TurnAngle(_angle);
    }
}
