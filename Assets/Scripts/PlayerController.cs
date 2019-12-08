using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedFactor = 7f;
    protected KeyCode left;
    protected KeyCode right;
    protected KeyCode up;
    protected KeyCode down;
    private Rigidbody2D rb;

    public PlayerController(KeyCode left, KeyCode right, KeyCode up, KeyCode down)
    {
        this.left = left;
        this.right = right;
        this.up = up;
        this.down = down;
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
        if (Input.GetKey(up))
        {
            transform.position += GetSpeed(Vector3.up);
        }
        if (Input.GetKey(down))
        {
            transform.position += GetSpeed(Vector3.down);
        }
    }
}