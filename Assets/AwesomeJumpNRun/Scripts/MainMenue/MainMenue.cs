using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenue : MonoBehaviour{

	public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Einstellungen()
    {
        SceneManager.LoadScene(3);
    }

    public void Credits()
    {
        SceneManager.LoadScene(2);
    }
}
