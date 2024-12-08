using UnityEngine;

namespace DefaultNamespace
{
    public class playerAttack
    {
        private GameObject attackArea = default;
        private bool attack = false;
        private float timeToAttack = 0.25f;

        private float timer = 0;

        void start()
        {
            
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack(); 
            }

            if (attack)
            {
                timer+=Time.deltaTime;
                if (timer >= timeToAttack)
                {
                    timer = 0;
                    attack = false; 
                    attackArea.SetActive(attack);
                }
            }
        }

        void Attack()
        {
            attack = true; 
            attackArea.SetActive(attack);
            Debug.Log("attacking");
        }
    }
}