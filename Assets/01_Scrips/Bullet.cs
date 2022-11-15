using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;
    public float timeToDestroy = 3;
    public AudioClip explosionSound;

    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {

            EnemyA d = other.gameObject.GetComponent<EnemyA>();
            d.TakeDamageB();
            Destroyed();

        }
    }

    void Destroyed()
    {
        //explosionAS.PlayOneShot(explosionSound);
        
        GameManager.instance.PlaySFX(explosionSound);
        Destroy(gameObject);
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
