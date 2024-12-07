using System;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Sjekker om det er spilleren
        {
            Debug.Log("Player hit the spike! Game Over.");
            GameOver();
        }    
    }
    
    void GameOver()
    {
        // Dette er hva som skjer når spilleren treffer en spiker
        // For nå logger vi bare en melding. Du kan senere legge til:
        // 1. Bytte scene til en Game Over-skjerm.
        // 2. Tilbakestille nivået.
        // 3. Stoppe spillet.

        // Eksempel: Laste Game Over-scene (forutsetter en scene med navnet "GameOver")
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
