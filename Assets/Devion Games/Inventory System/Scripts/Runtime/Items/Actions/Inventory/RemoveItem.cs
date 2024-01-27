using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

namespace DevionGames.InventorySystem.ItemActions
{
    [UnityEngine.Scripting.APIUpdating.MovedFromAttribute(true, null, "Assembly-CSharp")]
    [Icon("Item")]
    [ComponentMenu("Inventory System/Remove Item")]
    [System.Serializable]
    public class RemoveItem : ItemAction
    {
        [SerializeField]
        private string m_WindowName = "Inventory";
        [ItemPicker(true)]
        [SerializeField]
        private Item m_Item = null;
        [Range(1,200)]
        [SerializeField]
        private int m_Amount = 1;


        public override ActionStatus OnUpdate()
        {
            if (ItemContainer.RemoveItem(this.m_WindowName, this.m_Item, this.m_Amount))
            {
                return ActionStatus.Success;
            }
            return ActionStatus.Failure;
        }
        //public ActionStatus Checkitem()
        //{
        //    if (Input.GetKeyDown(KeyCode.E))
        //    {
        //        if (ItemContainer.RemoveItem(this.m_WindowName, this.m_Item, this.m_Amount))
        //        {
        //            return ActionStatus.Success;
        //        }
        //        return ActionStatus.Failure;
        //    }
        //    return ActionStatus.Failure;
        //}
    }
}