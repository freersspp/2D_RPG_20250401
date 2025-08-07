using UnityEngine;
namespace PPman
{

    public class Skull : Item
    {
        protected override void GetItem()
        {
            base.GetItem();
            SoundManager.Instance.PlaySound(SoundType.ItemGet, 0.9f, 1.5f);
            Knight.Instance.GetItem();
        }


    }
}