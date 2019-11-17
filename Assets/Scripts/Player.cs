using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public BoxCollider2D boundingCollider;
    public float speed;
    public Transform leftGun;
    public Transform rightGun;
    public GameObject laserProjectile;
    private int lastGunFired = 0;
    private float timeLastFired = 0f;
    public float shotCooldown;
    public GameObject shield;

    // Start is called before the first frame update
    void Start()
    {
        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        var pos = this.transform.position;
        var bounds = this.boundingCollider.bounds;

        var velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime * speed;
        var newPos = pos + (Vector3)velocity;

        if (bounds.min.x > newPos.x || newPos.x > bounds.max.x)
        {
            velocity.x = 0;
        }

        if (bounds.min.y > newPos.y || newPos.y > bounds.max.y)
        {
            velocity.y = 0;
        }

        this.transform.position += (Vector3)velocity;

        // Firing
        if (Input.GetButton("Fire1") && (Time.time - timeLastFired) > shotCooldown)
        {
            timeLastFired = Time.time;
            if (lastGunFired == 0)
            {
                Instantiate(laserProjectile, leftGun.position, Quaternion.identity);
                lastGunFired++;
            }
            else
            {
                Instantiate(laserProjectile, rightGun.position, Quaternion.identity);
                lastGunFired = 0;
            }
        }

        // Shield
        if (Input.GetButtonDown("Shield"))
        {
            shield.SetActive(true);
        }
        if (Input.GetButtonUp("Shield"))
        {
            shield.SetActive(false);
        }
    }
}
