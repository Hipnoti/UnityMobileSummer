using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello " + gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * (10f * Time.deltaTime));
            transform.Rotate(Vector3.left * (5f * Time.deltaTime));
            Debug.Log("Raichu!");
        }
    }
}
