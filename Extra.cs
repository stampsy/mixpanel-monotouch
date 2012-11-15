using System;
using MonoTouch.Foundation;

namespace MixpanelApi
{
    public partial class MixpanelPeople 
    {
        public object this [string key] {
            set {
                NSObject obj;
                switch (Type.GetTypeCode (value.GetType ())) {
                case TypeCode.DateTime:
                    obj = NSDate.FromTimeIntervalSinceReferenceDate (((DateTime)value - (new DateTime(2001,1,1,0,0,0))).TotalSeconds);
                    break;
                default:
                    obj = NSObject.FromObject (value);
                    break;
                }
                Set (key, obj);
            }
        }
    }
}

