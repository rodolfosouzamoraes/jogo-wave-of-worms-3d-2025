using UnityEngine;

public class WormFluid : MonoBehaviour
{
    [SerializeField] GameObject wormFluid;
    [SerializeField] GameObject particleFluid;
    private bool isCollectFluid;
    private bool isFluidsDone;
    private float maxScale;
    void Start()
    {
        int sizeFluid = new System.Random().Next(1, 4);
        maxScale = sizeFluid;
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        particleFluid.SetActive(false);
    }

    void Update()
    {
        if (isCollectFluid == true)
        {
            transform.localScale -= new Vector3(0.85f * Time.deltaTime, 0.85f * Time.deltaTime, 0.85f * Time.deltaTime);

            CarMng.Instance.IncrementFluids((0.85f * Time.deltaTime) / 100);
            if (transform.localScale.y <= 0.1f)
            {
                Destroy(wormFluid);
            }
        }
        else if (isFluidsDone == false && isCollectFluid == false) {
            transform.localScale += new Vector3(0.95f * Time.deltaTime, 0.95f * Time.deltaTime, 0.95f * Time.deltaTime);
            if(transform.localScale.x>= maxScale)
            {
                isFluidsDone = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            isCollectFluid = true;
            isFluidsDone = true;
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
