using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcAbility : MonoBehaviour
{
    [SerializeField] private ParticleSystem ability;
    [SerializeField] private float timetoPlayAbility;
    [SerializeField] private float abilityCoolDown;

    private float t;

    // Start is called before the first frame update
    void Start()
    {
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        if(t > abilityCoolDown)
        {
            PlayAbility();
        }
    }

    private void PlayAbility()
    {
        
       StartCoroutine(CoolDown());
    }

    private IEnumerator CoolDown()
    {
        ability.Play();
        yield return new WaitForSeconds(abilityCoolDown);
        ability.Stop();
        t = 0;
    }
}
