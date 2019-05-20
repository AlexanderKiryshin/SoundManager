using UnityEngine;

namespace Assets.Scripts
{
    public class MoveObject:MonoBehaviour
    {
        public Vector2 speed;
       // private GameObject gameobject;
        float maxX, minX;

        void Start()
        {
            Time.fixedDeltaTime = 0.02f;
            minX = 0;
            maxX =Screen.width;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed.x, speed.y));
        }

        void Update()
        {
           
        }

        void FixedUpdate()
        {
           // gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Time.deltaTime * speed.x, Time.deltaTime * speed.y));
            //gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(Screen.width, transform.position.y, 0), 0.5f);
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
           // else if (transform.position.x < minX) transform.position = new Vector2(minX, transform.position.y);
        }
       /* public void Update()
        {
            gameobject.transform.
        }*/
    }
}
