using UnityEngine;

public class ButtonPressedController : MonoBehaviour
{
    [SerializeField] private static ButtonPressedController audioManager;
    [SerializeField] private AudioSource back, effect;
    
   
    private void Awake()
    {
        if (audioManager == null)
        {
            audioManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

   

    public void SoundOn()
    {
        effect.volume = 1;
    }

    public void SoundOff()
    {
        effect.volume = 0;
    }

    public void MusikOn()
    {
        back.UnPause();
    }

    public void MusikOff()
    {
        back.Pause();
    }

   
      
}
