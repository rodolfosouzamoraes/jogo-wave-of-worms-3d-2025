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
    private int extrationAreaCurrentIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject area in allExtrationArea) { 
            area.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
