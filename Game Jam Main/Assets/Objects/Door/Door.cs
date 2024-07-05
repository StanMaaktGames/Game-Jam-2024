using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    public Collider2D doorCollider;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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

    public void Load()
    {
        doorCollider.enabled = true;
    }
}
