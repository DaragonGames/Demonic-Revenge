using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{
    private GameObject flashLight;
    private GameObject darknessEffect;
    private GameObject semiDarknessEffect;


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
        if (PlayerController.player.transform.position.x <= -20)
        {
            if (GameManager.conditionsMeet[GameManager.ConditionNames.hasFlashlight])
            {
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
                flashLight.SetActive(true);
                semiDarknessEffect.SetActive(true);
            }
            else
            {                
                darknessEffect.SetActive(true);
            }
        }
    }
    
}
