using UnityEngine;

namespace Assets.Scripts
{
    public class MoveObject:MonoBehaviour
    {
        public Vector2 speed;
        float maxX, minX;

        void Start()
        {
            Time.fixedDeltaTime = 0.02f;
            minX = 0;
            maxX =Screen.width;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed.x, speed.y));
        }
        void FixedUpdate()
        {
            if (transform.position.x > maxX)
            {
                transform.position = new Vector2(maxX, transform.position.y);
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2*speed.x, 0));
            }

            if (transform.position.x < minX)
            {
                transform.position = new Vector2(minX, transform.position.y);
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2 * speed.x, 0));
            }
        }
    }
}
