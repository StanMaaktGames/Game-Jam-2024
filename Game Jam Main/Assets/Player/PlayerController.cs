using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 velocity;
    bool grounded = false;
    bool reversing = false;
    List<Vector3> pastPositions = new List<Vector3>();

    public float moveSpeed = 1f;
    public float coyoteSeconds = 0.1f;
    public float jumpForce = 1f;
    public float airDrag;
    public float reverseLength = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity.x = Input.GetAxis("Horizontal") * moveSpeed;

        if (Input.GetAxis("Vertical") > 0f && grounded)
        {
            rb.AddForce(transform.up * jumpForce);
            grounded = false;
        }

        transform.position += velocity * Time.deltaTime;

        if (Input.Get)
    }

    void FixedUpdate()
    {
        if (reversing)
        {
            transform.position = pastPositions.Last();
            pastPositions.RemoveAt(-1);
        }
        else
        {
            pastPositions.Add(transform.position);
            if (pastPositions.Count > reverseLength * 50)
            {
                pastPositions.RemoveAt(0);
            }
        }
        Debug.Log(pastPositions.Count);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 3)
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
