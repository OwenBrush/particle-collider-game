using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
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

    private void Start()
    {
        
    }

    private void Update()
    {
        // Move towards camera
        //transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position, speed * Time.deltaTime);

        // X Movement
        float x = Mathf.PingPong(Time.time * xSpeed, xDistance * 2) - xDistance;
        zigZagAnchor.transform.localPosition = new Vector3(x, 0, 0);
        // Y Movement
        float y = Mathf.PingPong(Time.time * ySpeed, yDistance * 2) - yDistance;
        sphere.transform.localPosition = new Vector3(0, y, 0);
        // Rotate
        rotationAnchor.transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
    }
}
