using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created by Yan Ho Chan - 301008722 - Oct 4, 2019 - COMP305 C094
public class DestroyObject : MonoBehaviour { 
    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
