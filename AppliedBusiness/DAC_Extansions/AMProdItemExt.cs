using PX.Data;
using PX.Objects.AM;
using PX.Objects.SO;

namespace AppliedBusiness
{
    public class StatusCompleted : PX.Data.BQL.BqlString.Constant<StatusCompleted>
    {
        public StatusCompleted() : base("M") { }
    }
    public class AMProdItemExt : PXCacheExtension<PX.Objects.AM.AMProdItem>
    {
        #region UsrPRDescription
        [PXDBLocalizableString(IsUnicode = true)]
        [PXUIField(DisplayName = "Description")]

        [PXUIEnabled(typeof(Where<AMProdItem.statusID.IsNotEqual<StatusCompleted>>))]

        public virtual string UsrPRDescription { get; set; }
        public abstract class usrPRDescription : PX.Data.BQL.BqlString.Field<usrPRDescription> { }
        #endregion

    }
}