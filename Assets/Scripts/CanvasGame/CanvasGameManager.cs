using UnityEngine;

public class CanvasGameManager : MonoBehaviour
{
    public static CanvasGameManager Instance;
    public static QuestController Quests;
    public static InteractionsController Interactions;
    public static PainelEndGame EndGame;

    private void Awake()
    {
        if(Instance == null)
        {
            Quests = GetComponent<QuestController>();
            Interactions = GetComponent<InteractionsController>();
            idLanguage = DBMng.GetIdLanguage();
            EndGame = GetComponent<PainelEndGame>();
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    private int idLanguage;

    public int LanguageGame
    {
        get { return idLanguage; }
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
