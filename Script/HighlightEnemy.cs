using System;
using System.Collections.Generic;
using UnityEngine;

public class HighlightEnemy : MonoBehaviour
{
    public List<Renderer> render;
    public Color highlightColor;
    public string highlightHex = "#A4F3A0";
    public Color normalColor;
    public float radius;
    public Transform player;
    void Start()
    {
        
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.transform;

        
        highlightColor = HEXToColor(highlightHex);
    }

    private void OnMouseEnter()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                foreach (Renderer render in render)
                {
                    render.material.color = highlightColor;    
                }
            }
        }
    }

    private void OnMouseExit()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            foreach (Renderer render in render)
            {
                render.material.color = normalColor;    
            }
        }   
    }
    
    Color HEXToColor(string hex)
    {
       hex = hex.Replace("#", "");
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        
        byte a = 255;
        if (hex.Length == 8)
        {
            a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
        }
        return new Color32(r, g, b, a);
    }
}
