using UnityEngine;

namespace DefaultNamespace
{
    public class AttackArea :MonoBehaviour
    {
        public void OnTriggerEnter(Collider2D collider)
        {
            if (collider.GetComponent<health>() != null)
            {
                
            }
        }
    }
}