using System.Drawing;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] protected int damage = 2;
    [SerializeField] protected float moveSpeed = 2f;
    [SerializeField] protected float stop = 10f;
    [SerializeField] protected float stopFire;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform firePoint;

}
