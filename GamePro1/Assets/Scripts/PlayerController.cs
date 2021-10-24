using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.5f;
   // public float 
    // Update is called once per frame
    void Update()
    {
        float newX = transform.position.x;
        float newY = transform.position.y;
        float newZ = transform.position.z;
        

        if (Input.GetKey(KeyCode.UpArrow))
        {
            newZ = transform.position.z + speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            newZ = transform.position.z - speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            newX = transform.position.x + speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newX = transform.position.x - speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        transform.position = new Vector3(newX, newY, newZ);


    }
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.name == "Sphere")
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        if (collision.gameObject.name == "Cube")
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
