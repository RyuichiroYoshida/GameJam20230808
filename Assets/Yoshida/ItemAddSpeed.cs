using UnityEngine;

public class ItemAddSpeed : ItemBase
{
    [SerializeField] float _addSpeed = 1f;
    
    protected override void ItemGet()
    {
        PlayerController.Instance.MoveSpeed += _addSpeed;
    }
}
