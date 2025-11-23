using System;
using TMPro;
using UnityEngine;

public class PainelEndGame : MonoBehaviour
{
    [SerializeField] GameObject pnlEndGame;
    [SerializeField] TextMeshProUGUI txtTimer;
    [SerializeField] TextMeshProUGUI txtWormsKilled;
    [SerializeField] TextMeshProUGUI txtTotalFluids;
    [SerializeField] TextMeshProUGUI txtTotalKm;
    private float secondsInGame;
    [SerializeField] private float totalWormsKilled;
    private bool isEndGame;

    public bool IsEndGame
    {
        get { return isEndGame; }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalWormsKilled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowEndGame()
    {
        isEndGame = true;
        CalculateTime();
        txtWormsKilled.text = $"{totalWormsKilled}";
        txtTotalKm.text = $"{Math.Round(CarMng.Instance.TotalKm/100,2)}Km";
        txtTotalFluids.text = $"{Math.Round(CarMng.Instance.TotalFluids,2)}L";
        pnlEndGame.SetActive(true);
    }

    private void CalculateTime()
    {
        secondsInGame = Time.timeSinceLevelLoad;

        TimeSpan time = TimeSpan.FromSeconds(secondsInGame);

        if (time.TotalHours >= 1)
        {
            // Mostra horas, minutos e segundos
            txtTimer.text = time.ToString(@"hh\:mm\:ss");
        }
        else
        {
            // Mostra apenas minutos e segundos
            txtTimer.text = time.ToString(@"mm\:ss");
        }
    }

    public void IncrementWormsKilled()
    {
        totalWormsKilled++;
    }
    
    public void GameOver()
    {
        isEndGame = true;
    }
}
