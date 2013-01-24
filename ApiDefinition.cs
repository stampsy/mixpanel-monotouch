using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MixpanelApi
{
    [BaseType (typeof (NSObject))]
    interface Mixpanel {
        [Export ("people", ArgumentSemantic.Retain)]
        MixpanelPeople People { get;  }
        
        [Export ("distinctId", ArgumentSemantic.Copy)]
        string DistinctId { get; [Bind ("identify:")] set;  }
        
        [Export ("nameTag", ArgumentSemantic.Copy)]
        string NameTag { get; set;  }
        
        [Export ("serverURL", ArgumentSemantic.Copy)]
        string ServerURL { get; set;  }
        
        [Export ("flushInterval")]
        uint FlushInterval { get; set;  }
        
        [Export ("flushOnBackground")]
        bool FlushOnBackground { get; set;  }
        
        [Export ("showNetworkActivityIndicator")]
        bool ShowNetworkActivityIndicator { get; set;  }
        
        [Wrap ("WeakDelegate")]
        MixpanelDelegate Delegate { get; set; }
        
        [Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
        NSObject WeakDelegate { get; set; }

        [Static]
        [Export ("sharedInstanceWithToken:")]
        Mixpanel SharedInstanceWithToken (string apiToken);
        
        [Static]
        [Export ("sharedInstance")]
        Mixpanel SharedInstance { get; }
        
        [Export ("initWithToken:andFlushInterval:")]
        IntPtr Constructor (string apiToken, uint flushInterval);
        
        [Export ("track:")]
        void Track (string eventName);
        
        [Export ("track:properties:")]
        void Track (string eventName, NSDictionary properties);
        
        [Export ("registerSuperProperties:")]
        void RegisterSuperProperties (NSDictionary properties);
        
        [Export ("registerSuperPropertiesOnce:")]
        void RegisterSuperPropertiesOnce (NSDictionary properties);
        
        [Export ("registerSuperPropertiesOnce:defaultValue:")]
        void RegisterSuperPropertiesOnce (NSDictionary properties, NSObject defaultValue);
        
        [Export ("clearSuperProperties")]
        void ClearSuperProperties ();
        
        [Export ("currentSuperProperties")]
        NSDictionary CurrentSuperProperties ();
        
        [Export ("reset")]
        void Reset ();
        
        [Export ("flush")]
        void Flush ();
        
        [Export ("archive")]
        void Archive ();
    }
    
    [BaseType (typeof (NSObject))]
    interface MixpanelPeople {
        [Export ("distinctId", ArgumentSemantic.Copy)]
        string DistinctId { get;  [Bind ("identify:")] set;  }
        
        [Export ("addPushDeviceToken:")]
        void AddPushDeviceToken (NSData deviceToken);
        
        [Export ("set:")]
        void Set (NSDictionary properties);
        
        [Export ("set:to:")]
        void Set (string property, NSObject toObject);
        
        [Export ("increment:")]
        void Increment (NSDictionary properties);
        
        [Export ("increment:by:")]
        void Increment (string property, NSNumber amount);
        
        [Export ("deleteUser")]
        void DeleteUser ();
    }
    
    [BaseType (typeof (NSObject))]
    [Model]
    interface MixpanelDelegate {
        [Export ("mixpanelWillFlush:")]
        bool WillFlush (Mixpanel mixpanel);
    }
}

