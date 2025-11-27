using System;
using System.Collections;
using TMPro;
using Unity.Cinemachine.Samples;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarMng : MonoBehaviour
{
    public static CarMng Instance;
    public static SimpleCarController CarController;
    private void Awake()
    {
        if (Instance == null)
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
    [SerializeField] GameObject antena;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] MeshRenderer meshLamp;
    [SerializeField] Material[] materialsLampOn;
    [SerializeField] Material[] materialsLampOff;
    [SerializeField] Quests[] questCar;
    [SerializeField] TextMeshProUGUI txtFluids;
    private float totalFluids;
    private float totalKm;
    private bool enableExitCar = false;

    public Rigidbody Rigidbody
    {
        get { return rigidbody; }
    }

    public float TotalFluids
    {
        get { return totalFluids; }
    }

    public float TotalKm
    {
        get { return totalKm; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalFluids = 0;
        totalKm = 0;
        txtFluids.text = $"{Math.Round(totalFluids, 2)}L";
    }

    // Update is called once per frame
    void Update()
    {
        if (CanvasGameManager.Instance.isGamePaused == true)
        {
            rigidbody.linearVelocity = Vector3.zero;
            return;
        }
        antena.transform.LookAt(
            new Vector3(
                ExtrationMng.Instance.ExtrationAreaCurrent.transform.position.x,
                antena.transform.position.y,
                ExtrationMng.Instance.ExtrationAreaCurrent.transform.position.z
            )
        );
    }

    public void EnterCar()
    {
        //Verificar se ao entrar ele completou a quest de entrar no carro
        if (CanvasGameManager.Quests.IsCurrentQuests(questCar[0].idQuest)) {
            CanvasGameManager.Quests.NextQuest(questCar[0].idQuest);
        }            

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
        //Verificar se ao entrar ele completou a quest de sair do carro
        if (CanvasGameManager.Quests.IsCurrentQuests(questCar[1].idQuest))
        {
            CanvasGameManager.Quests.NextQuest(questCar[1].idQuest);
        }

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

    public void ActiveLamp()
    {
        meshLamp.materials = materialsLampOn;
    }

    public void DesactiveLamp()
    {
        meshLamp.materials = materialsLampOff;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("ExtrationArea"))
        {
            ActiveLamp();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("ExtrationArea"))
        {
            DesactiveLamp();
        }
    }
    public void IncrementFluids(float value)
    {
        totalFluids += value;
        txtFluids.text = $"{Math.Round(totalFluids, 2)}L";
    }

    public void IncrementKM(float value)
    {
        totalKm += value;
    }
}
