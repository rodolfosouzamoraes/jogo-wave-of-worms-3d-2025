using UnityEngine;
using UnityEngine.InputSystem;

public class CanvasGameManager : MonoBehaviour
{
    public static CanvasGameManager Instance;
    public static QuestController Quests;
    public static InteractionsController Interactions;
    public static PainelEndGame EndGame;
    public static PainelMenu Menu;

    private void Awake()
    {
        if(Instance == null)
        {
            Quests = GetComponent<QuestController>();
            Interactions = GetComponent<InteractionsController>();
            idLanguage = DBMng.GetIdLanguage();
            EndGame = GetComponent<PainelEndGame>();
            Menu = GetComponent<PainelMenu>();
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }
    [SerializeField] GameObject[] mainPainels;
    private int idLanguage;
    public bool isGamePaused;

    public int LanguageGame
    {
        get { return idLanguage; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ActivePainelMenu();
    }

    public void ActivePainelMenu()
    {
        mainPainels[0].SetActive(true);
        mainPainels[1].SetActive(false);
        isGamePaused = true;
    }

    public void ActivePainelGame()
    {
        mainPainels[1].SetActive(true);
        mainPainels[0].SetActive(false);
        isGamePaused = false;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame(InputAction.CallbackContext context) { 
        if (context.performed == true)
        {
            if(isGamePaused == false)
            {
                ActivePainelMenu();
            }
            else
            {
                ActivePainelGame();
            }
        }
    }
}
