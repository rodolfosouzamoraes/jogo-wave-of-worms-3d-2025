using UnityEngine;
using UnityEngine.Events;

public class SupportAninamtionPlayer : MonoBehaviour
{
    public UnityEvent eventAnimation;

    public void ActiveEvent()
    {
        eventAnimation.Invoke();
    }
}
