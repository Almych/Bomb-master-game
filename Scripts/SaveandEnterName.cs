using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveandEnterName : MonoBehaviour
{
    [SerializeField] private TMP_InputField displayText;
     [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private GameObject basicInterface;
    private TouchScreenKeyboard keyboard;

    void Start()
    {
        basicInterface.SetActive(false);
        nameText.text = PlayerPrefs.GetString("userName");
    }

   public void EnterName ()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer && !Application.isMobilePlatform)
        {
            if (displayText.text.Length != 0 || displayText.text.Length >= 20)
            {
                nameText.text = displayText.text;
            }
            else
            {
                nameText.text = "Каратель";
            }
            
        }
        else 
        {
                if (displayText.text.Length != 0 || displayText.text.Length >= 20)
                {

                    nameText.text = displayText.text;
                }
                else
                {
                    nameText.text = "Каратель";
                }
        }
       
    }

    public void CallKey()
    {

        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, true);
        Update();
    }
    private void SaveName ()
    {
        PlayerPrefs.SetString("userName", nameText.text);
        PlayerPrefs.Save();
    }
    public void Update()
    {
        if (keyboard.text.Length > 0 && keyboard.active)
        {
            displayText.text = keyboard.text;
        }
    }




}
