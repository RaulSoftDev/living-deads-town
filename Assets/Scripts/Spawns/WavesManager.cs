using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    WaveSpawner wavesSpawner;
    public Text roundSign;
    public Animator uiRoundText;

    void Update()
    {
        wavesSpawner = GameObject.Find("WaveSpawner").GetComponent<WaveSpawner>();

        StartCoroutine(nextRound());
        StartCoroutine(roundText());
    }

    IEnumerator nextRound()
    {
        if (wavesSpawner.state == WaveSpawner.SpawnState.SPAWNING)
        {
            uiRoundText.SetBool("RoundUp", true);
            yield return new WaitForSeconds(2);
            uiRoundText.SetBool("RoundUp", false);
        }

        yield break;
    }

    IEnumerator roundText()
    {
        if (wavesSpawner.state == WaveSpawner.SpawnState.SPAWNING)
        {
            int roundCount = wavesSpawner.nextWave;
            roundCount++;
            roundSign.text = "Ronda " + roundCount;
            yield return new WaitForSeconds(4);
            roundSign.text = null;
        }

        yield break;
    }
}
