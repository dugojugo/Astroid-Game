using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    GameObject explosion;

    // Start is called before the first frame update
    HUD hud;
    int RockPoints = 1;
    void Start()
    {
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nowposition = transform.position;
        if (ScreenUtils.ScreenBottom > nowposition.y)
        {
            Destroy(gameObject);
        }
        if (ScreenUtils.ScreenTop < nowposition.y)
        {
            Destroy(gameObject);
        }
        if (ScreenUtils.ScreenRight < nowposition.x)
        {
            Destroy(gameObject);
        }
        if (ScreenUtils.ScreenLeft > nowposition.x)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        if (collision.gameObject.tag == "Rock")
        {
          
            // GameObject explode = Instantiate(explosion) as GameObject;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            hud.AddPoints(RockPoints);
        }
    }
}
