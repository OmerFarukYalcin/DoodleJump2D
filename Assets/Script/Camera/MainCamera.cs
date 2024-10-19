using UnityEngine;

namespace DoodleJump
{
    public class MainCamera : MonoBehaviour
    {
        // Speed at which the camera follows the target. Default is set to 5f.
        [SerializeField] private float followSpeed = 5f;

        // The target that the camera will follow. Typically the player character.
        [SerializeField] private Transform target;

        private void Update()
        {
            // If there is no target or the target's Y position is lower than the camera's, do nothing.
            if (target == null || target.position.y <= transform.position.y) return;

            // Calculate the new position for the camera based on the target's Y position.
            Vector3 targetPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);

            // Smoothly move the camera towards the target position using Slerp (Spherical Linear Interpolation).
            transform.position = Vector3.Slerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
