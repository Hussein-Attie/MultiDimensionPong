using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D ballrb;
    public Vector2 foce;
    private Score score;
    private Canvas canvs;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
          
            ballrb = gameObject.GetComponent<Rigidbody2D>();
            ballrb.AddForce(foce);

        }
    }

    private void OnEnable()
    {
        canvs = transform.parent.GetComponentInChildren<Canvas>();
        score = canvs.gameObject.GetComponent<Score>();
        ballrb = gameObject.GetComponent<Rigidbody2D>();
        ballrb.AddForce(foce);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.transform.parent = transform.parent)
        {
            if (collision.collider.CompareTag("rightwall"))
            {
                score.rightscore++;
            }
            if (collision.collider.CompareTag("leftwall"))
            {
                score.leftscore++;
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent = transform.parent)
        {
            if (collision.CompareTag("rightwall"))
            {
                score.rightscore++;
            }
            if (collision.CompareTag("leftwall"))
            {
                score.leftscore++;
            }
        }
    }


}


