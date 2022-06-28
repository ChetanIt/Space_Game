using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "New Weapon/Gun")]
public class Gun_Obj : ScriptableObject
{
    public string gun_name;
    public float bul_speed, fire_rate;
    public int num_of_buls;
    
}
