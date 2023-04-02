using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enter : MonoBehaviour
{
    public void EnterLevel()
    {
        SceneManager.LoadScene("Level One");
    }

}
