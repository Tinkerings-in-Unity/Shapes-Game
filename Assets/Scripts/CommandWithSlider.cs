using TMPro;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class CommandWithSlider: Command
{
    protected float value;

    [SerializeField]
    protected TMP_Text sliderValueLabel;

    [SerializeField]
    protected Slider sliderInput;


    protected override void Start()
    {
        base.Start();

        Setup();
    }

    protected virtual void Setup()
    {
        sliderInput.onValueChanged.AddListener(delegate { OnInputValueChanged(sliderInput); });
    }

    protected override void OnOpenColorPicker(OpenColorPicker updateEvent)
    {
        base.OnOpenColorPicker(updateEvent);
        sliderInput.interactable = false;
    }

    protected override void OnCloseColorPicker(CloseColorPicker updateEvent)
    {
        base.OnCloseColorPicker(updateEvent);
        sliderInput.interactable = true;
    }


    protected virtual void OnInputValueChanged(Slider input)
    {

    }

}
