using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D stick1RB, stick2RB;
    public GameObject scriptmanager;
    public GameObject stick1, stick2;
    public GameObject s1, s2;
    public Text meterstext;
    public Text coinstext;
    public Text finalscoretext, hi_scoretext, shieldtext, pricetext, getbuttontext;
    public float m_speed = 5;
    public int gems = 0;
    public int meters = 0;
    public int HI_score = 0;
    public int[] skins = { 0, 0, 0 };
    public int saveskin = 0;
    int a = 0;
    public AudioSource audioData;
    [Header("Boosters")]
    public int shield = 1;

    
    //Start
    void Start()
    {
        skins = new int[3];
        PlayerData data = SaveSystem.LoadPlayer();
        gems = data.gems;
        HI_score = data.HI_score;
        saveskin = data.saveskin;
        if(saveskin == 1)
        {
            skins[1] = 1;
        }
        else if(saveskin == 10)
        {
            skins[2] = 1;
        }
        else if(saveskin == 11)
        {
            skins[1] = 1;
            skins[2] = 2;
        }
        shieldtext.text = shield + "";
    }

    //Update
    void Update()
    {
        meters = (int)stick1.transform.position.x / 2;
        meterstext.text = meters + "m";
        coinstext.text = gems + "";
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            JumpUp();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            JumpRight();
        }
    }

    //Collision
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Boost_shield")
        {
            Destroy(col.gameObject);
        }
        else if(col.gameObject.tag == "Coin")
        {
            gems++;
            Destroy(col.gameObject);
        }
        else if(col.gameObject.tag == "Boost_")
        {
            Destroy(col.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Coin")
        {
            gems++;
            Destroy(col.gameObject);
        }
    }

    //Functions
    public void JumpRight()
    {
        stick1RB.AddForce(transform.right * m_speed, ForceMode2D.Impulse);
    }
    public void JumpUp()
    {
        stick1RB.AddForce(transform.up * m_speed, ForceMode2D.Impulse);        
    }
    public void DestroyPlayer()
    {
        if(shield == 0)
        {
            Destroy(this.gameObject);
            if (meters > HI_score)
            {
                HI_score = meters;
                hi_scoretext.text = "[NOVO] Najviša rezultat: " + HI_score + "m";
            }
            else
            {
                hi_scoretext.text = "Najviša rezultat: " + HI_score + "m";
            }
            scriptmanager.SendMessage("ShowScore");
            finalscoretext.text = "Rezultat: " + meters + "m";
            
            
            SaveSystem.SavePlayer(this);


        }
    }
    public void AddCoin()
    {
        gems++;
    }
    public void Shield(bool value)
    {
        if(shield == 0 && value == false)
        {            
            DestroyPlayer();
        }
        else if(value)
        {
            shield++;
            shieldtext.text = shield + "";
        }
        else
        {
            shield--;
            shieldtext.text = shield + "";
        }
        
    }
    public void PausePlayer(bool value)
    {
        if(value)
        {
            stick1RB.bodyType = RigidbodyType2D.Static;
            stick2RB.bodyType = RigidbodyType2D.Static;
        }
        else
        {
            stick1RB.bodyType = RigidbodyType2D.Dynamic;
            stick2RB.bodyType = RigidbodyType2D.Dynamic;
        }
        
    }
    public void PlaySound()
    {
        audioData.Play();
    }

    public void ChangeColor(int value)
    {
        a += value;
        if (a == 3)
        {
            a = 0;
        }
        if(a < 0)
        {
            a = 2;
        }
        if (a == 0)
        {
            SetSkinColour(0);
            SkinTexts(0, 0);
        }
        else if (a == 1)
        {
            SetSkinColour(1);
            SkinTexts(20, 1);

        }
        else if(a == 2)
        {
            SetSkinColour(2);
            SkinTexts(40, 2);
        }
    }
    private void SkinTexts(int price, int skin)
    {
        switch (skins[skin])
        {
            case 0:
                if(price == 0){
                    pricetext.text = "Free";
                }
                else
                {
                    pricetext.text = price + "";
                } 
                getbuttontext.text = "Get";
            break;
            case 1:
                pricetext.text = "Owned";
                getbuttontext.text = "Use";
            break;
            case 2:
                pricetext.text = "Owned";
                getbuttontext.text = "Selected";
            break;
        }
    }
    public void UnlockSkin()
    {
        //Debug.Log(skins[a]);
        switch(skins[a])
        {
            case 0:
                if(a == 1 && gems >= 20)
                {
                    DeselectSkins();
                    gems -= 20;
                    skins[a] = 2;
                    saveskin += 1;
                    SkinTexts(20, a);
                }
                else if(a == 2 && gems >= 40)
                {
                    DeselectSkins();
                    gems -= 40;
                    skins[a] = 2;
                    saveskin += 10;
                    SkinTexts(40, a);
                }         
            break;
            case 1:
                DeselectSkins();
                skins[a] = 2;
            break;
            default:
            break;
        }
    }
    private void DeselectSkins(){
        if(skins[0] == 2) skins[0] = 1;
        if(skins[1] == 2) skins[1] = 1;
        if(skins[2] == 2) skins[2] = 1;
    }
    public void SetSkinColour(int skin)
    {
        switch (skin)
        {
            case 1:
                s1.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
                s2.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            break;
            case 2:
                s1.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                s2.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            break;
            case 3:
                s1.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                s2.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            break;
        }
    }
    private int GetSkin()
    {
        if(skins[0] == 2) return 0;
        else if(skins[1] == 2) return 1;
        else if(skins[2] == 2) return 2;
        else return 0;

    }
    public void SetSkin(){
        SetSkinColour(GetSkin());
    }
    public void ChangeBack()
    {
        if(skins[a] != 1)
        {
            s1.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            s2.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        }
    }

}
