using UnityEngine;
using UnityEngine.UI;

public class ItemExtrationCode : MonoBehaviour
{
    [SerializeField] Image imgCode;
    [SerializeField] GameObject imgCodeCorrect;
    [SerializeField] Sprite[] iconsCode;
    private int code;

    public int Code
    {
        get { return code; }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DesactiveCode();
    }

    public void ConfigureItem(int itemCode)
    {
        code = itemCode;
        imgCode.sprite = iconsCode[code];
    }

    public void ActiveCode()
    {
        imgCodeCorrect.SetActive(true);
    }

    public void DesactiveCode()
    {
        imgCodeCorrect.SetActive(false);
    }
}
