using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField] GameObject Car;
    [SerializeField] float forceMultiplier;
    private Rigidbody2D carRB;
    private float Force;
    // Start is called before the first frame update
    void Start()
    {
        carRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Force += Time.fixedDeltaTime;
            carRB.velocity = new Vector2(-Force*forceMultiplier, 0);
        }
    }
}
