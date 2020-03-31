using UnityEngine;
using System.Collections;

public class Buoyancy : MonoBehaviour
{

    public float gravityX;
    public float gravityY;

    // Use this for initialization
    void Start()
    {
        Physics2D.gravity = new Vector2(gravityX, gravityY);
    }

}
