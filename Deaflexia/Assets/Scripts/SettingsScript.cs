using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    private GameObject[] _settingsItemsT1;
    private GameObject[] _settingsItemsT2;
    private GameObject[] _settingsItemsT3;

    private string _ExpandedOrContracted = "Contracted";

    private Text[] textObjects;

    private Color32 _backgroundCreme = new Color32(255, 240, 175, 255);
    private Color32 _backgroundYellow = new Color32(255, 255, 150, 255);

    public Animator settingsAnim;

    public Image backgroundPanelImage;

    public Font fontVerdana;
    public Font fontHelvetica;
    public Font fontCourier;

    private void Awake()
    {
        textObjects = FindObjectsOfType<Text>();
        _settingsItemsT1 = GameObject.FindGameObjectsWithTag("SettingsT1");
        _settingsItemsT2 = GameObject.FindGameObjectsWithTag("SettingsT2");
        _settingsItemsT3 = GameObject.FindGameObjectsWithTag("SettingsT3");
        ChangeActiveState(_settingsItemsT1, false);
        ChangeActiveState(_settingsItemsT2, false);
        ChangeActiveState(_settingsItemsT3, false);
    }

    public void ExpandOrContract()
    {
        if (_ExpandedOrContracted == "Contracted")
        {
            StartCoroutine(Expand());
        }
        else
        {
            StartCoroutine(Contract());
        }
    }

    private IEnumerator Expand()
    {
        settingsAnim.Play("Expand");
        _ExpandedOrContracted = "Expanded";

        yield return new WaitForSecondsRealtime(0.2f);
        ChangeActiveState(_settingsItemsT1, true);
        yield return new WaitForSecondsRealtime(0.2f);
        ChangeActiveState(_settingsItemsT2, true);
        yield return new WaitForSecondsRealtime(0.2f);
        ChangeActiveState(_settingsItemsT3, true);
    }

    private IEnumerator Contract()
    {
        settingsAnim.Play("Contract");
        _ExpandedOrContracted = "Contracted";

        ChangeActiveState(_settingsItemsT3, false);
        yield return new WaitForSecondsRealtime(0.2f);
        ChangeActiveState(_settingsItemsT2, false);
        yield return new WaitForSecondsRealtime(0.2f);
        ChangeActiveState(_settingsItemsT1, false);
    }

    private void ChangeActiveState(GameObject[] gameObjArray, bool trueOrFalse)
    {
        foreach (GameObject g in gameObjArray)
        {
            g.SetActive(trueOrFalse);
        }
    }

    public void UpdateUI(string componentToUpdate)
    {
        switch (componentToUpdate)
        {
            case "BackgroundColourYellow":
                // Change background colour to yellow
                backgroundPanelImage.color = _backgroundYellow;
                break;
            case "BackgroundColourCreme":
                // Change background colour to creme
                backgroundPanelImage.color = _backgroundCreme;
                break;
            case "FontTypeVerdana":
                ChangeFontType(fontVerdana);
                break;
            case "FontTypeHelvetica":
                ChangeFontType(fontHelvetica);
                break;
            case "FontTypeCourer":
                ChangeFontType(fontCourier);
                break;
            default:
                // Do nothing
                break;
        }
    }

    private void ChangeFontType(Font updatedFont)
    {
        foreach (Text textItem in textObjects)
        {
            textItem.font = updatedFont;
        }
    }

}
