using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public List<GameObject> catchers;
    private Rigidbody2D rb;
    private PointEffector2D pef;
    public float catchDistance = 0.6f;
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
            PreventEscape();
        else
            LookForCatcher();
    }

    void PreventEscape()
    {
        if (catcher == null)
        {
            Debug.LogError("Catcher was null!");
            return;
        }
        if (!InCatchRange(catcher))
        {
            Debug.Log("Particle escapes");
            Vector2 polar = CartesianToPolar(transform.localPosition);
            polar.y = 0.1f;
            Vector2 newPoint = PolarToCartesian(polar);
            transform.localPosition = newPoint;
        }
    }


    Vector2 CartesianToPolar(Vector2 point)
    {
        Vector2 polar = new Vector2();
        polar.x = Mathf.Atan2(point.y, point.x);
        if (point.x < 0)
            polar.x += Mathf.PI;
        polar.y = point.magnitude;
        return polar;
    }


    Vector2 PolarToCartesian(Vector2 polar)
    {
        Vector2 point = new Vector2();
        point.x = polar.y * Mathf.Cos(polar.x);
        point.y = polar.y * Mathf.Sin(polar.x);
        return point;
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

    bool InCatchRange(GameObject catcher)
    {
        return Vector2.Distance(catcher.transform.position, transform.position) <= catchDistance;
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
