using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusIndicator : MonoBehaviour {

    [SerializeField]
    private RectTransform healthBarRect;
    [SerializeField]

    private Text healthText;

    private Image healthBarColor;

    Gradient g = new Gradient();

    //borrar en el futuro
    public float value;
    

    void Start()
    {
        if (healthBarRect == null)
        {
            Debug.LogError("no health barr objet referenced");
        }
        if (healthText == null)
        {
            Debug.LogError("no heal text referenced");
        }

        healthBarColor = healthBarRect.GetComponent<Image>();

        GradientColorKey[] gck = new GradientColorKey[3];

        gck[0].color = Color.green;
        gck[0].time = 0.0F;

        gck[1].color = Color.yellow;
        gck[1].time = 0.5F;

        gck[2].color = Color.red;
        gck[2].time = 1F;

        GradientAlphaKey[] gak = new GradientAlphaKey[2];
        gak[0].alpha = 1.0F;
        gak[0].time = 0.0F;

        gak[1].alpha = 1.0F;
        gak[1].time = 1.0F;

        g.SetKeys(gck, gak);





    }

    public void SetHealth(int _cur, int _max)
    {
        float _value = (float)_cur / _max;

        healthBarRect.localScale = new Vector3(_value, healthBarRect.localScale.y, healthBarRect.localScale.z);
        healthText.text = _cur + "/" + _max + "HP";


        healthBarColor.color = g.Evaluate(1 - value);

        

    }
}
