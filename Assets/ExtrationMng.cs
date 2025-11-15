using UnityEngine;

public class ExtrationMng : MonoBehaviour
{
    public static ExtrationMng Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }
    [SerializeField] GameObject[] allExtrationArea;
    private GameObject extrationAreaCurrent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject area in allExtrationArea) { 
            area.SetActive(false);
        }
    }

    public void SetExtrationAreaCurrent(GameObject area)
    {
        extrationAreaCurrent = area;
    }

    public Transform ExtrationAreaCurrent
    {
        get {  return extrationAreaCurrent.transform; }
    }
}
