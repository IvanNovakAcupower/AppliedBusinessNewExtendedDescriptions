using System.Collections;
using PX.Data;
using PX.Objects.SO;
using PX.Objects.IN;
using PX.Objects.AM;
using PX.Objects.CN.Compliance.AR.CacheExtensions;

namespace AppliedBusiness
{
    public class ProdMaint_Extension : PXGraphExtension<ProdMaint>
    {
        #region Event Handlers
        protected void AMProdItem_OrdNbr_FieldUpdated(PXCache cache, PXFieldUpdatedEventArgs e)
        {
            var row = (AMProdItem)e.Row;
            SOLine line = PXSelect<SOLine,
                Where<SOLine.orderType, Equal<Required<SOLine.orderType>>,
                    And<SOLine.orderNbr, Equal<Required<SOLine.orderNbr>>,
                    And<SOLine.lineNbr, Equal<Required<SOLine.lineNbr>>>>>>
                    .Select(Base, row.OrdTypeRef, row.OrdNbr, row.OrdLineRef);
            if (line != null) cache.SetValueExt<AMProdItemExt.usrPRDescription>(row, line.GetExtension<SOLineExt>().UsrSODescription);
        }
        protected void AMProdItem_InventoryId_FieldUpdated(PXCache cache, PXFieldUpdatedEventArgs e)
        {
            var row = (AMProdItem)e.Row;
            if (row.OrdNbr != null) return;

            InventoryItem item = PXSelect<InventoryItem,
            Where<InventoryItem.inventoryID, Equal<Required<InventoryItem.inventoryID>>>>
                .Select(Base, row.InventoryID);
            if (item != null) cache.SetValueExt<AMProdItemExt.usrPRDescription>(row, item.Body);
        }
        #endregion
    }

    
}