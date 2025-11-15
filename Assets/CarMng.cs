using System.Collections;
using Unity.Cinemachine.Samples;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarMng: MonoBehaviour
{
    public static CarMng Instance;
    public static SimpleCarController CarController;
    private void Awake()
    {
        if(Instance == null)
        {
            CarController = GetComponent<SimpleCarController>();
            CarController.EnableCar = false;
            driver.SetActive(false);
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    [SerializeField] GameObject interactionCar;
    [SerializeField] GameObject driver;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] Quests questCar;
    private bool enableExitCar = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnterCar()
    {
        //Verificar se ao entrar ele completou a quest do carro
        if (CanvasGameManager.Quests.IsCurrentQuests(questCar.idQuest))
            CanvasGameManager.Quests.NextQuest(questCar.idQuest);

        CarController.EnableCar = true;
        PlayerManager.Instance.gameObject.transform.SetParent(transform);
        PlayerManager.Instance.gameObject.SetActive(false);
        CameraManager.Instance.ChangeTarget(gameObject.transform);
        interactionCar.SetActive(false);
        enableExitCar = false;
        driver.SetActive(true);
        StartCoroutine(EnableExitCar());
    }

    public void ExitCar()
    {
        CarController.EnableCar = false;
        PlayerManager.Instance.gameObject.transform.SetParent(null);
        PlayerManager.Instance.gameObject.SetActive(true);
        CameraManager.Instance.ChangeTarget(PlayerManager.Instance.gameObject.transform);
        driver.SetActive(false);
    }

    private IEnumerator EnableExitCar()
    {
        yield return new WaitForSeconds(0.15f);
        enableExitCar = true;
    }

    public void ExitCar(InputAction.CallbackContext context)
    {
        if (context.performed && CarController.EnableCar == true && enableExitCar == true && rigidbody.linearVelocity.magnitude <= 0.05f)
        {
            ExitCar();
        }

        if(context.canceled && CarController.EnableCar == false )
        {
            interactionCar.SetActive(true);
        }
    }

}
