using UnityEngine;

namespace RPG.Combat
{

    public class Health : MonoBehaviour 
    {
        [SerializeField] float healthPoints = 100;
        
        bool isDead;

        public bool IsDead()
        {
            return isDead;
        }

        public void TakeDamage(float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0);
            print(healthPoints);
        }

        void Update() 
        {
            if (healthPoints <= 0 && !isDead)
            {
                SetDeathAnimation();
            }
        }

        void SetDeathAnimation()
        {
            GetComponent<Animator>().SetTrigger("die");
            isDead = true;
        }
    }


}