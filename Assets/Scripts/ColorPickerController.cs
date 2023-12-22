using System.Collections;
using System.Collections.Generic;
using HSVPicker;
using UnityEngine;
using UnityEngine.UI;
using Utility.Events;

public class OpenColorPicker : IBusEvent { };
public class CloseColorPicker : IBusEvent { };
public class ColorPickerColorUpdated : GenericEvent<Color> { };

public class ColorPickerController : MonoBehaviour
{

    [SerializeField]
    private ColorPicker picker;
    [SerializeField]
    private Button pickerCloseButton;

    private void Start()
    {
        EventBus.Subscribe<OpenColorPicker>(OnOpenColorPicker);

        picker.onValueChanged.AddListener(color =>
        {
            var colorUpdated = new ColorPickerColorUpdated();
            colorUpdated.Set(color);
            EventBus.Publish(colorUpdated);
        });

        picker.CurrentColor = Color.black;

        var colorUpdated = new ColorPickerColorUpdated();
        colorUpdated.Set(picker.CurrentColor);
        EventBus.Publish(colorUpdated);

        pickerCloseButton.onClick.AddListener(OnClose);

    }

    private void OnOpenColorPicker(OpenColorPicker updateEvent)
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnClose()
    {
        var closeColorPicker = new CloseColorPicker();
        EventBus.Publish(closeColorPicker);

        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<OpenColorPicker>(OnOpenColorPicker);
    }
}
