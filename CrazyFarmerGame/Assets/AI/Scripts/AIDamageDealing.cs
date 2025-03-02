using System;
using UnityEngine;

public class AIDamageDealing : MonoBehaviour
{
    GameObject Enemy;
    AiController AIcontroller;

    void Start()
    {

        Enemy = gameObject.transform.parent.gameObject;
        AIcontroller = Enemy.GetComponent<AiController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Touched!");
        GetComponent<Collider2D>().enabled = false;
        Enemy.GetComponent<SpriteRenderer>().flipY = true;
        Enemy.GetComponent<Collider2D>().enabled = false;
        Vector3 movement = new Vector3(UnityEngine.Random.Range(40, 70), UnityEngine.Random.Range(-40, 40), 0f);
        Enemy.transform.position = Enemy.transform.position + movement * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
