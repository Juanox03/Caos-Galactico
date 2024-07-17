using UnityEngine;
using UnityEngine.UI;

public class Enemy1 : Enemy
{
    [SerializeField] Image _barLife;
    [SerializeField] float _maxLife;
    [SerializeField] float _life;

    private void Start()
    {
        _life = _maxLife;
    }

    public override void GetDamage(float dmg)
    {
        _life -= dmg;
        _barLife.fillAmount = _life / _maxLife;
    }
}