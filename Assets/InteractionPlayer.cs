using UnityEngine;
using UnityEngine.Events;

public class InteractionPlayer : MonoBehaviour
{
    public UnityEvent eventsOn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            CanvasGameManager.Interactions.ShowInteractionKey(eventsOn);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            CanvasGameManager.Interactions.HideInteractionKey();
        }
    }
}
