using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    private float ticks = 0.0f;
    private const float END = 28.0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        this.ticks += Time.deltaTime;
        if (this.ticks >= END)
        {
            loadMainMenu();
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            loadMainMenu();
        }
    }

    private void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
