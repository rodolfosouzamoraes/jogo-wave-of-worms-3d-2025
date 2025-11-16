using UnityEngine;

public class WormFluid : MonoBehaviour
{
    [SerializeField] GameObject fluid;
    [SerializeField] GameObject particleFluid;
    private bool isCollectFluid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int sizeFluid = new System.Random().Next(1, 4);
        transform.localScale *= sizeFluid;
        particleFluid.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isCollectFluid == true)
        {
            fluid.transform.localScale -= new Vector3(0.85f * Time.deltaTime, 0.85f * Time.deltaTime, 0.85f * Time.deltaTime);
            
            CanvasGameManager.EndGame.IncrementFluids(0.85f * Time.deltaTime);
            if (fluid.transform.localScale.y <= 0) { 
                Destroy(gameObject);            
            }
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            isCollectFluid = true;
            particleFluid.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            isCollectFluid = false;
            particleFluid.SetActive(false);
        }
    }
}
