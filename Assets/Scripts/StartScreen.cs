using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.visible = true;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        };
    }

}
