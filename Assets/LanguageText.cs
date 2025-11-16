using TMPro;
using UnityEngine;

public class LanguageText : MonoBehaviour
{
    [SerializeField] TextsGame text;
    private TextMeshProUGUI textMeshPro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        int idLanguage = DBMng.GetIdLanguage();
        textMeshPro.text = text.txtLanguage[idLanguage];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
