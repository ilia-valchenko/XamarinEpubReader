package md50a303b86131d0533879405f1bc0332bd;


public class GestureImageListener
	extends android.view.GestureDetector.SimpleOnGestureListener
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLongPress:(Landroid/view/MotionEvent;)V:GetOnLongPress_Landroid_view_MotionEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("App1.Droid.Listeners.GestureImageListener, App1.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", GestureImageListener.class, __md_methods);
	}


	public GestureImageListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == GestureImageListener.class)
			mono.android.TypeManager.Activate ("App1.Droid.Listeners.GestureImageListener, App1.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onLongPress (android.view.MotionEvent p0)
	{
		n_onLongPress (p0);
	}

	private native void n_onLongPress (android.view.MotionEvent p0);

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
