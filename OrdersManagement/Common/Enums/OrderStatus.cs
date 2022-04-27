using System.ComponentModel;

namespace OrdersManagement.Common.Enums
{
    public enum OrderStatus
    {
        [Description("In process")]
        Inprocess = 0,

        [Description("Paid")]
        Paid = 1,

        [Description("Viewed")]
        Viewed = 2,
        
        [Description("Rejected")]
        Rejected = 3,

        [Description("Ready for dispatch")]
        ReadyForDispatch = 4,

        [Description("Dispatched")]
        Dispatched = 5,

        [Description("Delivered")]
        Delivered = 6,

        [Description("Closed")]
        Closed = 7
    }
}
