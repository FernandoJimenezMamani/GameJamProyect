using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 5;
    public float speed = 5;
    private Transform playerPos;
    public AudioClip deadEnemy;

    public GameObject dieEffect;
    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, playerPos.position) > 0.3f)
        {
            speed = 5;
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        }
    }


    public void TakeDamageP()
    {
        Debug.Log("Enemigo recibio daño");
        hp--;
        if (hp <= 0)
        {
            Debug.Log("Enemigo destruido");
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player e = collision.gameObject.GetComponent<Player>();
            e.TakeDamage();
            Instantiate(dieEffect, this.transform.position + Vector3.up * 2f, Quaternion.identity);
            Destroy(gameObject);
            Destroy(GameObject.Find("Bar").transform.GetChild(0).gameObject);
        }
    }


}
