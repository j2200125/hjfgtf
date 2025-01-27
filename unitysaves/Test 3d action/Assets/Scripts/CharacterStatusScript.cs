using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterStatusScript : MonoBehaviour
{

    Animator anim;
    public UnityEvent onDieCallback = new UnityEvent();

    public int life = 100;

    public Slider hpBar;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        if(hpBar != null)
        {
            hpBar.value = life;
        }
        
    }

    // Update is called once per frame
    public void Damage(int damage)
    {
        if (life <= 0) return;

        life -= damage;

        if(hpBar != null)
        {
            hpBar.value = life;
        }
        if(life <= 0)
        {
            OnDie();
        }

    }

    public void OnDie()
    {
        anim.SetBool("Die", true);
        onDieCallback.Invoke();
    }
}
