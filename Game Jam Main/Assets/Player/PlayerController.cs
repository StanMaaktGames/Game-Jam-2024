using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 velocity;
    public bool grounded = false;
    bool reversing = false;
    List<Vector3> pastPositions = new List<Vector3>();
    Vector3 deltaPosition;
    Vector3 previousPosition;

    public float moveSpeed = 1f;
    public float coyoteSeconds = 0.1f;
    public float jumpForce = 1f;
    public float airDrag;
    public float reverseLength = 5f;

    [Header("UI")]

    public Slider reverseSlider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            reversing = true;
        }
        else if (Input.GetKeyUp("space"))
        {
            reversing = false;

        }

        reverseSlider.value = pastPositions.Count / (reverseLength * 50);
        Debug.Log(pastPositions.Count);
    }

    void FixedUpdate()
    {
        if (reversing)
        {
            if (pastPositions.Count > 0)
            {
                transform.position = pastPositions.Last();
                pastPositions.RemoveAt(pastPositions.Count - 1);
            }
            else
            {
                reversing = false;
            }
        }
        else
        {
            velocity.x = Input.GetAxis("Horizontal") * moveSpeed;

            if (Input.GetAxis("Vertical") > 0f && grounded)
            {
                rb.AddForce(transform.up * jumpForce);
                grounded = false;
            }

            transform.position += velocity * Time.deltaTime;



            if (deltaPosition != new Vector3(0, 0, 0))
            {
                pastPositions.Add(transform.position);
            }
            if (pastPositions.Count > reverseLength * 50)
            {
                pastPositions.RemoveAt(0);
            }
        }

        deltaPosition = transform.position - previousPosition;
        previousPosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 3 && deltaPosition.y < 0f)
        {
            Debug.Log("Collision enter");
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == 3)
        {
            Debug.Log("Collision exit");
            grounded = false;
        }
    }
}
