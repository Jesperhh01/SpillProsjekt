using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
   public int maxHealth = 100; 
   private int currentHealth;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Player took {damage} damage! Remaining health: {currentHealth}");
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        Debug.Log("Player died");
        SceneManager.LoadScene("GameOver");
    }


}
