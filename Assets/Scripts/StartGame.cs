using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public static bool start = false;
    private Camera cam;
    private GameObject lb, rb;
    // Start is called before the first frame update

    void Awake()
    {
        cam = Camera.main;
        lb = GameObject.Find("left_bound");
        rb = GameObject.Find("right_bound");
    }

    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!start && Input.GetButtonDown("Jump"))

        ///if (!start && Input.touchCount > 0)
        {
            Time.timeScale = 1;
            lb.transform.position = new Vector2(cam.transform.position.x - cam.orthographicSize * Screen.width / Screen.height - lb.GetComponent<SpriteRenderer>().bounds.size.x, lb.transform.position.y);
            rb.transform.position = new Vector2(cam.transform.position.x + cam.orthographicSize * Screen.width / Screen.height + lb.GetComponent<SpriteRenderer>().bounds.size.x, lb.transform.position.y);
            start = true;
        }
    }
}
