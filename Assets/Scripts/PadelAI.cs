using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadelAI : MonoBehaviour
{
    private Ball ball;

    private Vector2 ballpos;
    public float movespeed;
    public TableManager tablemanager;
    public Color colors;

    public bool LeftPadel;
    // Start is called before the first frame update
    void Start()
    {
        tablemanager = transform.parent.GetChild(transform.parent.childCount - 1).GetComponent<TableManager>();

    }

    // Update is called once per frame
    void Update()
    {


        Mathf.Clamp(transform.position.y, transform.position.y - 3, transform.position.y + 3);

       
        if (tablemanager.PositiveVelocityballs.Count == 0 && tablemanager.NegativeVelocityballs.Count == 0)
        {
            ball = null;
        }
                



        if (tablemanager.PositiveVelocityballs.Count > 0)
            tablemanager.PositiveVelocityballs[0].GetComponent<SpriteRenderer>().color = Color.red;

        if (tablemanager.NegativeVelocityballs.Count > 0)
            tablemanager.NegativeVelocityballs[0].GetComponent<SpriteRenderer>().color = Color.green;



                                       /*///Left Padel////*/

        if(LeftPadel)

        { if (tablemanager.NegativeVelocityballs.Count > 0)
            {
                ball = tablemanager.NegativeVelocityballs[0];
                ballpos = ball.transform.position;

            }
            else if (tablemanager.NegativeVelocityballs.Count == 0)
            {
                ballpos = transform.position;
                ball = tablemanager.PositiveVelocityballs[0];
            }
            if (transform.parent == ball.transform.parent)
            {
                Debug.DrawLine(transform.position, ball.transform.position, Color.green);
                if (ballpos.y < transform.position.y)
                {
                    transform.position += new Vector3(0, -movespeed * Time.deltaTime, 0);
                }
                if (ballpos.y > transform.position.y)
                {
                    transform.position += new Vector3(0, movespeed * Time.deltaTime, 0);
                }
            }
        }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            /*///Right Padel////*/
            if (!LeftPadel)
            {


                if (tablemanager.PositiveVelocityballs.Count > 0)
                {
                    ball = tablemanager.PositiveVelocityballs[0];
                    ballpos = ball.transform.position;



                }


                else if (tablemanager.PositiveVelocityballs.Count == 0)
                {
                    ballpos = transform.position;
                    ball = tablemanager.NegativeVelocityballs[0];
                }
                if (transform.parent == ball.transform.parent)
                {
                    Debug.DrawLine(transform.position, ball.transform.position, Color.red);
                    if (ballpos.y < transform.position.y)
                    {
                        transform.position += new Vector3(0, -movespeed * Time.deltaTime, 0);
                    }
                    if (ballpos.y > transform.position.y)
                    {
                        transform.position += new Vector3(0, movespeed * Time.deltaTime, 0);
                    }
                }



            }
            ////////////////////////////////////////////////////////////////////////////

    }
}

