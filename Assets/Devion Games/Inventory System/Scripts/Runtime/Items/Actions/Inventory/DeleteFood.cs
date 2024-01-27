using DevionGames.InventorySystem;
using DevionGames.InventorySystem.ItemActions;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

namespace DevionGames
{
    [UnityEngine.Scripting.APIUpdating.MovedFromAttribute(true, null, "Assembly-CSharp")]
    [Icon("Item")]
    [ComponentMenu("Inventory System/Remove Item")]
    [System.Serializable]
    public class DeleteFood : Action
    {
        [SerializeField]
        private string m_WindowName = "Inventory";
        [ItemPicker(true)]
        [SerializeField]
        private Item m_Item = null;
        [Range(1, 200)]
        [SerializeField]
        private int m_Amount = 1;

        public override ActionStatus OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (ItemContainer.RemoveItem(this.m_WindowName, this.m_Item, this.m_Amount))
                {
                    return ActionStatus.Success;
                }
                else
                {
                    return ActionStatus.Failure;
                }         
            }
            else
            {
                return ActionStatus.Failure;
            }
          
        }
    }
}