using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WebLink : MonoBehaviour
{
    public void OpenLinkFromSp(Especie sp)
    {
        Application.OpenURL(sp.Link);
    }


}
