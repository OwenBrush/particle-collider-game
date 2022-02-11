using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Paddle : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] TextMeshProUGUI timeDisplay;
    [SerializeField] Animation animator;



    [SerializeField] LayerMask mask;

    private void Start()
    {
        animator = GetComponent<Animation>();
    }
    void Update()
    {
        time -= Time.deltaTime;
        timeDisplay.text = Mathf.RoundToInt(time).ToString("D2");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit rayCastHit, float.MaxValue, mask))
        {
            transform.position = rayCastHit.point;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sphere"))
        {
            Debug.Log("Sphere hit paddle");
            time += 1f;
            animator.Play("Paddle Hit");
        }

    }

   

}
