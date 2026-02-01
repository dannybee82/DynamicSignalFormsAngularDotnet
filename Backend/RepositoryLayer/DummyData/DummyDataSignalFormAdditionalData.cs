using RepositoryLayer.Entity;
using RepositoryLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.DummyData
{
    public class DummyDataSignalFormAdditionalData
    {

        public static List<SignalFormAdditionalData> Create()
        {
            return new List<SignalFormAdditionalData>()
            {
                // The first from
                new SignalFormAdditionalData()
                {
                    Id = 1,
                    Attribute = "cols",
                    Value = "30",
                    AttributeType = AttributeType.NUMBER,
                    SignalFormFieldId = 4
                },
                new SignalFormAdditionalData()
                {
                    Id = 2,
                    Attribute = "rows",
                    Value = "5",
                    AttributeType = AttributeType.NUMBER,
                    SignalFormFieldId = 4
                },
                // The second from
                new SignalFormAdditionalData()
                {
                    Id = 3,
                    Attribute = "cols",
                    Value = "30",
                    AttributeType = AttributeType.NUMBER,
                    SignalFormFieldId = 8
                },
                new SignalFormAdditionalData()
                {
                    Id = 4,
                    Attribute = "rows",
                    Value = "5",
                    AttributeType = AttributeType.NUMBER,
                    SignalFormFieldId = 8
                },
                // The third form
                // The fourth form
                // The fifth form
                // The sixth form
                // The seventh form
                // The eighth form

            };
        }

    }

}