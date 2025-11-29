using TMPro;
using UnityEngine;

public class TextUISettings : MonoBehaviour
{
    [SerializeField] TextsGame language;
    private TextMeshProUGUI txtUI;

    void Start()
    {
        SetText();
    }

    public void SetText()
    {
        txtUI = GetComponent<TextMeshProUGUI>();
        txtUI.text = $"{language.txtLanguage[DBMng.GetIdLanguage()]}";
    }

    private void OnEnable()
    {
        SetText();
    }
}
