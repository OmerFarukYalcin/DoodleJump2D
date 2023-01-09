using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

namespace DoodleJump
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float velocity;
        Rigidbody2D rb2d;
        Vector2 baseScale;
        [SerializeField] Camera cam;
        public static int score;
        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
            baseScale = transform.localScale;
        }

        private void Update()
        {
            //float x = Input.GetAxis("Horizontal");
            float x = CrossPlatformInputManager.GetAxis("Horizontal");
            rb2d.velocity = CalculateVelocity(x);
            switch (rb2d.velocity.x)
            {
                case > 0:
                    transform.localScale = baseScale;
                    break;
                case < 0:
                    transform.localScale = new Vector2(-baseScale.x, baseScale.y);
                    break;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Platform")
            {
                score += Random.Range(10, 50);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Death")
            {
                SceneManager.LoadScene(0);
                score = 0;
            }
        }
        Vector2 CalculateVelocity(float _x)
        {
            return new Vector2(_x * velocity, rb2d.velocity.y);
        }
    }
}
