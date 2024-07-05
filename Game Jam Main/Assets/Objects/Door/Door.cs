using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    public Collider2D doorCollider;
    public bool startClosed = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (startClosed)
        {
            animator.SetBool("open", false);
            doorCollider.enabled = true;
        }
        else
        {
            animator.SetTrigger("startOpened");
            animator.SetBool("open", true);
            doorCollider.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        animator.SetBool("open", true);
        doorCollider.enabled = false;
    }

    public void Close()
    {
        animator.SetBool("open", false);
        doorCollider.enabled = true;
    }

    public void Load()
    {
        doorCollider.enabled = true;
    }
}
