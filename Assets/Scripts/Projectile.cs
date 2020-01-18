using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
   // public GameObject destroyEffect;
    public LayerMask whatisSolid;

    

    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);

      //  player = GameObject.FindGameObjectWithTag("Player").transform;
     //   target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.left, distance);
        if (hitInfo.collider != null)
        {
           // if (hitInfo.collider.CompareTag("PlayerInfo"))
         //   {
        //        Debug.Log("Enemy must take damage!");
             //   hitInfo.collider.GetComponent<Player>().TakeDamage(damage);
          //  }
           // DestroyProjectile();
        }


        transform.Translate(transform.up * speed * Time.deltaTime);

    }

    void DestroyProjectile()
    {
       // Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }


}