using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public float offset;
    public GameObject projectile;
    public Transform shotPoint;
    public bool facingRight;
    private SpriteRenderer mySpriteRenderer;

    public GameObject playerArm;

    private void Awake()
    {
        // get a reference to the SpriteRenderer component on this gameObject
        mySpriteRenderer = GetComponent<SpriteRenderer>();

    }


    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
      //  transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        if (rotZ > 90 || rotZ < -90)
        {


            mySpriteRenderer.flipY = true;

            
        }
        else if (rotZ < 90 && rotZ > -90)
        {

            mySpriteRenderer.flipY = false;

        }
        if (Input.GetMouseButtonDown(0))
        {

            Instantiate(projectile, shotPoint.position, transform.rotation);
        }
    }
}
