using UnityEngine;

public class FootPlayer : MonoBehaviour
{
    [SerializeField] GameObject particleBlood;
    private GameObject enemyCurrent;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            if (enemyCurrent == null) {
                enemyCurrent = other.gameObject;
                particleBlood.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            if (enemyCurrent == other.gameObject)
            {
                enemyCurrent = null;
                particleBlood.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (enemyCurrent != null)
        {
            particleBlood.transform.LookAt(enemyCurrent.transform.position);
        }
        else
        {
            particleBlood.SetActive(false);
        }
    }
}
