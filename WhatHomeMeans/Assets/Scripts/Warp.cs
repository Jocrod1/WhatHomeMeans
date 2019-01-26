using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Warp : MonoBehaviour {

    public GameObject Target;

    bool start = false;
    bool isfadein = false;
    float alpha = 0;
    public float fadetime = 1f;

    public FollowTarget t;

    public Image Panel;

    float vel;
    void Awake() {
        Resources.UnloadUnusedAssets();
        GC.Collect();
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        t = Camera.main.GetComponent<FollowTarget>();
        Panel = GameObject.Find("Canvas").transform.GetChild(1).GetComponent<Image>();
    }

    IEnumerator OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "2Player" || other.gameObject.tag == "3Player")
        {
            FadeIn();


            yield return new WaitForSeconds(fadetime);

            other.transform.position = Target.transform.GetChild(0).transform.position;

            t.Isfade = true;
            
            FadeOut();
        }
    }

    void Update() {
        if (!start)
            return;

        if (isfadein)
        {
            alpha = Mathf.SmoothDamp(Panel.color.a, 1.1f, ref vel, fadetime);
        }
        else {
            alpha = Mathf.SmoothDamp(Panel.color.a, -0.1f, ref vel, fadetime);
            if (alpha < 0) start = false;
        }
        Panel.color = new Color(Panel.color.r, Panel.color.g, Panel.color.b, alpha);
    }

    void FadeIn() {
        start = true;
        isfadein = true;
    }
    void FadeOut() {
        isfadein = false;
    }   
}
