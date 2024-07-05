using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    Animator animator;

    public GameObject door;
    public bool openOnPress = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            animator.SetBool("pressed", true);
            if (openOnPress)
            {
                door.GetComponent<Door>().Open();
            }
            else
            {
                door.GetComponent<Door>().Close();
            }
        }
    }

    public void Load()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        Debug.Log(animator);
        animator.SetBool("pressed", false);
    }
}
