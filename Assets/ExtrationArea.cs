using UnityEngine;
using UnityEngine.Events;

public class ExtrationArea : MonoBehaviour
{
    public UnityEvent eventAreaOn;
    public UnityEvent eventAreaOff;
    [SerializeField] GameObject extrationPoint;

    public GameObject GetExtrationPoint()
    {
        return extrationPoint;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Car"))
        {
            eventAreaOn?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Car"))
        {
            eventAreaOff?.Invoke();
        }
    }
}
