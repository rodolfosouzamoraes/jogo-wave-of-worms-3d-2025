using UnityEngine;
using static Unity.VisualScripting.Icons;

public class PainelMenu : MonoBehaviour
{
    [SerializeField] GameObject[] selectLanguage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int idLanguage = DBMng.GetIdLanguage();
        ChangeLanguage(idLanguage);
    }

    
    public void ChangeLanguage(int id)
    {
        foreach (GameObject go in selectLanguage)
        {
            go.SetActive(false);
        }
        selectLanguage[id].SetActive(true);

        DBMng.SaveLanguage(id);

        var allText = FindObjectsByType<TextUISettings>(FindObjectsSortMode.None);
        foreach(TextUISettings txt in allText)
        {
            txt.SetText();
        }

    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
