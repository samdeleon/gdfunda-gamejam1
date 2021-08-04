using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Controller : MonoBehaviour
{

    [SerializeField] private GameObject interactLabel;
    [SerializeField] private TextMeshProUGUI counterLabel;
    private int mapsFound = 0;

    public static bool isPaused;
    public static bool mapToggled;
    public static bool menuToggled;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        mapToggled = false;
        menuToggled = false;
        mapsFound = 0;

        EventBroadcaster.Instance.AddObserver(EventNames.JabubuEvents.ON_HOVER_MAP, this.showInteractPrompt);
        EventBroadcaster.Instance.AddObserver(EventNames.JabubuEvents.NOT_HOVER_MAP, this.hideInteractPrompt);
        EventBroadcaster.Instance.AddObserver(EventNames.JabubuEvents.MAP_FOUND, this.updateMapCounter);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && !menuToggled)
        {
            EventBroadcaster.Instance.PostEvent(EventNames.JabubuEvents.TOGGLE_MAP);

            mapToggled = !mapToggled;
            this.toggleUICounter();

        }

        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuToggled = !menuToggled;

            EventBroadcaster.Instance.PostEvent(EventNames.JabubuEvents.TOGGLE_MENU);
            this.toggleUICounter();
            this.togglePause();
        }
    }

    private void Awake()
    {
        
     }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveAllObservers();
        Time.timeScale = 1f;
    }

    private void toggleUICounter()
    {
        this.counterLabel.enabled = !(mapToggled || menuToggled);
    }

    private void showInteractPrompt()
    {
        this.interactLabel.SetActive(true);
    }

    private void hideInteractPrompt()
    {
        this.interactLabel.SetActive(false);
    }

    private void updateMapCounter()
    {
        mapsFound += 1;
        Debug.Log(mapsFound);
        this.counterLabel.SetText("Found: " + mapsFound);
    }

    private void togglePause()
    {
        if (isPaused)
        {   
            Resume();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Pause();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        isPaused = !isPaused;
    }

    private void Resume()
    {
        Time.timeScale = 1f;
    }

    private void Pause()
    {
        Time.timeScale = 0f;
    }

}
