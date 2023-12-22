using UnityEngine;
using HSVPicker;
using UnityEngine.UI;
using Utility.Events;

public class ColorCommand : Command
{
    
    [SerializeField]
    private Image colorPickedRenderer;
    [SerializeField]
    private Button colorButton;
    

    private Color _color;

    protected override void Start()
    {
        base.Start();

        EventBus.Subscribe<ColorPickerColorUpdated>(OnColorUpdated);

        colorButton.onClick.AddListener(OnColorButtonClicked);
    }

    protected override void OnOpenColorPicker(OpenColorPicker updateEvent)
    {
        base.OnOpenColorPicker(updateEvent);
        colorButton.interactable = false;
    }

    protected override void OnCloseColorPicker(CloseColorPicker updateEvent)
    {
        base.OnCloseColorPicker(updateEvent);
        colorButton.interactable = true;
    }

    private void OnColorUpdated(ColorPickerColorUpdated updateEvent)
    {
        _color = updateEvent.First;
        colorPickedRenderer.color = _color;
    }

    private void OnColorButtonClicked()
    {
        var openColorPicker = new OpenColorPicker();
        EventBus.Publish(openColorPicker);
    }


    public override void Execute()
    {
        gameController.SetColor(_color);
    }
}
