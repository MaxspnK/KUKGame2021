using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControllerRigidbody : MonoBehaviour
{
    public PlaygroundSceneManager manager;
    Rigidbody rb;
    public float Speed = 2f;
    float newRotY = 0;
    public float rotSpeed = 20f;
    public float JumpPower = 1.5f;
    public GameObject prefabBullet;
    public GameObject gunPosition;
    public bool hasGun = false;
    public float gunPower = 15f;
    public float gunCooldown = 1f;
    float gunCooldownCount = 0;
    public int bulletCount = 0;

    public int coinsCount = 0;
    public AudioSource audioCoin;
    public AudioSource audioGunfire;
    public AudioSource audioGun;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(manager == null)
        {
            manager = FindObjectOfType<PlaygroundSceneManager>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {/*
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(0, 0, Speed, ForceMode.VelocityChange);
            newRotY = 0;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(0, 0, -Speed, ForceMode.VelocityChange);
            newRotY = -180;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Speed, 0, 0, ForceMode.VelocityChange);
            newRotY = 90;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-Speed, 0, 0, ForceMode.VelocityChange);
            newRotY = -90;
        }
        */
        float horizontal = Input.GetAxis("Horizontal") * Speed;
        float vertical = Input.GetAxis("Vertical") * Speed;
        
        if(horizontal > 0)
        {
            newRotY = 90;
        }else if (horizontal < 0)
        {
            newRotY = -90;
        }
        if(vertical > 0)
        {
            newRotY = 0;
        }else if(vertical < 0)
        {
            newRotY = 180;
        }
        rb.AddForce(horizontal,0,vertical ,ForceMode.VelocityChange);
 /*       if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(0, JumpPower, 0, ForceMode.Impulse);
        }

        if (Input.GetButtonDown("Fire1") && hasGun && (gunCooldownCount >= gunCooldown))
        {
            gunCooldownCount = 0;
            GameObject bullet = Instantiate(prefabBullet, gunPosition.transform.position, gunPosition.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * gunPower, ForceMode.Impulse);
            //Rigidbody bRb = bullet.GetComponent<Rigidbody>();
            //bRb.AddForce(transform.forward * gunPower, ForceMode.Impulse);
            Destroy(bullet, 3f);
        } */
        
        transform.rotation = Quaternion.Lerp(
                                              Quaternion.Euler(0, newRotY, 0),
                                              transform.rotation,
                                              Time.deltaTime * rotSpeed
                                              );
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(0, JumpPower, 0, ForceMode.Impulse);
        }

        if (Input.GetButtonDown("Fire1") &&
            hasGun && (bulletCount > 0) &&
            (gunCooldownCount >= gunCooldown))
        {
            gunCooldownCount = 0;
            bulletCount--;
            manager.SetTextBullet(bulletCount);
            audioGunfire.Play();
            GameObject bullet = Instantiate(prefabBullet, gunPosition.transform.position, gunPosition.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * gunPower, ForceMode.Impulse);
            //Rigidbody bRb = bullet.GetComponent<Rigidbody>();
            //bRb.AddForce(transform.forward * gunPower, ForceMode.Impulse);
            Destroy(bullet, 3f);
        }
        gunCooldownCount = gunCooldownCount + Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //print(collision.gameObject.name);
        if (collision.gameObject.tag == "Collectable")
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        
        if (other.gameObject.tag == "Collectable")
        {
            Destroy(other.gameObject);
            coinsCount++;
            manager.SetTextCoin(coinsCount);
            audioCoin.Play();
        }

        if (other.gameObject.name == "Guntrigger")
        {
            hasGun = true;
            bulletCount += 30;
            Destroy(other.gameObject);
            manager.SetTextBullet(bulletCount);
            audioGun.Play();
        }
    }
}