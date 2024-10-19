using UnityEngine;

namespace DoodleJump
{
    public class PlatformController : MonoBehaviour
    {
        // Jump force applied to the player when they collide with the platform.
        [SerializeField] private float jumpForce;

        // Cached reference to the player's Rigidbody2D.
        private Rigidbody2D rb2d;

        // Reference to the platform's position.
        [SerializeField] private Transform _pos;

        // This method is called when another collider makes contact with the platform.
        private void OnCollisionEnter2D(Collision2D other)
        {
            // Check if the object is falling (negative Y velocity).
            if (other.relativeVelocity.y <= 0)
            {
                // Get the Rigidbody2D component of the colliding object.
                rb2d = other.gameObject.GetComponent<Rigidbody2D>();

                // If the object has a Rigidbody2D, apply the calculated jump force.
                if (rb2d != null)
                {
                    rb2d.velocity = CalculateVelocity(jumpForce);
                }
            }
        }

        // This method is called when another collider enters the platform's trigger zone.
        private void OnTriggerEnter2D(Collider2D other)
        {
            float randomHorizontal = Random.Range(-5f, 5f);
            float distance = _pos.position.y - transform.position.y;

            // If the object tagged "moveGO" enters the trigger, reposition the platform.
            if (other.gameObject.tag == "moveGO")
            {
                transform.position = RandomPosition(transform, randomHorizontal, distance);
            }

            // If the object tagged "Platform" enters the trigger, reposition the platform.
            if (other.gameObject.tag == "Platform")
            {
                Debug.Log("Platform repositioned");
                other.gameObject.transform.position = RandomPosition(transform, randomHorizontal, other.gameObject.transform.position.y);
            }
        }

        // Returns a new random position for the platform based on horizontal and vertical offsets.
        private Vector3 RandomPosition(Transform _pos, float x, float y)
        {
            return new Vector3(x, _pos.position.y + y, _pos.position.z);
        }

        // Calculates and returns a new velocity for the Rigidbody2D, applying the jump force on the Y axis.
        private Vector2 CalculateVelocity(float _jump)
        {
            Vector2 velocity = rb2d.velocity;
            velocity.y = _jump;
            return velocity;
        }
    }
}
