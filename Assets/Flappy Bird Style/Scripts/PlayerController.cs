using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedFactor = 5f;
    protected KeyCode left;
    protected KeyCode right;
    private Rigidbody2D rb;

    public PlayerController(KeyCode left, KeyCode right)
    {
        this.left = left;
        this.right = right;
    }

    Vector3 GetSpeed(Vector3 direction)
    {
        return direction * speedFactor * Time.deltaTime;
    }
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(left))
        {
            transform.position += GetSpeed(Vector3.left);
        }
        if (Input.GetKey(right))
        {
            transform.position += GetSpeed(Vector3.right);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = Vector2.zero;
            transform.position += GetSpeed(Vector3.up);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = Vector2.zero;
            transform.position += GetSpeed(Vector3.down);
        }
    }
}