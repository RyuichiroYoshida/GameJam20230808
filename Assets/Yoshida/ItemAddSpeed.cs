using UnityEngine;

public class ItemAddSpeed : ItemBase
{
    [SerializeField] float _addSpeed = 1f;
    
    public override void ItemGet()
    {
        PlayerController.Instance.MoveSpeed += _addSpeed;
        print("SpeedItemGet");
    }
}
