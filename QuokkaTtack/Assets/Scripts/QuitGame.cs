using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class QuitGame : MonoBehaviour
{
   public void Quit()
    {
        Application.Quit();
        Debug.Log("You've just exit");
    }
}
