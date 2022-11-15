using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 4;
    public Rigidbody2D rb;
    public Animator anim;
    public LayerMask groundLayer;
    float x;

    public float jumpForce = 7;
    public bool canJump = false;

    public Transform feet;
    public Vector2 size = new Vector2(1, 0.5f);

    public Transform firePoint;
    public float timer = 0;
    public float timeBtwAttack = 1;
    public bool canShoot = true;
    public GameObject bulletPrefab;

    private bool activo;

    public int hp = 3;
    public Text hpText;

    void Start()
    {
        hpText.text = hp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        CheckIfCanShoot();
        Shoot();
        Bend();
    }
    void Move()
    {
        x = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(x));
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
        if (x < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (x > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    void Jump()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(feet.position, size, 0, groundLayer);
        if (colliders.Length > 0)
        {
            anim.SetBool("Jumping", false);
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
        else
        {
           
            anim.SetBool("Jumping", true);
            //canJump = false;
        }
    }

    void Shoot()
    {
        if (canShoot)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bulletPrefab, firePoint.position, transform.rotation);
                canShoot = false;
                //anim.SetTrigger("Shoot");
            }
        }
    }
    void CheckIfCanShoot()
    {
        if (!canShoot)
        {
            timer += Time.deltaTime;
            if (timer >= timeBtwAttack)
            {
                canShoot = true;
                timer = 0;
            }
        }
    }

    void Bend()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            activo = !activo;

        }
        if (activo == true)
        {
            anim.SetBool("Bend", true);
            anim.SetFloat("SpeedBend", Mathf.Abs(x));
        }
        if (activo == false)   
        {
            anim.SetBool("Bend", false);
            
        }
    }

}
