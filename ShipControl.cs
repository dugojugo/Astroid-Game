using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    List<GameObject> ListOfBullets;
    //Audio
    AudioSource audio;
    //speed of ship
    const float forwardSpeed = 5;
    const float tiltAngularSpeed = 150f;
    float xAngle = 0;
    float currentAngle=0;
    float PastTime=0;
    bool click = false;

    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PastTime += Time.deltaTime;
        if (currentAngle > 360)
        {
            currentAngle = currentAngle - 360;
        }
        if (currentAngle < -360)
        {
            currentAngle = currentAngle + 360;
        }
        //rotate the ship
        float previousBullet = Input.GetAxis("Attack");
        float horizontaltilt = Input.GetAxis("Horizontal")*tiltAngularSpeed;
        float thrust = Input.GetAxis("Vertical")*forwardSpeed;
        
        if (horizontaltilt != 0)
        {
            xAngle += horizontaltilt * Time.deltaTime;
            currentAngle += xAngle;    
            gameObject.transform.Rotate(0, 0, -xAngle);
            xAngle = 0;

        }
        
        //Thrust in pointing Direction
        if (thrust != 0)
        {
            Vector3 position = transform.position;
            position.x +=(float) Math.Sin(currentAngle *Math.PI/180 )*thrust*Time.deltaTime;
            position.y += (float)Math.Cos(currentAngle *Math.PI/180) * thrust*Time.deltaTime;
            transform.position = position;
        }
        Vector3 nowposition = transform.position;
        //Attack with bullet
        
        if (previousBullet > 0)
        {
           
                if (!click)
                {
                    click = true;
                    GameObject attack = Instantiate(bullet) as GameObject;
                    attack.transform.position = nowposition;
                    Vector2 direction = new Vector2(
                    (float)Math.Sin(currentAngle * Math.PI / 180), (float)Math.Cos(currentAngle * Math.PI / 180));
                    float magnitude = 20f;
                    attack.GetComponent<Rigidbody2D>().AddForce(
                    direction * magnitude,
                    ForceMode2D.Impulse);
                }
           
        }
        else 
        {
            click = false;
        }
        //count bullets

        //teleport if leaves screen
        
        if (ScreenUtils.ScreenBottom>nowposition.y)
        {
            nowposition = transform.position;
            nowposition.y = -ScreenUtils.ScreenBottom;
            transform.position = nowposition;
        }
        if (ScreenUtils.ScreenTop < nowposition.y)
        {
            nowposition = transform.position;
            nowposition.y = -ScreenUtils.ScreenTop;
            transform.position = nowposition;
        }
        if (ScreenUtils.ScreenRight < nowposition.x)
        {
            nowposition = transform.position;
            nowposition.x = -ScreenUtils.ScreenRight;
            transform.position = nowposition;
        }
        if (ScreenUtils.ScreenLeft > nowposition.x)
        {
            nowposition = transform.position;
            nowposition.x = -ScreenUtils.ScreenLeft;
            transform.position = nowposition;
        }
       
    }
    public float Survival()
    {
        return PastTime;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            audio.Play();
            Destroy(gameObject);
           
        }
    }


}
