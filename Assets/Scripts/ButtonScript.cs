using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ButtonScript : MonoBehaviour
{
    public Button startButton; 

    void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
