using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BizTalkComponents.Utils;
using Microsoft.BizTalk.Component.Interop;
using Microsoft.BizTalk.Message.Interop;
using IComponent = Microsoft.BizTalk.Component.Interop.IComponent;

namespace BizTalkComponents.PipelineComponents.PromoteNewGuid
{
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [System.Runtime.InteropServices.Guid("42CB3224-572E-4C7D-9DDB-0B485F49C37F")]
    [ComponentCategory(CategoryTypes.CATID_Any)]
    public partial class PromoteNewGuid : IComponent, IBaseComponent,
                                        IPersistPropertyBag, IComponentUI
    {
        private const string DestinationPropertyPropertyName = "DestinationProperty";

        [RequiredRuntime]
        [DisplayName("Destination property")]
        [Description("The property path of the property to promote the guid to.")]
        [RegularExpression(@"^.*#.*$",
        ErrorMessage = "A property path should be formatted as namespace#property.")]
        public string DestinationProperty { get; set; }

        public IBaseMessage Execute(IPipelineContext pContext, IBaseMessage pInMsg)
        {
            string errorMessage;

            if (!Validate(out errorMessage))
            {
                throw new ArgumentException(errorMessage);
            }

            pInMsg.Context.Promote(new ContextProperty(DestinationProperty),Guid.NewGuid().ToString());

            return pInMsg;
        }
        
        public void Load(IPropertyBag propertyBag, int errorLog)
        {
            DestinationProperty = PropertyBagHelper.ReadPropertyBag<string>(propertyBag, DestinationPropertyPropertyName);
        }

        public void Save(IPropertyBag propertyBag, bool clearDirty, bool saveAllProperties)
        {
            PropertyBagHelper.WritePropertyBag(propertyBag, DestinationPropertyPropertyName, DestinationProperty);
        }
    }
}
