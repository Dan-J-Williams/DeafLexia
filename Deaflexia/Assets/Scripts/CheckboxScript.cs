using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckboxScript : MonoBehaviour
{
    private SettingsScript _settingsScript;

    public Image tickImage;
    public bool ticked;

    [Header("Checkboxes that are in mutually exclusive sets.")]
    public bool partOfASet;
    public CheckboxScript setMember2;
    public CheckboxScript setMember3;

    public enum Effect {FontTypeVerdana, FontTypeHelvetica, FontTypeCourier, BackgroundColourYellow, BackgroundColourCreme};

    public Effect updateEffect = Effect.FontTypeVerdana;

    private void Awake()
    {
        // Sets the default tick state which can be changed in the inspector
        if (ticked)
        {
            tickImage.enabled = true;
        }
        else
        {
            tickImage.enabled = false;
        }
        _settingsScript = GameObject.FindGameObjectWithTag("SettingsCanvas").GetComponent<SettingsScript>();
    }

    public void ToggleTick()
    {
        // Handles checkboxes that AREN'T part of a set
        if (!ticked & !partOfASet)
        {
            Tick();
        }
        else if (ticked & !partOfASet)
        {
            Untick();
        }

        // Handles checkboxes that ARE part of a set
        if (!ticked & partOfASet)
        {
            // Set of three
            if (setMember2 != null && setMember3 != null)
            {
                // Tick this checkbox
                Tick();
                // Untick the other checkboxes in the set
                setMember2.Untick();
                setMember3.Untick();
            }
            // Set of two
            else if (setMember2 != null)
            {
                // Tick this checkbox
                Tick();
                // Untick the partner checkbox
                setMember2.Untick();
            }
        }
    }

    public void Tick()
    {
        tickImage.enabled = true;
        ticked = true;
        UpdateSettings();
    }

    public void Untick()
    {
        tickImage.enabled = false;
        ticked = false;
    }

    private void UpdateSettings()
    {
        // Call a function in the settings master script to update, passing in the 'Effect' enum so it knows what to do
        // Master script will use a switch that will execute an action based on the enum value
        //Debug.Log("Enum value: " + updateEffect.ToString());
        _settingsScript.UpdateUI(updateEffect.ToString());
    }
}
