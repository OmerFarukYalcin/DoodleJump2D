using UnityEngine;

namespace DoodleJump
{
    public class PlatformController : MonoBehaviour
    {
        [SerializeField] float jumpForce;
        Rigidbody2D rb2d;
        [SerializeField] Transform _pos;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.relativeVelocity.y <= 0)
            {
                rb2d = other.gameObject.GetComponent<Rigidbody2D>();
                if (rb2d != null)
                {
                    rb2d.velocity = CalculateVelocity(rb2d, jumpForce);

                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            float randomHorizontal = Random.Range(-5f, 5f);
            float distance = _pos.position.y - transform.position.y;
            //float vertical = 9f;
            if (other.gameObject.tag == "moveGO")
            {
                transform.position = RandomPosition(transform, randomHorizontal, distance);
            }
            if (other.gameObject.tag == "Platform")
            {
                Debug.Log("test");
                other.gameObject.transform.position = RandomPosition(transform, randomHorizontal, other.gameObject.transform.position.y);
            }
        }
        private Vector3 RandomPosition(Transform _pos, float x, float y)
        {
            return new Vector3(x, _pos.position.y + y, _pos.position.z);
        }

        private Vector2 CalculateVelocity(Rigidbody2D _rb, float _jump)
        {
            Vector2 velocity = rb2d.velocity;
            velocity.y = _jump;
            return velocity;
        }

    }
}
