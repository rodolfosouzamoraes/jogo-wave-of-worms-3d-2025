using UnityEngine;

public class RecoverPlayerLife : MonoBehaviour
{
    [SerializeField] float valueRecover;
    bool isAreaColision;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
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
