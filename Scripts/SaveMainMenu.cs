using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMainMenu : MonoBehaviour
{
    [SerializeField] private static SaveMainMenu saveMainMenu;
    private void Awake()
    {
        if (saveMainMenu == null)
        {
            saveMainMenu = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        if (!saveMainMenu.gameObject.activeInHierarchy) saveMainMenu.gameObject.SetActive(true);
    }
   
}
