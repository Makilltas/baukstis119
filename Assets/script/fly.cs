using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class fly : MonoBehaviour
{
    private Rigidbody2D rb;

    public scoremanager scoremanager;

    public TextMeshProUGUI scoreText;

    private float previousVelocityY;  

    public SpriteRenderer plane;

    public float jumpforce = 100;

    private int score = 0;

    public AudioClip successSound;
    public AudioClip JumpSound;
    public AudioClip FallSound;
    public AudioClip HitSound;

    private AudioSource audioSource;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        plane = GetComponent<SpriteRenderer>();

        audioSource = GetComponent<AudioSource>();

        previousVelocityY = rb.velocity.y; 
    }

    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (rb.velocity.y < 0)
                audioSource.PlayOneShot(JumpSound); 

            
            if (rb.velocity.y < 0)
            {
                rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            }
        }

        
        DetectFalling();

        
        if (rb.velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 30); 
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, -30); 
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            audioSource.PlayOneShot(HitSound);
        }


    }

    
    void DetectFalling()
    {
        float currentVelocityY = rb.velocity.y;

        
        if (previousVelocityY > 0 && currentVelocityY < 0)
        {
            
            if (FallSound != null && !audioSource.isPlaying)
            {
                audioSource.PlayOneShot(FallSound);
            }
        }

        
        previousVelocityY = currentVelocityY;
    }

   
    void OnTriggerExit2D(Collider2D col)
    {
        scoreText.text = (++score).ToString("0000");
        audioSource.PlayOneShot(successSound); 
    }

    
    void OnCollisionEnter2D(Collision2D col)
    {
       
        

        
        scoremanager.ShowScoreBoard(score);
        Ggsound();
        gameObject.SetActive(false);

        
    }

    void Ggsound()
    {
        
        audioSource.PlayOneShot(HitSound);
    }



}
