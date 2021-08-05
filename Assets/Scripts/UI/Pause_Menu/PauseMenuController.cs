using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;

    private bool menuToggle = false;
    // Start is called before the first frame update
    void Start()
    {
        menuToggle = false;
        EventBroadcaster.Instance.AddObserver(EventNames.JabubuEvents.TOGGLE_MENU, this.toggleMenu);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveAllObservers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void toggleMenu()
    {
        menuToggle = !menuToggle;
        menuPanel.SetActive(menuToggle);
    }

}
