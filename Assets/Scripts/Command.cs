using UnityEngine;
using UnityEngine.UI;

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

    public virtual void Execute()
    {

    }
}
