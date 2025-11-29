using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TerminalRadio : MonoBehaviour
{
    [SerializeField] GameObject radio;
    [SerializeField] GameObject terminal;
    [SerializeField] Scrollbar progressBar;
    [SerializeField] TextMeshProUGUI txtProgress;
    [SerializeField] TextMeshProUGUI txtPercent;
    [SerializeField] TextsGame TXTLoading;
    [SerializeField] TextsGame TXTExtrationCode;
    [SerializeField] TextsGame TXTFinished;
    [SerializeField] float speedLoading;
    [SerializeField] int maxCountExtrationCode;
    [SerializeField] GameObject extrationCode;
    public UnityEvent eventFinishedRadio;
    [SerializeField] private bool terminalActived = false;
    [SerializeField] private bool terminalFinished = false;
    [SerializeField] GameObject iconQuest;
    [SerializeField] GameObject iconTerminal;
    private int countExtrationCode = 0;

    public bool TerminalFinished
    {
        get { return terminalFinished; }
    }

    public bool TerminalActived
    {
        get { return terminalActived; }
    }

    private void Start()
    {
        ResetTerminal();
    }

    private void Update()
    {
        if (terminalActived == false) return;
        LoadingTerminal();
    }

    private void ResetTerminal()
    {
        progressBar.size = 0;
        txtPercent.text = $"{progressBar.size * 100}&";
        txtProgress.text = $"{TXTLoading.txtLanguage[DBMng.GetIdLanguage()]}";
    }
    
    private void LoadingTerminal()
    {
        progressBar.size += Time.deltaTime * speedLoading;
        if(progressBar.size >= 1)
        {
            progressBar.size = 1;
            terminalActived = false;
            txtProgress.text = $"{TXTExtrationCode.txtLanguage[DBMng.GetIdLanguage()]}";
            extrationCode.SetActive(true);
        }
    }

    public void EnableTerminalRadio()
    {
        radio.SetActive(true);
        iconQuest.SetActive(false);
        iconTerminal.SetActive(true);
        AudioMng.Instance.PlayAudioTerminal();
        Invoke("ActiveTerminal", 1f);
    }

    public void ActiveTerminal()
    {
        if (terminalFinished == true) return;

        AudioMng.Instance.PlayAudioExtrationPoint();

        ResetTerminal();

        extrationCode.SetActive(false);

        countExtrationCode++;
        if (countExtrationCode == maxCountExtrationCode)
        {
            FinishedTerminal();
        }
        else
        {
            terminal.SetActive(true);
            terminalActived = true;
        }            
    }

    private void FinishedTerminal()
    {
        terminalFinished = true;
        txtProgress.text = $"{TXTFinished.txtLanguage[DBMng.GetIdLanguage()]}";
        txtPercent.gameObject.SetActive(false);
        progressBar.gameObject.SetActive(false);
        AudioMng.Instance.PlayAudioAmbient();
        eventFinishedRadio.Invoke();
    }
}
