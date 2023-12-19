using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Transform codePanelContent;
    public GameObject moveCommandPrefab;
    public GameObject turnCommandPrefab;
    public GameObject colorCommandPrefab;
    public GameObject widthCommandPrefab;

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
