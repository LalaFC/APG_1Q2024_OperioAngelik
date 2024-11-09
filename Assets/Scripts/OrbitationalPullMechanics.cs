using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitationalPullMechanics : MonoBehaviour
{
    [SerializeField] GameObject earth;
    [SerializeField]Rigidbody2D rb;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        earth = GameObject.Find("Earth");
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PullArea")
        {
            direction = rb.transform.position - earth.transform.position;
            Physics.gravity = direction;
            rb.gravityScale = 1;
            Debug.Log(collision);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        rb.gravityScale = 0;
    }
}
