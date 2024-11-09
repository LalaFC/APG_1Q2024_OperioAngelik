using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RbForceOrbiting : MonoBehaviour
{
    [SerializeField] string targetName;
    [SerializeField] GameObject target;
    [SerializeField] float pullForce = 12;
    Rigidbody2D meteorRB;
    Vector2 direction;
    float targetScale;

    Vector2 initPos;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find(targetName);
        meteorRB = GetComponent<Rigidbody2D>();
        initPos = transform.position;
        targetScale = target.transform.localScale.magnitude/5;
    }

    // Update is called once per frame
    void Update()
    {
        direction = (target.transform.position-transform.position).normalized;
        if (Input.GetKeyDown(KeyCode.Backspace))ResetMeteor();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.parent.transform.parent.name == targetName)
        {
            Debug.Log(collision.transform.parent.transform.parent.name + $"target = {targetName}");
            if (collision.gameObject.name == "OuterPull")
            {
                var dynamicPullForce = Mathf.Abs(10 - Vector2.Distance(target.transform.position, transform.position) - 5) / 10;
                meteorRB.AddForce(direction * pullForce * dynamicPullForce * targetScale);
            }
            else
            {
                meteorRB.AddForce(direction * pullForce);
            }
        }

    }
    void ResetMeteor()
    {
        transform.position = initPos;
    }
}
