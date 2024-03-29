using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utilities
{
    public static int playerDeath = 0;

    public static string UpdateDeathCount (ref int playerDeath)
    {
        playerDeath += 1;
        return "Next time you'll be at number " + playerDeath;
    }

    public static void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;

        Debug.Log("Player deaths: " + playerDeath);
        string message = UpdateDeathCount(ref playerDeath);
        Debug.Log("Player deaths: " + playerDeath);

    }

    public static bool RestartLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1.0f;


        return true;
    }
}
