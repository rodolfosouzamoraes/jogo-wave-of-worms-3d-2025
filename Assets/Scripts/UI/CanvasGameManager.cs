using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
            EndGame = GetComponent<PainelEndGame>();
            Menu = GetComponent<PainelMenu>();
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }
    [SerializeField] GameObject[] mainPainels;
    [SerializeField] GameObject map;
    public bool isGamePaused;

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

    public void PauseGame(InputAction.CallbackContext context) {
        if (EndGame.IsEndGame == true) return;

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

    public void Map(InputAction.CallbackContext context)
    {
        if (EndGame.IsEndGame == true || isGamePaused == true) return;
        if (context.performed == true)
        {
            map.SetActive(!map.activeSelf);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartGameInput(InputAction.CallbackContext context)
    {
        if (EndGame.IsEndGame == false) return;
        if (context.performed == true)
        {
            RestartGame();
        }
    }
}
