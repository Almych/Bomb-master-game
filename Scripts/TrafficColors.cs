using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.Collections;



public class TrafficColors : MonoBehaviour
{
    public bool isEnded;
    public int countPoint = 0;
    [SerializeField] private TextMeshProUGUI pointCount;
    [SerializeField] private TextMeshProUGUI timeBoard;
    [SerializeField] private GameObject scoreMenu;
    [SerializeField] private GameObject basicInterface;
    [SerializeField] private Material [] colorOfTraffic;
    [SerializeField] private TouchWireController wireController;
    [SerializeField] private AudioClip effect;
    [SerializeField] private Image vignette;
    private  ParticleSystem explosion;
    private AudioSource source, sourceBackround;
    private Action Check;
    private float timer = 0;
    private int randomColor = 0;
    private Material currColor;
    private bool isSounded = false;
    

    

    private void Start()
    {
        explosion = GameObject.FindGameObjectWithTag("Partical").GetComponent<ParticleSystem>();
        source = GameObject.FindGameObjectWithTag("Effect").GetComponent<AudioSource>();
        sourceBackround = GameObject.FindGameObjectWithTag("Backround").GetComponent<AudioSource>();
        isEnded = false;
        SetTimer();
        SetColor();
        
    }
    private void Update()
    {

        if (timer > 0)
        {
            timeBoard.text = (timer -= Time.deltaTime).ToString("f2");
            wireController.Updater();
            if (wireController.isPressed) CallColor();
            if (timer < 1) vignette.gameObject.SetActive(true);
            else vignette.gameObject.SetActive(false);
        }
        else
        {
            vignette.gameObject.SetActive(false);
            EndGame();
        }
    }

    private void CallColor ()
    {
        pointCount.text = (countPoint += 1).ToString();
        Check();
        SetColor();
        SetTimer();
        wireController.isPressed = false;
    }

    private void SetColor ()
    {
         randomColor = UnityEngine.Random.Range(0, colorOfTraffic.Length);
        currColor = colorOfTraffic[randomColor];
        transform.GetComponent<Renderer>().material = currColor;
    }
    private void SetTimer()
    {
        if (countPoint <=10)
        timer = UnityEngine.Random.Range(4, 5);
        else if (countPoint <= 30)
            timer = UnityEngine.Random.Range(2, 3);
        else if (countPoint > 30) 
            timer = UnityEngine.Random.Range(1, 2);
    }
    


    public bool CheckNodeColor(Material node)
    {
      
        if (node.name == transform.GetComponent<Renderer>().material.name)
        {
            return true;
        }
        else return false;
    }

    public void CheckNumber (Action action)
    {
        Check = action;
    }
    
    private  void EndGame ()
    {
        isEnded = true;
            basicInterface.SetActive(false);
            if (!isSounded)
            {
                source.PlayOneShot(effect);
                StartCoroutine(WaitEnd());
                isSounded = true;
            }
        scoreMenu.SetActive(true);
    }
    
    private IEnumerator WaitEnd ()
    {
            explosion.Play();
            yield return new WaitForSeconds(effect.length);
            explosion.Stop();
            sourceBackround.Stop();
    }

   
 

   



}
