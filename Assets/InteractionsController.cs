using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InteractionsController : MonoBehaviour
{
    [SerializeField] GameObject interactionKey;
    private UnityEvent eventsInteration;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HideInteractionKey();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowInteractionKey(UnityEvent events)
    {
        interactionKey.SetActive(true);
        eventsInteration = events;
    }

    public void HideInteractionKey() 
    { 
        interactionKey.SetActive(false);
        eventsInteration = null;
    }

    public void InteractionKey(InputAction.CallbackContext context) 
    {
        if (interactionKey.activeSelf == true) {
            Debug.Log("Interagiu!!!");
            eventsInteration.Invoke();
            HideInteractionKey();
        }        
    }
}
