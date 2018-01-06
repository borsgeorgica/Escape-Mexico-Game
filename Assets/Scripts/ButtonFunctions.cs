using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour {

	public void startGame()
    {
        SceneManager.LoadScene("Main");

    }

    public void quitGame()
    {
        Application.Quit();
    }
}
