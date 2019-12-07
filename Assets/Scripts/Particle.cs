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
            Debug.Log("Recerting particle escape");
            rb.velocity = Vector2.zero;
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
