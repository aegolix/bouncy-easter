using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockControl : MonoBehaviour
{
    // Start is called before the first frame update

    private int childRockCount = 0;

    void Start()
    {
        childRockCount = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (StartGame.start && Input.GetMouseButtonDown(0))
        ///if (StartGame.start && Input.touchCount > 0)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ///Vector3 wp = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
            GameObject chosen = transform.GetChild(Random.Range(0, childRockCount - 1)).gameObject;
            GameObject aPole = Instantiate(chosen, new Vector3(wp.x, -chosen.GetComponent<BoxCollider2D>().size.y, 0), Quaternion.identity, transform.transform) as GameObject;
            aPole.SetActive(true);
        }
    }
}
