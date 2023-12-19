using TMPro;
using UnityEngine;

public class WidthCommand : Command
{
    private float _width;

    [SerializeField]
    private TMP_InputField inputField;


    protected override void Start()
    {
        base.Start();

        inputField.onValueChanged.AddListener(delegate { OnInputValueChanged(inputField); });
    }

    void OnInputValueChanged(TMP_InputField inputField)
    {
        string inputValue = inputField.text;

        if (float.TryParse(inputValue, out float floatValue))
        {
            _width = floatValue;
        }
        else
        {
            Debug.LogError("Invalid input value");
        }

    }

    public override void Execute()
    {
        gameController.SetWidth(_width);
    }
}
