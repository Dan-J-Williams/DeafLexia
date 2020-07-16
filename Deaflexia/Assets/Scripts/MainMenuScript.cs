using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public Button openBookButton;
    public Dropdown dropDown;
    public Text errorText;

    public void OpenSelectedBook()
    {
        switch (dropDown.value)
        {
            case 1:
                SceneManager.LoadScene(1);
                break;
            case 2:
                SceneManager.LoadScene(2);
                break;
            case 3:
                SceneManager.LoadScene(3);
                break;
            default:
                errorText.text = "No book selected";
                break;
        }
    }

    public void ClearErrorText()
    {
        errorText.text = "";
    }

}
