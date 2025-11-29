using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InteractionsController : MonoBehaviour
{
    [Header("Config Interaction Key")]
    [SerializeField] GameObject interactionKey;
    private UnityEvent eventsInteration;

    [Header("Config Extration Code")]
    [SerializeField] GameObject interactionExtrationCode;
    [SerializeField] GameObject itemExtrationCode;
    [SerializeField] Transform contentExtrationCode;
    private List<GameObject> listCodeExtration;
    private int countingHitsCode;
    private List<int> codeExtrationCurrent;
    private UnityEvent eventsExtrationCode;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        listCodeExtration = new List<GameObject>();
        countingHitsCode = 0;
        HideInteractionKey();
    }

    public void ShowInteractionKey(UnityEvent events)
    {
        interactionKey.SetActive(true);
        eventsInteration = events;
    }

    public void HideInteractionKey() 
    { 
        interactionKey.SetActive(false);
        eventsInteration = null;
    }

    /// <summary>
    /// Toda vez que o jogador se aproxima do objeto de interação e interage clicando na tecla E, ele executa esse método
    /// Ele invoca os eventos provenientes do objeto que foi interagido.
    /// </summary>
    public void InteractionKey(InputAction.CallbackContext context) 
    {
        if (interactionKey.activeSelf == true) {
            Debug.Log("Interagiu!!!");
            eventsInteration.Invoke();
            HideInteractionKey();
        }        
    }

    /// <summary>
    /// Exibe o painel de código de extração com as imagens do código em sequência
    /// </summary>
    /// <param name="codeExtration">O código gerado</param>
    /// <param name="eventsExtrationCode">Os eventos após acertar a sequencia de códigos</param>
    public void ShowExtrationCode(List<int> codeExtration, UnityEvent eventsExtrationCode)
    {
        codeExtrationCurrent = codeExtration;
        countingHitsCode = 0;
        this.eventsExtrationCode = eventsExtrationCode;

        foreach (GameObject go in listCodeExtration) { 
            Destroy(go);
        }
        listCodeExtration.Clear();

        foreach (int code in codeExtrationCurrent) {
            GameObject newCode = Instantiate(itemExtrationCode, contentExtrationCode);
            newCode.GetComponent<ItemExtrationCode>().ConfigureItem(code);
            listCodeExtration.Add(newCode);
        }

        interactionExtrationCode.SetActive(true);
    }

    public void UpCode(InputAction.CallbackContext context)
    {
        if (context.performed && interactionExtrationCode.activeSelf == true)
        {
            CheckCode(0);
        }
    }
    public void DownCode(InputAction.CallbackContext context)
    {
        if (context.performed && interactionExtrationCode.activeSelf == true)
        {
            CheckCode(2);
        }
    }
    public void LeftCode(InputAction.CallbackContext context)
    {
        if (context.performed && interactionExtrationCode.activeSelf == true)
        {
            CheckCode(3);
        }
    }
    public void RightCode(InputAction.CallbackContext context)
    {
        if (context.performed && interactionExtrationCode.activeSelf == true)
        {
            CheckCode(1);
        }
    }

    /// <summary>
    /// Verifica se a tecla precionada corresponde ao código atual que o jogador deve acertar.
    /// Se o jogador acertar o código, é incrementado o acerto na variável para poder verificar o próximo código quando precionado
    /// Executa o evento quando todos os códigos forem acertados sequencialmente.
    /// Se o jogador errar o código, reinicia a sequencia.
    /// </summary>
    /// <param name="code"></param>
    private void CheckCode(int code)
    {
        AudioMng.Instance.PlayAudioClickUI();
        if (countingHitsCode == listCodeExtration.Count) return;
        var item = listCodeExtration[countingHitsCode].GetComponent<ItemExtrationCode>();
        if (item.Code == code)
        {
            item.ActiveCode();
            countingHitsCode++;
            if (countingHitsCode == listCodeExtration.Count)
            {
                CompleteCode();
            }
        }
        else
        {
            foreach (var itemCode in listCodeExtration)
            {
                itemCode.GetComponent<ItemExtrationCode>().DesactiveCode();
                countingHitsCode = 0;
            }
        }
    }

    public void HideExtrationCode()
    {
        interactionExtrationCode.SetActive(false);
    }

    private void CompleteCode()
    {
        Debug.Log("Completou o código de extração!!!");
        eventsExtrationCode.Invoke();
        Invoke("HideExtrationCode",1);
    }
}
