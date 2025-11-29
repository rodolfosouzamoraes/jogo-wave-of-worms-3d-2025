using TMPro;
using UnityEngine;

public class TextUISettings : MonoBehaviour
{
    [SerializeField] TextsGame language;
    private TextMeshProUGUI txtUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
