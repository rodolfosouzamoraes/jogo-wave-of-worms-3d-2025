using UnityEngine;

public class RecoverPlayerLife : MonoBehaviour
{
    [SerializeField] float valueRecover;
    bool isAreaColision;

    void Update()
    {
        if(isAreaColision == true)
            PlayerManager.Damage.IncrementLife(valueRecover);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            isAreaColision = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            isAreaColision = false;
        }
    }
}
