using UnityEngine;
using UnityEngine.UI;
using Utility.Events;

public class Command : MonoBehaviour
{

    [SerializeField]
    protected Button deleteButton;
    [SerializeField]
    protected Button upButton;
    [SerializeField]
    protected Button downButton;

    protected GameController gameController;

    protected virtual void Start()
    {
        gameController = FindObjectOfType<GameController>();
        deleteButton.onClick.AddListener(OnDeleteButtonClick);
        upButton.onClick.AddListener(OnUpButtonClick);
        downButton.onClick.AddListener(OnDownButtonClick);

        EventBus.Subscribe<OpenColorPicker>(OnOpenColorPicker);
        EventBus.Subscribe<CloseColorPicker>(OnCloseColorPicker);
    }

    protected virtual void OnOpenColorPicker(OpenColorPicker updateEvent)
    {
        deleteButton.interactable = false;
        upButton.interactable = false;
        downButton.interactable = false;
    }

    protected virtual void OnCloseColorPicker(CloseColorPicker updateEvent)
    {
        deleteButton.interactable = true;
        upButton.interactable = true;
        downButton.interactable = true;
    }

    protected void OnDeleteButtonClick()
    {
        Destroy(gameObject);
    }

    protected void OnUpButtonClick()
    {
        var originalIndex = transform.GetSiblingIndex();
        originalIndex --;

        var parent = transform.parent;

        if(parent.GetChild(originalIndex)){
            transform.SetSiblingIndex(originalIndex);
        }
    }

    protected void OnDownButtonClick()
    {
        var originalIndex = transform.GetSiblingIndex();
        originalIndex ++;

        var parent = transform.parent;

        if(parent.GetChild(originalIndex)){
            transform.SetSiblingIndex(originalIndex);
        }
    }

    public void Remove()
    {
        OnDeleteButtonClick();
    }

    public virtual void Execute()
    {

    }
}
