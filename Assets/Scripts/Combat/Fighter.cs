using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {

        [SerializeField] float weaponRange = 2;
        [SerializeField] float weaponDamage = 10;
        [SerializeField] float timeBetweenAttacks = 1.5f;

        Health target;
        Animator animator;

        float timeSinceLastAttack = 0;

        void Start() 
        {
            animator = GetComponent<Animator>();
        }

        void Update() 
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;
            if (target.IsDead()) return;

            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.transform.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }


        }

        void AttackBehaviour()
        {
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                animator.SetTrigger("attack");
                timeSinceLastAttack = 0;
            }
        }

        bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.transform.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.GetComponent<Health>();
            
        }

        public void Cancel()
        {
            GetComponent<Animator>().SetTrigger("stopAttacking");
            target = null;
        }

        // animation event, not called on any script
        void Hit()
        {
            if (!target) return;
            target.TakeDamage(weaponDamage);
        }
    }
}
