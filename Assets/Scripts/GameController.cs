using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Transform codePanelContents;
    [SerializeField]
    private GameObject drawPanel;
    [SerializeField]
    private Button runButton;
    [SerializeField]
    private Button clearButton;
    [SerializeField]
    private LineRenderer lineRenderer;

    private List<Command> _commands;
    private List<Vector3> _positions;
    private Vector3 _currentPosition = Vector3.zero;
    private float _currentAngle;
    private Color _currentColor;
    private float _currentWidth;

    private Vector3 _centerPosition = new Vector3(2.5f, 4f, 0f);


    private void Start()
    {
        _commands = new List<Command>();
        _positions = new List<Vector3>();

        Reset();
   
        runButton.onClick.AddListener(RunCode);
        clearButton.onClick.AddListener(ClearCode);
    }


    private void FlushAndGet()
    {
        _commands.Clear();
        _positions.Clear();

        Reset();
    
        GetCommands();
    }

    private void RunCode()
    {
        Debug.Log("Should run");
        
        FlushAndGet();

        foreach (Command command in _commands)
        {
            command.Execute();
        }
  
        DrawShapes();
    }


    private void ClearCode()
    {
        
        FlushAndGet();

        foreach (Command command in _commands)
        {
            command.Remove();
        }
 
        _commands.Clear();
        _positions.Clear();

        Reset();
    }

    private void Reset()
    {
        _currentPosition = _centerPosition;
        // _currentPosition += new Vector3(0, 0, 5);
        _currentAngle = 0f;
        _currentColor = Color.black;
        _currentWidth = 0.1f;
        lineRenderer.positionCount = 0;

        _positions.Add(_currentPosition);
    }


    private void GetCommands()
    {
        for (int i = 0; i < codePanelContents.childCount; i++)
        {
            var child = codePanelContents.GetChild(i).gameObject;
            
            if (child.TryGetComponent<Command>(out var command))
            {
                _commands.Add(command);
            }
        }
    }

    public void MovePosition(float distance)
    {
        
        // if(angle != 0f)
        // {
        //     _currentAngle -= angle;
        //     _currentAngle %= 360f;
        //     angle = _currentAngle;
        //     _currentAngle = 0f;
        // }
        // else
        // {
           var angle = _currentAngle;
            _currentAngle = 0f;
        // }

        var radian = angle * Mathf.Deg2Rad;
        var dx = distance * Mathf.Cos(radian);
        var dy = distance * Mathf.Sin(radian);

        _currentPosition.x += dx;
        _currentPosition.y += dy;

        _positions.Add(_currentPosition);
    }

    public void TurnAngle(float angle)
    {
        _currentAngle -= angle;
        _currentAngle %= 360f;

        Debug.Log(_currentAngle);
    }

    public void SetColor(string color)
    {
        _currentColor = color switch
        {
            "red" => Color.red,
            "green" => Color.green,
            "blue" => Color.blue,
            "yellow" => Color.yellow,
            "black" => Color.black,
            _ => Color.white,
        };
    }

    public void SetWidth(float width)
    {
        _currentWidth = width;
    }

    public void DrawShapes()
    {
        Debug.Log("Draw shapes called");

        lineRenderer.material.color = _currentColor;

        lineRenderer.startWidth = _currentWidth;

        lineRenderer.endWidth = _currentWidth;

        lineRenderer.positionCount = _positions.Count;

        for (int i = 0; i < _positions.Count; i++)
        {
            lineRenderer.SetPosition(i, _positions[i]);
        }
    }
}
