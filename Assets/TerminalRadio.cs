using UnityEngine;

public class TerminalRadio : MonoBehaviour
{
    [SerializeField] GameObject radio;
    [SerializeField] GameObject terminal;

    public void EnableTerminalRadio()
    {
        radio.SetActive(true);
        Invoke("ActiveTerminal", 1f);
    }

    private void ActiveTerminal()
    {
        terminal.SetActive(true);
    }
}
