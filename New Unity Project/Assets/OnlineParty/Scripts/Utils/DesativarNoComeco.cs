using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnlineParty
{
    public class DesativarNoComeco : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            this.gameObject.SetActive(false);
        }
    }
}
