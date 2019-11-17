using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float velocity;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var rb = this.GetComponent<Rigidbody2D>();
        rb.MovePosition(rb.position + new Vector2(0f, velocity*Time.deltaTime));

        if (Vector2.Distance(this.transform.position, new Vector2(0f, 0f)) > 20f)
        {
            Destroy(this.gameObject);
        }
    }
}
