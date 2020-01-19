using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletGood : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
   // public GameObject destroyEffect;
    public LayerMask whatisSolid;

    void Start()
    {
   //     Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.left, distance);
   //     if (hitInfo.collider != null)
    //    {
         /*   if (hitInfo.collider.CompareTag("Enemie"))
            {
                Debug.Log("Enemy must take damage!");
                hitInfo.collider.GetComponent<enemigo>().TakeDamage(damage);
            }
            DestroyProjectile();
        }
        */

        transform.Translate(Vector2.right * speed * Time.deltaTime);

    }

 /*   void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

    } */
}
