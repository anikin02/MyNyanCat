using UnityEngine;
using UnityEngine.UI;


public class Heart : MonoBehaviour
{
    public void LoseHeart()
    {
        GetComponent<Image>().color = new Color32(51,51,51,255);
    }
}
