using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
   public void OnClick()
    {
        SceneManager.LoadScene("World");
    }
}
