using System;
using System.Collections;
using System.Linq;
using BizTalkComponents.Utils;

namespace BizTalkComponents.PipelineComponents.PromoteNewGuid
{
    public partial class PromoteNewGuid
    {
        public string Name { get { return "PromoteNewGuid"; } }
        public string Version { get { return "1.0"; } }
        public string Description { get { return "Promotes a new guid"; } }
        
        public void GetClassID(out Guid classID)
        {
            classID = Guid.Parse("FCC03491-D4E4-42D3-8295-9E32733573D8");
        }

        public void InitNew()
        {
            
        }

        public IntPtr Icon { get { return IntPtr.Zero; } }

        public IEnumerator Validate(object projectSystem)
        {
            return ValidationHelper.Validate(this, false).ToArray().GetEnumerator();
        }

        public bool Validate(out string errorMessage)
        {
            var errors = ValidationHelper.Validate(this, true).ToArray();

            if (errors.Any())
            {
                errorMessage = string.Join(",", errors);

                return false;
            }

            errorMessage = string.Empty;

            return true;
        }
    }
}