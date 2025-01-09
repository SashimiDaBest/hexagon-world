using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
   public void OnClick()
    {
        SceneManager.LoadScene("World");
        Debug.Log("CLICKED");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("SPACE");
            SceneManager.LoadScene("World");
        }
    }


}
