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
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    [SerializeField] GameObject interactionCar;
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
        CarController.EnableCar = true;
        PlayerManager.Instance.gameObject.transform.SetParent(transform);
        PlayerManager.Instance.gameObject.SetActive(false);
        CameraManager.Instance.ChangeTarget(gameObject.transform);
        interactionCar.SetActive(false);
        enableExitCar = false;
        StartCoroutine(EnableExitCar());
    }

    public void ExitCar()
    {
        CarController.EnableCar = false;
        PlayerManager.Instance.gameObject.transform.SetParent(null);
        PlayerManager.Instance.gameObject.SetActive(true);
        CameraManager.Instance.ChangeTarget(PlayerManager.Instance.gameObject.transform);
    }

    private IEnumerator EnableExitCar()
    {
        yield return new WaitForSeconds(0.15f);
        enableExitCar = true;
    }

    public void ExitCar(InputAction.CallbackContext context)
    {
        Debug.Log("Entrei aqui 1");
        if (context.performed && CarController.EnableCar == true && enableExitCar == true)
        {
            Debug.Log("Entrei aqui 2");
            ExitCar();
        }

        if(context.canceled && CarController.EnableCar == false)
        {
            Debug.Log("Entrei aqui 3");
            interactionCar.SetActive(true);
        }
    }

}
