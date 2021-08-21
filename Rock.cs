using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public GameObject[] list;
    ShipControl seconds;
    // Start is called before the first frame update
    void Start()
    {
        seconds = GameObject.FindGameObjectWithTag("Ship").GetComponent<ShipControl>();
        // apply impulse force to get game object moving
        float MinImpulseForce = 2f+(seconds.Survival());
        float MaxImpulseForce = 2f+ (seconds.Survival());
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = MaxImpulseForce;
        print("Magnitude: "+magnitude);
        print("Time: "+seconds.Survival());
        
        GetComponent<Rigidbody2D>().AddForce(
            direction * magnitude,
            ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 nowposition = transform.position;
        if (ScreenUtils.ScreenBottom > nowposition.y)
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
}
