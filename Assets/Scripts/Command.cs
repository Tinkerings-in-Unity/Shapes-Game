using UnityEngine;
using UnityEngine.UI;

public class Command : MonoBehaviour
{

    protected Button deleteButton;

    protected GameController gameController;

    protected virtual void Start()
    {
        gameController = FindObjectOfType<GameController>();
        Button deleteButton =  GetComponentInChildren<Button>();
        deleteButton.onClick.AddListener(OnDeleteButtonClick);
    }

    protected void OnDeleteButtonClick()
    {
        Destroy(this.gameObject);
    }

    public virtual void Execute()
    {

    }
}
