using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fumee : MonoBehaviour
{
    // Start is called before the first frame update

     public void suicide()
    {
        transform.parent.GetComponent<CultistController>().isInDialog = false;
    Destroy(gameObject);
    }
    public void Transfro()
    {
        transform.parent.GetChild(0).GetComponent<Animator>().SetFloat("Index", 5);
    }

}
