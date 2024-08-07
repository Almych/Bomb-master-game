using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    

    private static  int menu = 0;
    private static int play = 1;

   

    public void PlayBack ()
     {
        SceneManager.LoadScene(menu);
     }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(play);
    }
    public void PauseGame ()
    {
        Time.timeScale = 0;
    }
    public void ContinueGame ()
    {
        Time.timeScale = 1;
    }
    
}
