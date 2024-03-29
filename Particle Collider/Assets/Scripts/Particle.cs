using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] float timeFactor = 1f;

    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float maxRotationSpeed;
    [SerializeField] float maxXSpeed;
    [SerializeField] float maxYSpeed;

    [SerializeField] float xDistanceMax ;
    [SerializeField] float yDistanceMax;

    [SerializeField] float xDistance ;
    [SerializeField] float yDistance;

    [SerializeField] float speed;
    [SerializeField] float xSpeed;
    [SerializeField] float ySpeed;
    [SerializeField] float rotationSpeed;


    [SerializeField] GameObject zigZagAnchor;
    [SerializeField] GameObject rotationAnchor;
    [SerializeField] GameObject sphere;
    [SerializeField] Animation sphereAnimation;
    [SerializeField] MeshRenderer sphereRenderer;
    private MaterialPropertyBlock propertyBlock;

    private void Awake()
    {
        sphereAnimation = GetComponent<Animation>();
        propertyBlock = new MaterialPropertyBlock();
    }

    public void OnEnable()
    {
        sphereAnimation.Play("Sphere Fade In");
        speed = Random.Range(minSpeed, maxSpeed * timeFactor);
        xSpeed = Random.Range(0, maxXSpeed * timeFactor);
        ySpeed = Random.Range(0, maxYSpeed * timeFactor);
        xDistance = Random.Range(0, xDistanceMax * timeFactor);
        yDistance = Random.Range(0, yDistanceMax * timeFactor);
        rotationSpeed = Random.Range(0, maxRotationSpeed * timeFactor);

    }
    
    private void Update()
    {
        // Move towards camera
        transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position, speed * Time.deltaTime);

        // X Movement
        if (xDistance > 0)
        {
            float x = Mathf.PingPong(Time.time * xSpeed, xDistance * 2) - xDistance;
            zigZagAnchor.transform.localPosition = new Vector3(x, 0, 0);
        }
        // Y Movement
        if (yDistance > 0)
        {
            float y = Mathf.PingPong(Time.time * ySpeed, yDistance * 2) - yDistance;
            sphere.transform.localPosition = new Vector3(0, y, 0);
        }
        // Rotate
        rotationAnchor.transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Plane2D"))
        {
            sphereAnimation.Play("Sphere Fade Away");
        }

    }

    public void DeSpawn()
    {
        gameObject.SetActive(false);
    }

}
