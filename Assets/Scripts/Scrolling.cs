using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public Vector2 scrollSpeed = new Vector2(0, 0);

    Material material;
    Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        offset = scrollSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
 