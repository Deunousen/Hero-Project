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

        Transform target;
        Animator animator;

        void Start() 
        {
            animator = GetComponent<Animator>();
        }

        void Update() 
        {
            if (target == null) return;

            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }


        }

        void AttackBehaviour()
        {
            animator.SetTrigger("attack");
        }

        bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
            
        }

        public void Cancel()
        {
            target = null;
        }

        // animation event, not called on any script
        void Hit()
        {

        }
    }
}
