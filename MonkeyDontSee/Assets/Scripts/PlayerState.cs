using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    //HP => die
    //n eyes & state
    //deactivate eye

    public float playerHealth;
    
    [SerializeField] private int iframesTime;
    private bool _iFrames;
    private SpriteRenderer spriteRend;
    
    
    void Start()
    {
        _iFrames = false;
        spriteRend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (playerHealth == 0)
        {
            Debug.Log("DIED");
        }
    }

    public void DamagePlayer(float damageTaken)
    {
        if (!_iFrames)
        {
            playerHealth -= damageTaken;
            Debug.Log(damageTaken);
            StartCoroutine(startIFrames());
        }
    }

    private IEnumerator startIFrames()
    {
        _iFrames = true;
        spriteRend.color = new Color(0.2f, 0, 0, 1f);
        Debug.Log(_iFrames);

        yield return new WaitForSeconds(iframesTime);

        _iFrames = false;
        spriteRend.color = Color.white;
        Debug.Log(_iFrames);
    }
}
