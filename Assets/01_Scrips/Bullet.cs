using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;
    public float timeToDestroy = 3;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(gameObject);
    }

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        Destroy(gameObject);
    //    }
    //    else if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        Enemy e = collision.gameObject.GetComponent<Enemy>();
    //        e.TakeDamage();
    //        Destroy(gameObject);
    //    }
    //}
}
