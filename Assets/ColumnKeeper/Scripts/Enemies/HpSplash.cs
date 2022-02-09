using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HpSplash : MonoBehaviour
{
    [Header("Splash Text Info")]
    public TextMeshProUGUI HpSplashText; ////// HP Splash text
    public float lifetime = 0.6f;///// HP splash
    public float minDist = 5f;///// HP splash
    public float maxDist = 10f;///// HP splash
    private Vector3 iniPos; ///// HP splash
    private Vector3 targetPos;///// HP splash
    private float timer;///// HP splash



    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position);
        float direction = Random.rotation.eulerAngles.z;
        iniPos = transform.position;
        float dist = Random.Range(minDist, maxDist);
        targetPos = iniPos + (Quaternion.Euler(0, 0, direction) * new Vector3(dist, dist, 0f));
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float fraction = lifetime / 2f;
        if (timer > lifetime) Destroy(gameObject);
        else if (timer > fraction) HpSplashText.color = Color.Lerp(HpSplashText.color, Color.clear, (timer - fraction) / (lifetime - fraction));

        transform.position = Vector3.Lerp(iniPos, targetPos, Mathf.Sin(timer / lifetime));
        transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, Mathf.Sin(timer / lifetime));
    
    
    }
    public void SetDamageText (float damage)
    {
        HpSplashText.text = damage.ToString();
        Debug.Log(damage);
    }
}
