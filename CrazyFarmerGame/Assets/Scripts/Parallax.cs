using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lenght, startposs;
    public GameObject cam;
    public float parallaxEffect;

    private void Start()
    {
        startposs = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;

    }
    void Update()
    {
        float temp = cam.transform.position.x * (1 - parallaxEffect);
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startposs + dist, transform.position.y, transform.position.z);

        if (temp > startposs + lenght)
        {
            startposs += lenght;
        }
        else if (temp < startposs - lenght)
        {
            startposs -= lenght;
        }
    }
}

