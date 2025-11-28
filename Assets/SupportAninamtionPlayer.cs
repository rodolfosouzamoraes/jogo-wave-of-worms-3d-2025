using UnityEngine;
using UnityEngine.Events;

public class SupportAninamtionPlayer : MonoBehaviour
{

    public void EventInstantiateProjetil()
    {
        PlayerManager.Fire.InstantiateProjetil();
    }

    public void EventSinkTheSand()
    {
        PlayerManager.Damage.SinkInTheSand();
    }

    public void AudioStepsSand()
    {
        AudioMng.Instance.PlayAudioStepsSand();
    }
}
