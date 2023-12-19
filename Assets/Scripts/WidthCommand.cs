using TMPro;
using UnityEngine;

public class WidthCommand : Command
{
    // The width to set
    public float width;

    public TMP_InputField inputField;

    
    protected override void Start()
    {
        base.Start();
        // Get the reference to the input field component
        // InputField inputField = this.GetComponentInChildren<InputField>();
        // // Add a listener to the input field value changed event
        // inputField.onValueChanged.AddListener(delegate { OnInputValueChanged(inputField); });
    }

    // void OnInputValueChanged()
    // {
    //     // Get the input value as a string
    //     string inputValue = inputField.text;
    //     // Try to parse the input value to the appropriate data type
    //     // If successful, assign it to the corresponding variable
    //     // If not, display an error message
    //     if (float.TryParse(inputValue, out float floatValue))
    //     {
    //         // For the move and turn commands, the parameter is a float
    //         distance = floatValue;
    //         angle = floatValue;
    //     }
    //     else if (inputValue == "red" || inputValue == "green" || inputValue == "blue" || 
    //     inputValue == "yellow" || inputValue == "black")
    //     {
    //         // For the color command, the parameter is a string
    //         color = inputValue;
    //     }
    //     else
    //     {
    //         // Display an error message
    //         Debug.LogError("Invalid input value");
    //     }

    // }

    // The method that executes the command
    public override void Execute()
    {
        gameController.SetWidth(width);
    }
}
