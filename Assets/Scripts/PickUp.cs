using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public GameObject playerCamera;
    public GameObject playerHand;
    public GameObject playerArm;
    public LayerMask GroundLayer;
    public float raycastMaxDistance = 1f;
    public float originOffset = 1f;
    public float origenY;

    public GameObject weaponOnHand;

    public float dropSpeed = 100f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        RaycastCheckUpdate();
        if (Input.GetKeyDown(KeyCode.Q) && weaponOnHand != null)
        {
            setDrop();
        }

    }

    private bool RaycastCheckUpdate()
    {

            if (Input.GetKey(KeyCode.E))
            {
            // Launch a raycast in the forward direction from where the player is facing.
            Vector2 direction = new Vector2(1, 0);

            // If facing left, negative direction

            // First target hit
            RaycastHit2D hit = CheckRaycast(direction);

            if (hit.collider)
            {
                if (hit.collider.gameObject.CompareTag("Weapon") && weaponOnHand == null)
                {
                        weaponOnHand = hit.collider.gameObject;
                        Destroy(hit.collider.gameObject.GetComponent<Rigidbody2D>());
                        hit.collider.gameObject.transform.parent = playerHand.transform;
                        hit.collider.gameObject.transform.rotation = Quaternion.Euler(0, 0, playerHand.transform.rotation.z);
                        hit.collider.gameObject.transform.localPosition = playerHand.transform.localPosition;
                }

                    Debug.DrawRay(transform.position, hit.point, Color.red, 3f);
            }

            return true;
        }
        else
        {
            return false;
        }
    }

    void setDrop()
    {
        // Remove Item from player parent 
        weaponOnHand.transform.parent = null;
        weaponOnHand.AddComponent<Rigidbody2D>();
        weaponOnHand.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

        //Set New Position to drop item
        float newY, newX;

        // Looking up: Use Player Collider Size + Y position
        newY = (weaponOnHand.gameObject.GetComponent<BoxCollider2D>().bounds.size.y + 0.02f) * -1F;
        // Since X collider is in X = 0, the logis is simplier
        newX = (weaponOnHand.gameObject.GetComponent<BoxCollider2D>().bounds.size.x + 0.02f) * 1;
        //Set New Position to drop item


        //weaponOnHand.transform.Translate(transform.up * dropSpeed * Time.deltaTime);
        // weaponOnHand.gameObject.GetComponent<Rigidbody2D>().rotation = playerArm.GetComponent<Rigidbody2D>().rotation;
        //  weaponOnHand.gameObject.GetComponent<Rigidbody2D>().AddForce = weaponOnHand.transform.position * dropSpeed;
        weaponOnHand.gameObject.transform.rotation = playerArm.gameObject.transform.rotation;
        weaponOnHand.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0.3f) * dropSpeed);
        // Adjust Object Layer
        // weaponOnHand.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
        // Adjust Object Order
        //weaponOnHand.GetComponent<SpriteRenderer>().sortingOrder = (int)((10 * ((transform.position.y + (1 * 0.25f)) * -1)));
        // Set no item is picked
        weaponOnHand = null;
        //   picking = false;
    }


    public RaycastHit2D CheckRaycast(Vector2 direction)
        {
            float directionOriginOffset = originOffset * (direction.x > 0 ? 1 : -1);

            Vector2 startingPosition = new Vector2(transform.position.x, transform.position.y + origenY);

            return Physics2D.Raycast(startingPosition, direction, raycastMaxDistance, 1 << LayerMask.NameToLayer("Weapon"));
        }
}