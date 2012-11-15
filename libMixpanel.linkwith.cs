using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libMixpanel.a", LinkTarget.ArmV7 | LinkTarget.Simulator, ForceLoad = true)]
