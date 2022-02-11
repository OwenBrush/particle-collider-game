using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Paddle : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] float timeTotal;
    [SerializeField] float timeStart = 30;
    [SerializeField] TextMeshProUGUI timeDisplay;
    [SerializeField] TextMeshProUGUI scoreDisplay;
    [SerializeField] Animation paddleAnimation;
    [SerializeField] AudioSource paddleAudio;
    [SerializeField] public bool gameRunning = false;




    [SerializeField] LayerMask mask;

    private void Start()
    {
        paddleAudio = GetComponent<AudioSource>();
        paddleAnimation = GetComponent<Animation>();
    }


    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (gameRunning)
        {
            time -= Time.deltaTime;
            timeTotal += Time.deltaTime;
            timeDisplay.text = Mathf.RoundToInt(time).ToString("D2");
            if (Physics.Raycast(ray, out RaycastHit rayCastHit, float.MaxValue, mask))
            {
                transform.position = rayCastHit.point;
            }

            if (time <= 0)
            {
                EndGame();
            }

        }
        else
        {
            if (Physics.Raycast(ray, out RaycastHit rayCastHit))
            {
                if (rayCastHit.collider.gameObject == gameObject)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Cursor.visible = false;
                        gameRunning = true;
                        timeTotal = 0;
                        time = 30;
                        paddleAnimation.Play("Paddle Hit");
                        paddleAudio.Play();
                        scoreDisplay.text = "";
                    }
                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameRunning && other.gameObject.CompareTag("Sphere"))
        {
            
            time += 1f;
            paddleAnimation.Play("Paddle Hit");
            paddleAudio.Play();
        }

    }

   private void EndGame()
    {
        Cursor.visible = true;
        scoreDisplay.text = Mathf.RoundToInt(Mathf.Clamp(timeTotal-timeStart, 0, float.MaxValue)).ToString("D4") + " seconds";
        timeDisplay.text = "GO";
        gameRunning = false;
        transform.position = new Vector3(0,0, transform.position.z);
    }

}
