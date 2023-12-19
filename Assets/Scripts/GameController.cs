using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public GameObject commandBlocksPanel;
    public GameObject codePanel;
    public GameObject drawPanel;
    public Button runButton;
    public Button clearButton;
    public LineRenderer lineRenderer;

    private List<Command> commands;
    private List<Vector3> positions;
    private Vector3 currentPosition;
    private float currentAngle;
    private Color currentColor;
    private float currentWidth;


    private void Start()
    {
        commands = new List<Command>();
        positions = new List<Vector3>();

        Reset();
   
        runButton.onClick.AddListener(RunCode);
        clearButton.onClick.AddListener(ClearCode);
    }


    // Run the code and draw the shapes
    private void RunCode()
    {
        commands.Clear();
        positions.Clear();
    
        GetCommands();
   
        foreach (Command command in commands)
        {
            command.Execute();
        }
  
        DrawShapes();
    }


    private void ClearCode()
    {
 
        commands.Clear();
        positions.Clear();

        Reset();
    }

    private void Reset()
    {
        currentPosition = drawPanel.transform.position;
        currentAngle = 0f;
        currentColor = Color.black;
        currentWidth = 1f;
        lineRenderer.positionCount = 0;
    }

   

    // Get the commands from the code panel
    private void GetCommands()
    {
        for (int i = 0; i < codePanel.transform.childCount; i++)
        {
            var child = codePanel.transform.GetChild(i).gameObject;
            var command = child.GetComponent<Command>();

            if (command != null)
            {
                commands.Add(command);
            }
        }
    }

    // Move the current position by a distance and an angle
    public void MovePosition(float distance, float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        float dx = distance * Mathf.Cos(radian);
        float dy = distance * Mathf.Sin(radian);

        currentPosition.x += dx;
        currentPosition.y += dy;

        positions.Add(currentPosition);
    }

    // Turn the current angle by an angle
    public void TurnAngle(float angle)
    {
        // Add the angle to the current angle
        currentAngle += angle;
        // Wrap the current angle between 0 and 360 degrees
        currentAngle = currentAngle % 360;
    }

    public void SetColor(string color)
    {
        // Switch on the color
        switch (color)
        {
            // If the color is "red"
            case "red":
                // Set the current color to red
                currentColor = Color.red;
                break;
            // If the color is "green"
            case "green":
                // Set the current color to green
                currentColor = Color.green;
                break;
            // If the color is "blue"
            case "blue":
                // Set the current color to blue
                currentColor = Color.blue;
                break;
            // If the color is "yellow"
            case "yellow":
                // Set the current color to yellow
                currentColor = Color.yellow;
                break;
            // If the color is "black"
            case "black":
                // Set the current color to black
                currentColor = Color.black;
                break;
            // If the color is anything else
            default:
                // Set the current color to white
                currentColor = Color.white;
                break;
        }
    }

    public void SetWidth(float width)
    {
        currentWidth = width;
    }

    // Draw the shapes using the line renderer
    public void DrawShapes()
    {
        lineRenderer.material.color = currentColor;

        lineRenderer.startWidth = currentWidth;

        lineRenderer.endWidth = currentWidth;

        lineRenderer.positionCount = positions.Count;

        for (int i = 0; i < positions.Count; i++)
        {
            lineRenderer.SetPosition(i, positions[i]);
        }
    }
}
