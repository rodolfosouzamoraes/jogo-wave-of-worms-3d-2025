using UnityEngine;

public class CanvasGameManager : MonoBehaviour
{
    public static CanvasGameManager Instance;
    public static QuestController Quests;
    public static InteractionsController Interactions;

    private void Awake()
    {
        if(Instance == null)
        {
            Quests = GetComponent<QuestController>();
            Interactions = GetComponent<InteractionsController>();
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
