using UnityEngine;
using UnityEngine.UI;
using Utility.Events;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private Transform codePanelContent;
    [SerializeField]
    private GameObject moveCommandPrefab;
    [SerializeField]
    private GameObject turnCommandPrefab;
    [SerializeField]
    private GameObject colorCommandPrefab;
    [SerializeField]
    private GameObject widthCommandPrefab;
    [SerializeField]
    private Button moveCommandButton;
    [SerializeField]
    private Button turnCommandButton;
    [SerializeField]
    private Button colorCommandButton;
    [SerializeField]
    private Button widthCommandButton;

    private void Start()
    {
        moveCommandButton.onClick.AddListener(OnMoveButtonClick);
        turnCommandButton.onClick.AddListener(OnTurnButtonClick);
        colorCommandButton.onClick.AddListener(OnColorButtonClick);
        widthCommandButton.onClick.AddListener(OnWidthButtonClick);

        EventBus.Subscribe<OpenColorPicker>(OnOpenColorPicker);
        EventBus.Subscribe<CloseColorPicker>(OnCloseColorPicker);
    }

    protected virtual void OnOpenColorPicker(OpenColorPicker updateEvent)
    {
        moveCommandButton.interactable = false;
        turnCommandButton.interactable = false;
        colorCommandButton.interactable = false;
        widthCommandButton.interactable = false;
    }

    protected virtual void OnCloseColorPicker(CloseColorPicker updateEvent)
    {
        moveCommandButton.interactable = true;
        turnCommandButton.interactable = true;
        colorCommandButton.interactable = true;
        widthCommandButton.interactable = true;
    }

    public void OnMoveButtonClick()
    {
        var moveCommand = Instantiate(moveCommandPrefab, codePanelContent);
        moveCommand.transform.localScale = Vector3.one;
    }

    public void OnTurnButtonClick()
    {
        var turnCommand = Instantiate(turnCommandPrefab, codePanelContent);
        turnCommand.transform.localScale = Vector3.one;
    }

    public void OnColorButtonClick()
    {
        var colorCommand = Instantiate(colorCommandPrefab, codePanelContent);
        colorCommand.transform.localScale = Vector3.one;
    }

    public void OnWidthButtonClick()
    {
        var widthCommand = Instantiate(widthCommandPrefab, codePanelContent);
        widthCommand.transform.localScale = Vector3.one;
    }
}
