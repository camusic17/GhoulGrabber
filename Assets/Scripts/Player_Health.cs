using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{


    void Update()
    {
        if (gameObject.transform.position.y < -50)
        {
            SceneManager.LoadScene(sceneName: "GD_Arena_SANDBOX");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            SceneManager.LoadScene(sceneName: "GD_Arena_SANDBOX");
        }

        {
            if (collision.collider.tag == "Hazard")
            {
                SceneManager.LoadScene(sceneName: "GD_Arena_SANDBOX");
            }
        }
        
    }
}
     

