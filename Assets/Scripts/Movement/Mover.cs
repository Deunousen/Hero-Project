using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {

        [SerializeField] Transform target;
        
        

        NavMeshAgent navMeshAgent;
        Ray lastRay;
        

        // Update is called once per frame
        void Update()
        {
            // if (Input.GetMouseButton(0))
            // {
            //     MoveToCursor();
            // }
            
            UpdateAnimator();
            
        }

        

        void MoveToCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);

            if (hasHit)
            {
                MoveTo(hit.point);
            }
        }

        public void MoveTo(Vector3 destination)
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.destination = destination;
        }

        void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);  // convert global velocity to local velocity
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }

        
    }
}

