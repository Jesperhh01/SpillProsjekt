using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] 
    public int maxHealth; 
    private int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(int damage)                                                
    {                                                                                 
        currentHealth -= damage;                                                      
        Debug.Log($"Entity took {damage} damage! Remaining health: {currentHealth}"); 
                                                                                    
        if (currentHealth <= 0 && gameObject.CompareTag("Player"))                                                       
        {                                                                             
            Die();                                                                    
        }
        else if (currentHealth <= 0 && gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy has died");
            EnemyDie();
        }
    }                                                                                 
                                                                                    
    void Die()                                                                        
    {                                                                                 
        Debug.Log("Player died");                                                     
        SceneManager.LoadScene("GameOver");                                           
    }    
    
    void EnemyDie()
    { 
        Destroy(gameObject);
    }
}
