using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript1 : MonoBehaviour
{

    public string escenaMuerte;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(KillAndLoadGameOver(collision.gameObject));
        }
    }
    
    private IEnumerator KillAndLoadGameOver(GameObject player)
    {
        Destroy(player);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(escenaMuerte);
    }
}
