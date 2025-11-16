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
    private float totalWormsKilled;
    private float totalFluids;
    private float totalKm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalWormsKilled = 0;
        totalFluids = 0;
        totalKm = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowEndGame()
    {
        CalculateTime();
        txtWormsKilled.text = $"{totalWormsKilled}";
        txtTotalKm.text = $"{totalKm}Km";
        txtTotalFluids.text = $"{totalFluids}";
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

    public void IncrementFluids(float value)
    {
        totalFluids += value;
    }

    public void IncrementKM(float value)
    {
        totalKm += value;
    }
}
