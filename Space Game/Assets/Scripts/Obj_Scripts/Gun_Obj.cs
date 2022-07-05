using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "New Weapon/Gun")]
public class Gun_Obj : ScriptableObject
{
    [Header("Properties")]
    public string gun_name;
    public float bul_speed, fire_rate;
    public int num_of_buls;

   
    public enum Bul_Type {Missile, Laser, Normal};
    [Header("BulletType")]
    public Bul_Type bul_type;
}
