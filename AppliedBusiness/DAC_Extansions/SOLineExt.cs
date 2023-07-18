using PX.Data;
using PX.Objects.IN;

namespace AppliedBusiness
{
    public class SOLineExt : PXCacheExtension<PX.Objects.SO.SOLine>
    {

        #region UsrSODescription
        [PXDBLocalizableString(IsUnicode = true)]
        [PXUIField(DisplayName = "Description")]
        public virtual string UsrSODescription { get; set; }
        public abstract class usrSODescription : PX.Data.BQL.BqlString.Field<usrSODescription> { }
        #endregion
    }
}
