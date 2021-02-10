using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TableManager : MonoBehaviour
{
    public List<Ball> NegativeVelocityballs;
    public List<Ball> PositiveVelocityballs;
    public GameObject ballprefab;


    private void Awake()
    {
        
    }
    void Start()
    {
        NegativeVelocityballs = new List<Ball>();
         PositiveVelocityballs = new List<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
     
        if(Input.GetKey(KeyCode.F))
            {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }


        if (NegativeVelocityballs.Count > 0)
        {
            NegativeVelocityballs = NegativeVelocityballs.OrderBy(e => e.transform.position.x).ToList();
        }
        if (PositiveVelocityballs.Count > 0)
        {
            PositiveVelocityballs = PositiveVelocityballs.OrderBy(e => -e.transform.position.x).ToList();
        }




       
       

            


    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("ball"))
        {

            if (collision.attachedRigidbody.velocity.x < 0)
            {
               if (!NegativeVelocityballs.Contains(collision.GetComponent<Ball>()))
               {
                NegativeVelocityballs.Add(collision.GetComponent<Ball>());
               }
               if (PositiveVelocityballs.Count > 0)
               {
                PositiveVelocityballs.Remove(collision.GetComponent<Ball>());
               }

            }


            if (collision.attachedRigidbody.velocity.x >= 0)
            {
                if (!PositiveVelocityballs.Contains(collision.GetComponent<Ball>()))
                {
                    PositiveVelocityballs.Add(collision.GetComponent<Ball>());
                }
                if (NegativeVelocityballs.Count > 0)
                {
                    NegativeVelocityballs.Remove(collision.GetComponent<Ball>());

                }
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag("ball"))
        {
            collision.transform.parent = transform.parent;

            if (collision.attachedRigidbody.velocity.x < 0)
            {
               if (!NegativeVelocityballs.Contains(collision.GetComponent<Ball>()))
               {
                NegativeVelocityballs.Add(collision.GetComponent<Ball>());
               }
               if (PositiveVelocityballs.Count > 0)
               {
                PositiveVelocityballs.Remove(collision.GetComponent<Ball>());
               }

            }


            if (collision.attachedRigidbody.velocity.x >= 0)
            {
                if (!PositiveVelocityballs.Contains(collision.GetComponent<Ball>()))
                {
                    PositiveVelocityballs.Add(collision.GetComponent<Ball>());
                }
                if (NegativeVelocityballs.Count > 0)
                {
                    NegativeVelocityballs.Remove(collision.GetComponent<Ball>());

                }
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ball"))
        {
            if(NegativeVelocityballs.Count>0)
            NegativeVelocityballs.Remove(collision.GetComponent<Ball>());
            if(PositiveVelocityballs.Count>0)
            PositiveVelocityballs.Remove(collision.GetComponent<Ball>());

            if (PositiveVelocityballs.Count == 0 && NegativeVelocityballs.Count == 0)
            {
                Instantiate(ballprefab, transform.parent);
            }
        }
    }
}
