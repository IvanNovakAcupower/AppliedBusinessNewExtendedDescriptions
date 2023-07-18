using System.Collections;
using PX.Data;
using PX.Objects.SO;
using PX.Objects.IN;

namespace AppliedBusiness
{
    public class SOOrderEntry_Extension : PXGraphExtension<PX.Objects.SO.SOOrderEntry>
    {
        #region Event Handlers

        protected void SOLine_InventoryID_FieldUpdated(PXCache cache, PXFieldUpdatedEventArgs e)
        {
            SOLine row = (SOLine)e.Row;
            InventoryItem item = PXSelect<InventoryItem,
                    Where<InventoryItem.inventoryID, Equal<Required<InventoryItem.inventoryID>>>>
                    .Select(Base, row.InventoryID);
            if (item != null) cache.SetValueExt<SOLineExt.usrSODescription>(row, item.Body);
        }
        #endregion
    }


}