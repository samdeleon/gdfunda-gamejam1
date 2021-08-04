using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    public LayerMask interactableLayerMask;
    [SerializeField] private Camera mainCamera;
    public Interactable interactable;
    private bool allMapFound = false;

    // Start is called before the first frame update
    void Start()
    {
        allMapFound = false;
        EventBroadcaster.Instance.AddObserver(EventNames.JabubuEvents.ALL_MAP_FOUND, this.treasureReady);
    }
    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveAllObservers();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, 2, interactableLayerMask))
        {   
            if(hit.collider.GetComponent<Interactable>() != false)
            {   
                if(interactable == null || interactable.ID != hit.collider.GetComponent<Interactable>().ID)
                {
                    interactable = hit.collider.GetComponent<Interactable>();
                }
                EventBroadcaster.Instance.PostEvent(EventNames.JabubuEvents.ON_HOVER_MAP);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (interactable.getInteractableType() == "mapPiece")
                    {
                        EventBroadcaster.Instance.PostEvent(EventNames.JabubuEvents.ON_INTERACT);
                        EventBroadcaster.Instance.PostEvent(EventNames.JabubuEvents.MAP_FOUND);

                        interactable.OnInteract();
                    }

                    else if (interactable.getInteractableType() == "treasure" && allMapFound)
                    {
                        EventBroadcaster.Instance.PostEvent(EventNames.JabubuEvents.ON_INTERACT);
                        EventBroadcaster.Instance.PostEvent(EventNames.JabubuEvents.MAP_FOUND);

                        interactable.OnInteract();
                    }
                }
            }
            
        }
        else
        {
            EventBroadcaster.Instance.PostEvent(EventNames.JabubuEvents.NOT_HOVER_MAP);
        }
    }

    private void treasureReady()
    {
        this.allMapFound = true;
    }

}
