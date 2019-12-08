using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public List<GameObject> catchers;
    private Rigidbody2D rb;
    private PointEffector2D pef;
    public float catchDistance = 0.6f;
    public float forceFactor = 1f / 300;
    public float randomFactor = 1f / 200;
    public bool isCatched = false;
    public GameObject catcher = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pef = GetComponent<PointEffector2D>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCatched)
            FollowCatcher();
        else
            LookForCatcher();
    }

    void FollowCatcher()
    {
        if (catcher == null)
        {
            Debug.LogError("Catcher was null!");
            return;
        }
        Vector2 force = GetCatcherForceOnMe();
        rb.AddForce(force);
        CheckEscape();
    }

    Vector2 GetCatcherForceOnMe()
    {
        Vector2 force = -transform.localPosition * forceFactor;
        Vector2 rand = Random.insideUnitCircle * randomFactor;
        force += rand;
        return force;
    }

    void CheckEscape()
    {
        if (rb.velocity.magnitude > 6f)
        {
            rb.velocity /= 2;
        }
    }

    void LookForCatcher()
    {
        foreach (GameObject catcher in catchers)
        {
            if (catcher == null)
            {
                continue;
            }
            if (InCatchRange(catcher))
            {
                OnCatch(catcher);
                break;
            }
        }
    }

    float DistanceFrom(GameObject other)
    {
        return Vector2.Distance(other.transform.position, transform.position);
    }

    bool InCatchRange(GameObject catcher)
    {
        return DistanceFrom(catcher) <= catchDistance;
    }

    void OnCatch(GameObject catcher)
    {
        Debug.Log(catcher.name + " has catched paricle " + GetInstanceID());
        isCatched = true;
        this.catcher = catcher;
        transform.parent = catcher.transform;
        rb.velocity = Vector2.zero;
    }
}
