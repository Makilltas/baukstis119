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

    public SpriteRenderer plane;

    public float jumpforce = 100;

    private int score = 0;

    public AudioClip successSound;

    private AudioSource audioSource;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        plane = GetComponent<SpriteRenderer>();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (rb.velocity.y < 0)
            {
                rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            }


        }

        if (rb.velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 30);

        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, -30);

        }


        




    }

    void OnTriggerExit2D(Collider2D col)
    {
        scoreText.text =  (++score).ToString("0000");
        audioSource.PlayOneShot(successSound);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        scoremanager.ShowScoreBoard(score);
        gameObject.SetActive(false);
    }


}

