using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public List<GameObject> catchers;
    Rigidbody2D rb;
    public float catchDistance = 0.6f;
    public bool isCatched = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCatched)
            return;
        LookForCatcher();
    }

    void LookForCatcher()
    {
        foreach (GameObject catcher in catchers)
        {
            if (catcher == null)
            {
                continue;
            }
            if (HasCatchedMe(catcher))
            {
                OnCatch(catcher);
                break;
            }
        }
    }

    bool HasCatchedMe(GameObject catcher)
    {
        return Vector2.Distance(catcher.transform.position, transform.position) <= catchDistance;
    }

    void OnCatch(GameObject catcher)
    {
        Debug.Log(catcher.name + " has catched paricle " + GetInstanceID());
        isCatched = true;
        transform.parent = catcher.transform;
        rb.velocity = Vector2.zero;
    }
}
