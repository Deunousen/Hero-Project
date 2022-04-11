using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        Mover mover;

        void Awake() 
        {
            mover = FindObjectOfType<Mover>();
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        void Update() 
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }
        }

        void MoveToCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);

            if (hasHit)
            {
                mover.MoveTo(hit.point);
            }
        }
    }
}
