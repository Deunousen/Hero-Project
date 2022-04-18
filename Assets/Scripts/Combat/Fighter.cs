using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {

        [SerializeField] float weaponRange = 2;

        Transform target;

        void Update() 
        {
            if (target != null)
            {
                float dist = Vector3.Distance(transform.position, target.position); 
                if (dist < weaponRange) 
                {
                    GetComponent<Mover>().Stop();
                }
                else
                {
                    GetComponent<Mover>().MoveTo(target.position);
                }
            }
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }
    }
}
