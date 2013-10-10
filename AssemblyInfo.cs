using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libMixpanel-Universal.a", LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true)]
