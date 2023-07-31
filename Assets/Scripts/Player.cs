using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject projectilePrefab;
    private float fireRate = 0.5f;
    private float canFire = -1f;
    public float lives = 3;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move the player forward or backward based on the input
        if (verticalInput > 0)
        {
            MoveForward();
        }
        else if (verticalInput < 0)
        {
            MoveBackward();
        }
        if (horizontalInput > 0)
        {
            MoveRight();
        }
        else if (horizontalInput < 0)
        {
            MoveLeft();
        }

        shootprojectile();
    }
    private void MoveForward()
    {
        // Calculate the forward direction relative to the player's rotation
        Vector3 forwardDirection = transform.forward * moveSpeed * Time.deltaTime;
        transform.position += forwardDirection;

        // Rotate the player to face forward
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.5f);
    }

    private void MoveBackward()
    {
        // Calculate the backward direction relative to the player's rotation
        Vector3 backwardDirection = transform.forward * moveSpeed * Time.deltaTime;
        transform.position += backwardDirection;

        // Rotate the player to face backward
        Quaternion targetRotation = Quaternion.Euler(0f, 180f, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.5f);
    }
    private void MoveRight()
    {
        Vector3 rightDirection = transform.forward * moveSpeed * Time.deltaTime;
        transform.position += rightDirection;
        transform.rotation = Quaternion.Euler(0f, 90f, 0f);
    }

    private void MoveLeft()
    {
        Vector3 leftDirection = transform.forward * moveSpeed * Time.deltaTime;
        transform.position += leftDirection;
        transform.rotation = Quaternion.Euler(0f, -90f, 0f);
    }

    void shootprojectile()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > canFire)
        {
            canFire = Time.time + fireRate;
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }

    public void Damage()
    {
        lives--;
        if(lives < 1)
        {
            Destroy(gameObject);
            gameOver = true;
        }
    }
}
