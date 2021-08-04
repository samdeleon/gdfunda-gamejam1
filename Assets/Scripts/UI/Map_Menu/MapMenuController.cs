using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MapMenuController : MonoBehaviour
{
    [SerializeField] private GameObject mapMenu;
    [SerializeField] private TextMeshProUGUI mapCounter;
    [SerializeField] private GameObject mapTopLeft;
    [SerializeField] private GameObject mapTopRight;
    [SerializeField] private GameObject mapBotLeft;
    [SerializeField] private GameObject mapBotRight;

    private bool mapToggle = false;
    private int mapCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        mapToggle = false;
        mapCount = 0;
        EventBroadcaster.Instance.AddObserver(EventNames.JabubuEvents.TOGGLE_MAP, this.toggleMap);
        EventBroadcaster.Instance.AddObserver(EventNames.JabubuEvents.MAP_FOUND, this.updateMapCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveAllObservers();
    }

    private void toggleMap()
    {
        mapToggle = !mapToggle;
        mapMenu.SetActive(mapToggle);
    }

    private void updateMapCount()
    {
        this.mapCount += 1;

        if (mapCount == 1)
        {
            mapBotRight.SetActive(true);
        }
        else if (mapCount == 2)
        {
            mapBotLeft.SetActive(true);
        }
        else if (mapCount == 3)
        {
            mapTopLeft.SetActive(true);
        }
        else if (mapCount == 4)
        {
            mapTopRight.SetActive(true);
            EventBroadcaster.Instance.PostEvent(EventNames.JabubuEvents.ALL_MAP_FOUND);
        }

        else if (mapCount == 5)
        {
            SceneManager.LoadScene("Credits");
        }
        this.mapCounter.SetText("Pieces found: " + mapCount + "/4");

        
    }
}
