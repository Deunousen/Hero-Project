using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Combat;

namespace RPG.Movement
{

    public class Mover : MonoBehaviour
    {

        [SerializeField] Transform target;

        NavMeshAgent navMeshAgent;
        Ray lastRay;
        
        void Start() 
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {

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

        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<Fighter>().Cancel();
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        public void Stop()
        {
            navMeshAgent.isStopped = true;
        }

        void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);  // convert global velocity to local velocity
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }

        
    }
}

