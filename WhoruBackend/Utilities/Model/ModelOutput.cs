using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoruBackend.Utilities.Model
{
    class ModelOutput
    {
        public string PredictedLabel { get; set; }
        public float[] Score { get; set; }
    }
}
