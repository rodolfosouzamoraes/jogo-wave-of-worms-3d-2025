using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExtrationPoint : MonoBehaviour
{
    private List<int> extrationCode; // 0 - CIMA, 1 - Direita, 2 - Baixo, 3 - Esquerda
    [SerializeField] UnityEvent eventsExtrationCode;
    [SerializeField] GameObject interactionKey;

    void Start()
    {
        extrationCode = new List<int>();
    }

    /// <summary>
    /// Gera um código aleatório
    /// </summary>
    public void GenerateCode()
    {
        extrationCode.Clear();
        int sizeCode = new System.Random().Next(4, 11);
        for (int i = 0; i < sizeCode; i++)
        {
            int code = new System.Random().Next(0, 4);
            extrationCode.Add(code);
        }

        CanvasGameManager.Interactions.ShowExtrationCode(extrationCode, eventsExtrationCode);
    }

    private void OnDisable()
    {
        interactionKey.SetActive(true);
    }
}
