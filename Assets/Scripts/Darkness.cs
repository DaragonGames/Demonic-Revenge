using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{
    private GameObject flashLight;
    private GameObject darknessEffect;
    private GameObject semiDarknessEffect;

    public Sprite[] flashSprite;


    // Start is called before the first frame update
    void Start()
    {
        flashLight = transform.GetChild(0).gameObject;
        darknessEffect = transform.GetChild(1).gameObject;
        semiDarknessEffect = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        flashLight.SetActive(false);
        semiDarknessEffect.SetActive(false);
        darknessEffect.SetActive(false);

        if (GameManager.conditionsMeet[GameManager.ConditionNames.hasFlashlight])
        {
            flashLight.SetActive(true);
            if (PlayerController.player.facingDirection < 0)
            {
                flashLight.transform.localPosition = new Vector3(0.42f, 0, 1.18f);
                flashLight.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                flashLight.transform.localPosition= new Vector3(-0.2f, 0, 1.18f);
                flashLight.transform.localScale = new Vector3(-1, 1, 1);
            }  
            if (PlayerController.player.transform.position.x <= -20)
            {
                flashLight.GetComponent<SpriteRenderer>().sprite = flashSprite[0];
            }
            else
            {
                flashLight.GetComponent<SpriteRenderer>().sprite = flashSprite[1];
            }          
        }


        if (PlayerController.player.transform.position.x <= -20)
        {
            if (GameManager.conditionsMeet[GameManager.ConditionNames.hasFlashlight])
            {
                semiDarknessEffect.SetActive(true);
            }
            else
            {                
                darknessEffect.SetActive(true);
            }
        }
    }
    
}
