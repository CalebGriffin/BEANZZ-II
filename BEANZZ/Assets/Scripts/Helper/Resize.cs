using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : MonoBehaviour
{

    [Range(1, 5)]
    public int sizeIndex;
    int sizeIndexMin = 1, sizeIndexMax = 5;
    float offset = 0.3f, sizeIndexWeight = 0.1f;

    public Material[] materials;
    Material mat;

    public ParticleSystem resizeFX;
    ParticleSystem prt;

    void Start()
    {
        mat = GetComponentInChildren<Renderer>().material;

        ResizeHelper();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Resizer")
        {
            switch (col.gameObject.name)
            {
                case "UpSizer":
                    sizeIndex++;
                    break;
                case "DownSizer":
                    sizeIndex--;
                    break;
                default:
                    break;
            }

            ResizeHelper();
            GiveColour();
            CleanParticles();     
        }

    }

    void ResizeHelper()
    {
        sizeIndex = Mathf.Clamp(sizeIndex, sizeIndexMin, sizeIndexMax);
        float s = (float)sizeIndex;
        gameObject.transform.localScale = new Vector3(offset + s * sizeIndexWeight, offset + s * sizeIndexWeight, offset + s * sizeIndexWeight);
    }

    void CleanParticles()
    {
        if (prt != null)
            Destroy(prt.gameObject);

        prt = Instantiate(resizeFX, this.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        prt.GetComponent<Renderer>().material.color = mat.color;
    }

    void GiveColour()
    {
        if (sizeIndex == sizeIndexMax)
            mat.color = materials[1].color;
        else if (sizeIndex == sizeIndexMin)
            mat.color = materials[2].color;
        else
            mat.color = materials[0].color;
    }
}
