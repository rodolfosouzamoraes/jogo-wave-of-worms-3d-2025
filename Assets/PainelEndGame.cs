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
    [SerializeField] private float totalFluids;
    [SerializeField] private float totalKm;
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
        Debug.Log($"{Math.Round(totalKm / 1000, 2)}Km");
    }

    public void ShowEndGame()
    {
        CalculateTime();
        txtWormsKilled.text = $"{totalWormsKilled}";
        txtTotalKm.text = $"{Math.Round(totalKm/1000,2)}Km";
        txtTotalFluids.text = $"{Math.Round(totalFluids,2)}L";
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
