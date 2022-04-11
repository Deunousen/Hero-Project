using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class FollowCamera : MonoBehaviour
    {

        [SerializeField] Transform target;

        void Start()
        {
            
        }

        void LateUpdate()                                       // lateupdate used instead of update to prevent potential jitter between camera and player moving
        {
            transform.position = target.position;
        }
    }
}

