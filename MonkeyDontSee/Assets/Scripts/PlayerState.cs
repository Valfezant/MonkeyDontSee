using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    //NNEDS TO BRING UP SACRIFICE SCREEN

    public float maxPlayerHealth;
    public float playerHealth;
    
    [SerializeField] private int iframesTime;
    private bool _iFrames;
    private SpriteRenderer spriteRend;

    public bool _isDead;
    
    void Start()
    {
        _iFrames = false;
        spriteRend = GetComponent<SpriteRenderer>();
        playerHealth = maxPlayerHealth;
    }

    void Update()
    {
        if (playerHealth <= 0 && !_isDead)
        {
            var manager = GameObject.FindWithTag("Manager").GetComponent<EyesManager>();
            manager.SacrificeScreen();

            Debug.Log("DIED");

            _isDead = true;
            _iFrames = true;
        }
        else if (playerHealth > 0)
        {
            _isDead = false;
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
