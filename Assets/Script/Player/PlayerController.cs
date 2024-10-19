using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

namespace DoodleJump
{
    public class PlayerController : MonoBehaviour
    {
        // Horizontal movement speed for the player.
        [SerializeField] private float velocity;

        // Reference to the Rigidbody2D component for physics calculations.
        private Rigidbody2D rb2d;

        // Original scale of the player object for flipping the sprite.
        private Vector2 baseScale;

        // Reference to the camera.
        [SerializeField] private Camera cam;

        // Static variable to track the player's score.
        public static int score;

        private void Awake()
        {
            // Cache the Rigidbody2D and original scale of the player object.
            rb2d = GetComponent<Rigidbody2D>();
            baseScale = transform.localScale;
        }

        private void Update()
        {
            // Get the horizontal input from the CrossPlatformInputManager.
            float x = CrossPlatformInputManager.GetAxis("Horizontal");

            // Set the player's velocity based on the horizontal input.
            rb2d.velocity = CalculateVelocity(x);

            // Flip the player sprite based on the movement direction.
            if (rb2d.velocity.x > 0)
            {
                transform.localScale = baseScale;  // Moving right, keep the original scale.
            }
            else if (rb2d.velocity.x < 0)
            {
                transform.localScale = new Vector2(-baseScale.x, baseScale.y);  // Moving left, flip the sprite horizontally.
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            // If the player collides with a platform, increase the score by a random value between 10 and 50.
            if (other.gameObject.tag == "Platform")
            {
                score += Random.Range(10, 50);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // If the player collides with an object tagged "Death", reset the game and score.
            if (other.gameObject.tag == "Death")
            {
                SceneManager.LoadScene(0);  // Reload the current scene (index 0).
                score = 0;  // Reset the score to 0.
            }
        }

        // Calculates the player's velocity based on the horizontal input.
        private Vector2 CalculateVelocity(float _x)
        {
            return new Vector2(_x * velocity, rb2d.velocity.y);
        }
    }
}
