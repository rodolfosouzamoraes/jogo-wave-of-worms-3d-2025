using UnityEngine;

public class PainelMenu : MonoBehaviour
{
    [SerializeField] GameObject[] selectLanguage;

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
