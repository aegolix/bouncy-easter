using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{

    public float speed = 0;
    public float direction = 1;
    private Rigidbody2D bunny;
    public GameObject sibling;
    private float camHalfWidth, spriteWidth;
    private float offset;
    private Camera cam;

    void Awake()
    {
        cam = Camera.main;
        bunny = GameObject.Find("Bunny").GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        camHalfWidth = cam.orthographicSize * Screen.width / Screen.height;

        SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = sRenderer.bounds.size.x;

        offset = 1f;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.left * (Mathf.Abs(bunny.velocity.x) + speed) * Time.deltaTime * Mathf.Sign(bunny.transform.localScale.x));


        if (transform.position.x + spriteWidth / 2 <= cam.transform.position.x - camHalfWidth)
        {
            Vector2 newPos = new Vector2(sibling.transform.position.x + spriteWidth - offset, transform.position.y);
            transform.position = newPos;
        }

        if (transform.position.x - spriteWidth / 2 >= cam.transform.position.x + camHalfWidth)
        {
            Vector2 newPos = new Vector2(sibling.transform.position.x - spriteWidth + offset, transform.position.y);
            transform.position = newPos;
        }
    }
}
