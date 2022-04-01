using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowTypeManager : MonoBehaviour
{
    public enum TypeOfArrow { Regular, Fire, Ice, MeteorShower, Lightning, Rain, Heal, Target };
    Button button;
    public TypeOfArrow typeOfArrow;
    [SerializeField] ArrowStoreManager arrowStoreManager;

    private void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }
    public void OnClick()
    {

    }
}
