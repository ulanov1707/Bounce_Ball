using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField] private float _JumpForce;
    [SerializeField] private float _Gravity = 1;
    [SerializeField] private float _jumpMultiplyer = 10f;
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private TilesSpawner tileSpawner;

    public int score = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


        if (rb == null) { Debug.Log("Ridgitbody isnt set!"); }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Tile")) 
        {
            if(rb.velocity.y <= 0f) 
            {
                _JumpForce = _Gravity * _jumpMultiplyer;
                rb.velocity = new Vector2(0, _JumpForce);
                score++;
                DestroyAndSpawn(other);
            }

        }
        
    }

    public void DestroyAndSpawn(Collider2D other) 
    {
        Destroy(other.gameObject);
        TilesSpawner.instance.SpawnTile();
    }

    void Update()
    {
        AddGravity();
        GetInput();
        IsDead();
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    private void GetInput()
    {
        float axisValue = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(axisValue * _moveSpeed * Time.deltaTime, 0, 0));

        if (transform.position.x >= 3.5f || transform.position.x <= -3.5f)
            transform.position = new Vector3(transform.position.x *-1,transform.position.y,transform.position.z);
      
    }

    void AddGravity() 
    {
        rb.velocity = new Vector2(0, rb.velocity.y - (_Gravity * _Gravity));
    }

    void IsDead() 
    {
        if (transform.position.y < Camera.main.transform.position.y - 15)
        {
            Debug.Log("Dead");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
