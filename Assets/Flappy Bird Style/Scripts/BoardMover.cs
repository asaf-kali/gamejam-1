using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMover : MonoBehaviour
{
    public float speedFactor = 1.5f;
    protected KeyCode left;
    protected KeyCode right;

    public BoardMover(KeyCode left, KeyCode right)
    {
        this.left = left;
        this.right = right;
    }

    Vector3 GetSpeed(Vector3 direction)
    {
        return direction * speedFactor * Time.deltaTime;
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
    }
}