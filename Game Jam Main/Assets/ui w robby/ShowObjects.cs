using UnityEngine;

public class ShowObjects : MonoBehaviour
{
    public GameObject object1; // Reference to the first object
    public GameObject object2; // Reference to the second object
    public GameObject object3; // Reference to the third object

    void Start()
    {
        // Initially hide all objects
        HideAllObjects();
    }

    void Update()
    {
        // Check for input to show the objects
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShowObject1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShowObject2();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ShowObject3();
        }
    }

    void HideAllObjects()
    {
        object1.SetActive(false);
        object2.SetActive(false);
        object3.SetActive(false);
    }

    public void ShowObject1()
    {
        HideAllObjects();
        object1.SetActive(true);
    }

    public void ShowObject2()
    {
        HideAllObjects();
        object2.SetActive(true);
    }

    public void ShowObject3()
    {
        HideAllObjects();
        object3.SetActive(true);
    }
}
