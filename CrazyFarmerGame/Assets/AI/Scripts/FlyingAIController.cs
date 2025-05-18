using UnityEngine;
using Pathfinding;
using System.IO;

public class FlyingAIController : MonoBehaviour
{
    public GameObject player;
    private Transform target;
    public float Speed = 200f;
    public float nextWaypointDistance = 3f;

    Pathfinding.Path path;
    int currentWaypoint = 0;
    //bool reachedTheEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        target = player.transform;
        InvokeRepeating("UpdatePath", 0f, .5f);
        
    }

     public void SetPlayer(GameObject obj) 
    {
        player = obj;
    }

    void UpdatePath() 
    {
        if (seeker.IsDone()) 
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Pathfinding.Path p) 
    {
        if (!p.error) 
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null) 
        { return; }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            //reachedTheEndOfPath = true;
            return;
        }
        else 
        {
            //reachedTheEndOfPath = false;
        }
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * Speed * Time.deltaTime;
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance) 
        {
            currentWaypoint++;
        }
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); // Face right
        }
        else if (direction.x > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); // Face left
        }




    }
}
