package md5c1bf5d923ac0cddfc21fa474230ef062;


public class Battery_ChargerMonitor
	extends md5c1bf5d923ac0cddfc21fa474230ef062.BroadcastMonitor
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onReceive:(Landroid/content/Context;Landroid/content/Intent;)V:GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("XLabs.Platform.Device.Battery+ChargerMonitor, XLabs.Platform.Droid, Version=2.0.5782.12262, Culture=neutral, PublicKeyToken=null", Battery_ChargerMonitor.class, __md_methods);
	}


	public Battery_ChargerMonitor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Battery_ChargerMonitor.class)
			mono.android.TypeManager.Activate ("XLabs.Platform.Device.Battery+ChargerMonitor, XLabs.Platform.Droid, Version=2.0.5782.12262, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onReceive (android.content.Context p0, android.content.Intent p1)
	{
		n_onReceive (p0, p1);
	}

	private native void n_onReceive (android.content.Context p0, android.content.Intent p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
