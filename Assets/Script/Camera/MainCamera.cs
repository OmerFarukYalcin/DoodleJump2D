using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodleJump
{
    public class MainCamera : MonoBehaviour
    {
        [SerializeField] float followSpeed;
        [SerializeField] Transform target;
        void Update()
        {
            if (target != null)
            {
                if (target.position.y > transform.position.y)
                {
                    Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
                    transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
                }
            }
        }
    }
}
